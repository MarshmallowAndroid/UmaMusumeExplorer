﻿using System.ComponentModel;

namespace UmaMusumeExplorer.Controls.Common
{
    internal abstract class ItemsPanel<TargetType> : FlowLayoutPanel
    {
        private readonly BackgroundWorker loadingBackgroundWorker = new();
        private IEnumerable<TargetType>? items;
        private bool indeterminate = false;

        public ItemsPanel()
        {
            DoubleBuffered = true;

            loadingBackgroundWorker.WorkerReportsProgress = true;
            loadingBackgroundWorker.DoWork += LoadingBackgroundWorker_DoWork;
            loadingBackgroundWorker.RunWorkerCompleted += LoadingBackgroundWorker_RunWorkerCompleted;
        }

        public ItemsPanel(IEnumerable<TargetType> itemList) : this()
        {
            items = itemList;
            LoadItems();
        }

        public IEnumerable<TargetType>? Items
        {
            get => items;
            set
            {
                items = value;
                LoadItems();
            }
        }

        public abstract bool ProcessItem(TargetType item, ref Control? displayControl);

        public bool Indeterminate
        {
            get
            {
                return indeterminate;
            }
            set
            {
                indeterminate = value;
            }
        }

        // Temporarily adds a panel with a progress bar to show loading progress.
        private void LoadItems()
        {
            if (items is not null)
            {
                AutoScroll = false;

                Controls.Clear();

                Panel tempPanel = new()
                {
                    Width = Width,
                    Height = Height
                };

                ProgressBar loadingProgressBar = new() { Width = tempPanel.Width / 2 };
                loadingProgressBar.MarqueeAnimationSpeed = 16;
                loadingProgressBar.Left = (tempPanel.Width / 2) - (loadingProgressBar.Width / 2);
                loadingProgressBar.Top = (tempPanel.Height / 2) - (loadingProgressBar.Height / 2);

                if (indeterminate)
                {
                    loadingProgressBar.Style = ProgressBarStyle.Marquee;
                }
                else
                {
                    loadingBackgroundWorker.ProgressChanged += LoadingBackgroundWorker_ProgressChanged;
                }

                tempPanel.Controls.Add(loadingProgressBar);

                Controls.Add(tempPanel);

                loadingBackgroundWorker.RunWorkerAsync();
            }
        }

        private void LoadingBackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (items is null) return;

            List<Control> controls = new();
            int itemNumber = 0;
            foreach (var item in items)
            {
                Control? control = null;
                if (ProcessItem(item, ref control) && (Filter?.Invoke(item) ?? true) && control is not null)
                {
                    control.Click += ItemClick;
                    controls.Add(control);
                }

                loadingBackgroundWorker.ReportProgress((int)((float)itemNumber++ / items.Count() * 100.0F));
            }

            e.Result = controls.ToArray();
        }

        private void LoadingBackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            // This control > temp panel control > progress bar
            if (Controls.Count < 1) return;
            if (Controls[0].Controls[0] is not ProgressBar progressBar) return;
            progressBar.Value = e.ProgressPercentage;
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            Controls.Clear();

            if (e.Result is Control[] result && result.Length > 0)
            {
                Controls.AddRange(result);
                AutoScroll = true;
            }
            else
            {
                Panel tempPanel = new()
                {
                    Width = Width,
                    Height = Height
                };

                Label noItemsLabel = new() { AutoSize = true, Text = "No items" };
                noItemsLabel.Left = (tempPanel.Width / 2) - (noItemsLabel.Width / 2);
                noItemsLabel.Top = (tempPanel.Height / 2) - (noItemsLabel.Height / 2);

                tempPanel.Controls.Add(noItemsLabel);

                Controls.Add(tempPanel);
                AutoScroll = false;
            }

            LoadingFinished?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? LoadingFinished;
        public event EventHandler? ItemClick;

        public ShouldFilter? Filter;
        public delegate bool ShouldFilter(TargetType item);
    }
}
