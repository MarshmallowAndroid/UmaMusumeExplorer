using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace UmaMusumeExplorer.Controls.Common
{
    internal abstract class ItemsPanel<TargetType> : FlowLayoutPanel
    {
        private readonly BackgroundWorker loadingBackgroundWorker = new();
        private IEnumerable<TargetType> items;

        public ItemsPanel()
        {
            DoubleBuffered = true;

            loadingBackgroundWorker.WorkerReportsProgress = true;
            loadingBackgroundWorker.DoWork += LoadingBackgroundWorker_DoWork;
            loadingBackgroundWorker.ProgressChanged += LoadingBackgroundWorker_ProgressChanged;
            loadingBackgroundWorker.RunWorkerCompleted += LoadingBackgroundWorker_RunWorkerCompleted;
        }

        public ItemsPanel(IEnumerable<TargetType> itemList) : this()
        {
            items = itemList;
            LoadItems();
        }

        public IEnumerable<TargetType> Items
        {
            get => items;
            set
            {
                items = value;
                LoadItems();
            }
        }

        public abstract bool ProcessItem(TargetType item, ref Control displayControl);

        private void LoadItems()
        {
            if (items is not null)
            {
                AutoScroll = false;

                Controls.Clear();

                Panel tempPanel = new();
                tempPanel.Width = Width;
                tempPanel.Height = Height;

                ProgressBar loadingProgressBar = new() { Width = tempPanel.Width / 2 };
                loadingProgressBar.Left = (tempPanel.Width / 2) - (loadingProgressBar.Width / 2);
                loadingProgressBar.Top = (tempPanel.Height / 2) - (loadingProgressBar.Height / 2);
                tempPanel.Controls.Add(loadingProgressBar);

                Controls.Add(tempPanel);

                loadingBackgroundWorker.RunWorkerAsync();
            }
        }

        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Control> controls = new();
            int itemNumber = 0;
            foreach (var item in items)
            {
                Control control = null;
                if (ProcessItem(item, ref control) && (Filter?.Invoke(item) ?? true))
                {
                    control.Click += ItemClick;
                    controls.Add(control);
                }

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / items.Count() * 100.0F));
            }

            e.Result = controls.ToArray();
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Progress bar
            (Controls[0].Controls[0] as ProgressBar).Value = e.ProgressPercentage;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Controls.Clear();
            Controls.AddRange((Control[])e.Result);

            AutoScroll = true;

            LoadingFinished?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler LoadingFinished;
        public event EventHandler ItemClick;

        public ShouldFilter Filter;
        public delegate bool ShouldFilter(TargetType item);
    }
}
