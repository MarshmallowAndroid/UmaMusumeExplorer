namespace UmaMusumeExplorer.Controls.AudioPlayer
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
            this.loopEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.startSampleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endSampleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startSamplesHintLabel = new System.Windows.Forms.Label();
            this.endSamplesHintLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startSampleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endSampleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // loopEnabledCheckBox
            // 
            this.loopEnabledCheckBox.AutoSize = true;
            this.loopEnabledCheckBox.Location = new System.Drawing.Point(12, 12);
            this.loopEnabledCheckBox.Name = "loopEnabledCheckBox";
            this.loopEnabledCheckBox.Size = new System.Drawing.Size(98, 19);
            this.loopEnabledCheckBox.TabIndex = 1;
            this.loopEnabledCheckBox.Text = "Loop enabled";
            this.loopEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // startSampleNumericUpDown
            // 
            this.startSampleNumericUpDown.Location = new System.Drawing.Point(90, 37);
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
            this.startSampleNumericUpDown.Size = new System.Drawing.Size(153, 23);
            this.startSampleNumericUpDown.TabIndex = 2;
            // 
            // endSampleNumericUpDown
            // 
            this.endSampleNumericUpDown.Location = new System.Drawing.Point(90, 66);
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
            this.endSampleNumericUpDown.Size = new System.Drawing.Size(153, 23);
            this.endSampleNumericUpDown.TabIndex = 2;
            // 
            // startSamplesHintLabel
            // 
            this.startSamplesHintLabel.AutoSize = true;
            this.startSamplesHintLabel.Location = new System.Drawing.Point(12, 39);
            this.startSamplesHintLabel.Name = "startSamplesHintLabel";
            this.startSamplesHintLabel.Size = new System.Drawing.Size(72, 15);
            this.startSamplesHintLabel.TabIndex = 0;
            this.startSamplesHintLabel.Text = "Start sample";
            // 
            // endSamplesHintLabel
            // 
            this.endSamplesHintLabel.AutoSize = true;
            this.endSamplesHintLabel.Location = new System.Drawing.Point(12, 68);
            this.endSamplesHintLabel.Name = "endSamplesHintLabel";
            this.endSamplesHintLabel.Size = new System.Drawing.Size(68, 15);
            this.endSamplesHintLabel.TabIndex = 0;
            this.endSamplesHintLabel.Text = "End sample";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(266, 119);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(347, 119);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ConfigureLoopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 154);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.endSampleNumericUpDown);
            this.Controls.Add(this.startSampleNumericUpDown);
            this.Controls.Add(this.loopEnabledCheckBox);
            this.Controls.Add(this.endSamplesHintLabel);
            this.Controls.Add(this.startSamplesHintLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureLoopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Configure Loop";
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
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button resetButton;
    }
}