namespace UmaMusumeExplorer.Controls.CharacterInfo
{
    partial class SkillEvolutionConditionContainer
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
            conditionNumberLabel = new System.Windows.Forms.Label();
            conditionDescription = new System.Windows.Forms.Label();
            conditionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // conditionNumberLabel
            // 
            conditionNumberLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            conditionNumberLabel.Location = new System.Drawing.Point(15, 15);
            conditionNumberLabel.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
            conditionNumberLabel.Name = "conditionNumberLabel";
            conditionNumberLabel.Size = new System.Drawing.Size(99, 15);
            conditionNumberLabel.TabIndex = 0;
            conditionNumberLabel.Text = "Condition 0";
            conditionNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conditionDescription
            // 
            conditionDescription.AutoSize = true;
            conditionDescription.Location = new System.Drawing.Point(144, 15);
            conditionDescription.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
            conditionDescription.Name = "conditionDescription";
            conditionDescription.Size = new System.Drawing.Size(210, 15);
            conditionDescription.TabIndex = 0;
            conditionDescription.Text = "Satisfy one of the following conditions";
            // 
            // conditionsPanel
            // 
            conditionsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            conditionsPanel.Location = new System.Drawing.Point(15, 45);
            conditionsPanel.Margin = new System.Windows.Forms.Padding(15);
            conditionsPanel.Name = "conditionsPanel";
            conditionsPanel.Size = new System.Drawing.Size(451, 50);
            conditionsPanel.TabIndex = 1;
            // 
            // SkillEvolutionConditionContainer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            Controls.Add(conditionsPanel);
            Controls.Add(conditionDescription);
            Controls.Add(conditionNumberLabel);
            Name = "SkillEvolutionConditionContainer";
            Size = new System.Drawing.Size(481, 110);
            Load += SkillEvolutionConditionMultiple_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label conditionNumberLabel;
        private System.Windows.Forms.Label conditionDescription;
        private System.Windows.Forms.FlowLayoutPanel conditionsPanel;
    }
}
