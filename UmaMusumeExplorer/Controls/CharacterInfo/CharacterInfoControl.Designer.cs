
namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class CharacterInfoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterInfoControl));
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.charactersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.selectLabel = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.charaListComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // loadingProgressBar
            // 
            resources.ApplyResources(this.loadingProgressBar, "loadingProgressBar");
            this.loadingProgressBar.Name = "loadingProgressBar";
            // 
            // loadingBackgroundWorker
            // 
            this.loadingBackgroundWorker.WorkerReportsProgress = true;
            this.loadingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadingBackgroundWorker_DoWork);
            this.loadingBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadingBackgroundWorker_ProgressChanged);
            this.loadingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadingBackgroundWorker_RunWorkerCompleted);
            // 
            // charactersPanel
            // 
            resources.ApplyResources(this.charactersPanel, "charactersPanel");
            this.charactersPanel.Name = "charactersPanel";
            // 
            // selectLabel
            // 
            resources.ApplyResources(this.selectLabel, "selectLabel");
            this.selectLabel.Name = "selectLabel";
            // 
            // goButton
            // 
            resources.ApplyResources(this.goButton, "goButton");
            this.goButton.Name = "goButton";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // charaListComboBox
            // 
            this.charaListComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.charaListComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.charaListComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.charaListComboBox, "charaListComboBox");
            this.charaListComboBox.Name = "charaListComboBox";
            // 
            // CharacterInfoControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.charaListComboBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.charactersPanel);
            this.Name = "CharacterInfoControl";
            this.Load += new System.EventHandler(this.CharacterInfoControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.ComponentModel.BackgroundWorker loadingBackgroundWorker;
        private System.Windows.Forms.FlowLayoutPanel charactersPanel;
        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.ComboBox charaListComboBox;
    }
}
