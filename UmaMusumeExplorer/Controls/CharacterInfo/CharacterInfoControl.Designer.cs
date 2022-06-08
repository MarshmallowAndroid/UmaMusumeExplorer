
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
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.Location = new System.Drawing.Point(223, 215);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(281, 23);
            this.loadingProgressBar.TabIndex = 3;
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
            this.charactersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charactersPanel.AutoScroll = true;
            this.charactersPanel.Location = new System.Drawing.Point(0, 32);
            this.charactersPanel.Name = "charactersPanel";
            this.charactersPanel.Size = new System.Drawing.Size(727, 389);
            this.charactersPanel.TabIndex = 4;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(3, 6);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(68, 15);
            this.selectLabel.TabIndex = 5;
            this.selectLabel.Text = "Select by ID";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(279, 3);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 7;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // charaListComboBox
            // 
            this.charaListComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.charaListComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.charaListComboBox.FormattingEnabled = true;
            this.charaListComboBox.Location = new System.Drawing.Point(77, 3);
            this.charaListComboBox.Name = "charaListComboBox";
            this.charaListComboBox.Size = new System.Drawing.Size(196, 23);
            this.charaListComboBox.TabIndex = 8;
            // 
            // CharacterInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.charaListComboBox);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.charactersPanel);
            this.Name = "CharacterInfoControl";
            this.Size = new System.Drawing.Size(730, 424);
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
