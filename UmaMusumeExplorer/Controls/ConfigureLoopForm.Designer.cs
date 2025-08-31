namespace UmaMusumeExplorer.Controls
{
    partial class ConfigureLoopForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureLoopForm));
            this.loopEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.startSampleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endSampleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startSamplesHintLabel = new System.Windows.Forms.Label();
            this.endSamplesHintLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startSampleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endSampleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // loopEnabledCheckBox
            // 
            resources.ApplyResources(this.loopEnabledCheckBox, "loopEnabledCheckBox");
            this.loopEnabledCheckBox.Name = "loopEnabledCheckBox";
            this.loopEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // startSampleNumericUpDown
            // 
            resources.ApplyResources(this.startSampleNumericUpDown, "startSampleNumericUpDown");
            this.startSampleNumericUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.startSampleNumericUpDown.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.startSampleNumericUpDown.Name = "startSampleNumericUpDown";
            // 
            // endSampleNumericUpDown
            // 
            resources.ApplyResources(this.endSampleNumericUpDown, "endSampleNumericUpDown");
            this.endSampleNumericUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.endSampleNumericUpDown.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.endSampleNumericUpDown.Name = "endSampleNumericUpDown";
            // 
            // startSamplesHintLabel
            // 
            resources.ApplyResources(this.startSamplesHintLabel, "startSamplesHintLabel");
            this.startSamplesHintLabel.Name = "startSamplesHintLabel";
            // 
            // endSamplesHintLabel
            // 
            resources.ApplyResources(this.endSamplesHintLabel, "endSamplesHintLabel");
            this.endSamplesHintLabel.Name = "endSamplesHintLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // resetButton
            // 
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfigureLoopForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.endSampleNumericUpDown);
            this.Controls.Add(this.startSampleNumericUpDown);
            this.Controls.Add(this.loopEnabledCheckBox);
            this.Controls.Add(this.endSamplesHintLabel);
            this.Controls.Add(this.startSamplesHintLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureLoopForm";
            this.Load += new System.EventHandler(this.LoopModifyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startSampleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endSampleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox loopEnabledCheckBox;
        private System.Windows.Forms.NumericUpDown startSampleNumericUpDown;
        private System.Windows.Forms.NumericUpDown endSampleNumericUpDown;
        private System.Windows.Forms.Label startSamplesHintLabel;
        private System.Windows.Forms.Label endSamplesHintLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button cancelButton;
    }
}