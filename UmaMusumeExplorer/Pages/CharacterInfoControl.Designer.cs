
namespace UmaMusumeExplorer.Pages
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
            selectLabel = new Label();
            goButton = new Button();
            charaListComboBox = new ComboBox();
            markPlayableCheckBox = new CheckBox();
            characterItemsPanel = new Controls.CharacterItemsPanel();
            SuspendLayout();
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
            charaListComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            charaListComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            charaListComboBox.FormattingEnabled = true;
            resources.ApplyResources(charaListComboBox, "charaListComboBox");
            charaListComboBox.Name = "charaListComboBox";
            // 
            // markPlayableCheckBox
            // 
            resources.ApplyResources(markPlayableCheckBox, "markPlayableCheckBox");
            markPlayableCheckBox.Name = "markPlayableCheckBox";
            markPlayableCheckBox.UseVisualStyleBackColor = true;
            markPlayableCheckBox.CheckedChanged += ShowPlayableCheckBox_CheckedChanged;
            // 
            // characterItemsPanel
            // 
            resources.ApplyResources(characterItemsPanel, "characterItemsPanel");
            characterItemsPanel.Items = null;
            characterItemsPanel.Name = "characterItemsPanel";
            // 
            // CharacterInfoControl
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(characterItemsPanel);
            Controls.Add(markPlayableCheckBox);
            Controls.Add(charaListComboBox);
            Controls.Add(goButton);
            Controls.Add(selectLabel);
            Name = "CharacterInfoControl";
            resources.ApplyResources(this, "$this");
            Load += CharacterInfoControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label selectLabel;
        private Button goButton;
        private ComboBox charaListComboBox;
        private CheckBox markPlayableCheckBox;
        private Controls.CharacterItemsPanel characterItemsPanel;
    }
}
