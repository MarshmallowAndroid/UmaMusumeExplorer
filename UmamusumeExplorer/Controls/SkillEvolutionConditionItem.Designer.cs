namespace UmamusumeExplorer.Controls
{
    partial class SkillEvolutionConditionItem
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
            conditionLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // conditionLabel
            // 
            conditionLabel.AutoSize = true;
            conditionLabel.Location = new System.Drawing.Point(15, 15);
            conditionLabel.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
            conditionLabel.Name = "conditionLabel";
            conditionLabel.Size = new System.Drawing.Size(60, 15);
            conditionLabel.TabIndex = 2;
            conditionLabel.Text = "Condition";
            // 
            // SkillEvolutionConditionSingle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.SystemColors.ControlLight;
            Controls.Add(conditionLabel);
            Name = "SkillEvolutionConditionSingle";
            Size = new System.Drawing.Size(352, 45);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label conditionLabel;
    }
}
