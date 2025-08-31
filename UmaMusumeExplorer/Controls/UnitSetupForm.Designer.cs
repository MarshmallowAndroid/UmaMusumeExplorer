namespace UmaMusumeExplorer.Controls
{
    partial class UnitSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitSetupForm));
            singersPanel = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            confirmButton = new System.Windows.Forms.Button();
            sfxCheckBox = new System.Windows.Forms.CheckBox();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // singersPanel
            // 
            resources.ApplyResources(singersPanel, "singersPanel");
            singersPanel.Name = "singersPanel";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(tableLayoutPanel, "tableLayoutPanel");
            tableLayoutPanel.Controls.Add(singersPanel, 0, 0);
            tableLayoutPanel.Controls.Add(confirmButton, 0, 1);
            tableLayoutPanel.Controls.Add(sfxCheckBox, 0, 2);
            tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // confirmButton
            // 
            resources.ApplyResources(confirmButton, "confirmButton");
            confirmButton.Name = "confirmButton";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += ConfirmButton_Click;
            // 
            // sfxCheckBox
            // 
            resources.ApplyResources(sfxCheckBox, "sfxCheckBox");
            sfxCheckBox.Checked = true;
            sfxCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            sfxCheckBox.Name = "sfxCheckBox";
            sfxCheckBox.UseVisualStyleBackColor = true;
            // 
            // UnitSetupForm
            // 
            AcceptButton = confirmButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            MaximizeBox = false;
            Name = "UnitSetupForm";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel singersPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.CheckBox sfxCheckBox;
    }
}