
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
            loadingProgressBar = new System.Windows.Forms.ProgressBar();
            loadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            charactersPanel = new System.Windows.Forms.FlowLayoutPanel();
            selectLabel = new System.Windows.Forms.Label();
            goButton = new System.Windows.Forms.Button();
            charaListComboBox = new System.Windows.Forms.ComboBox();
            showPlayableCheckBox = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // loadingProgressBar
            // 
            resources.ApplyResources(loadingProgressBar, "loadingProgressBar");
            loadingProgressBar.Name = "loadingProgressBar";
            // 
            // loadingBackgroundWorker
            // 
            loadingBackgroundWorker.WorkerReportsProgress = true;
            loadingBackgroundWorker.DoWork += LoadingBackgroundWorker_DoWork;
            loadingBackgroundWorker.ProgressChanged += LoadingBackgroundWorker_ProgressChanged;
            loadingBackgroundWorker.RunWorkerCompleted += LoadingBackgroundWorker_RunWorkerCompleted;
            // 
            // charactersPanel
            // 
            resources.ApplyResources(charactersPanel, "charactersPanel");
            charactersPanel.Name = "charactersPanel";
            // 
            // selectLabel
            // 
            resources.ApplyResources(selectLabel, "selectLabel");
            selectLabel.Name = "selectLabel";
            // 
            // goButton
            // 
            resources.ApplyResources(goButton, "goButton");
            goButton.Name = "goButton";
            goButton.UseVisualStyleBackColor = true;
            goButton.Click += GoButton_Click;
            // 
            // charaListComboBox
            // 
            charaListComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            charaListComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            charaListComboBox.FormattingEnabled = true;
            resources.ApplyResources(charaListComboBox, "charaListComboBox");
            charaListComboBox.Name = "charaListComboBox";
            // 
            // showPlayableCheckBox
            // 
            resources.ApplyResources(showPlayableCheckBox, "showPlayableCheckBox");
            showPlayableCheckBox.Name = "showPlayableCheckBox";
            showPlayableCheckBox.UseVisualStyleBackColor = true;
            showPlayableCheckBox.CheckedChanged += ShowPlayableCheckBox_CheckedChanged;
            // 
            // CharacterInfoControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(showPlayableCheckBox);
            Controls.Add(charaListComboBox);
            Controls.Add(goButton);
            Controls.Add(loadingProgressBar);
            Controls.Add(selectLabel);
            Controls.Add(charactersPanel);
            Name = "CharacterInfoControl";
            Load += CharacterInfoControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.ComponentModel.BackgroundWorker loadingBackgroundWorker;
        private System.Windows.Forms.FlowLayoutPanel charactersPanel;
        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.ComboBox charaListComboBox;
        private System.Windows.Forms.CheckBox showPlayableCheckBox;
    }
}
