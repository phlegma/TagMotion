using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chrismo.TagMotion.Forms
{
	public partial class SettingsDialog : Form
	{
        private bool _LeaveAllowed = true;
        
        
        public SettingsDialog()
		{
			InitializeComponent();
		}
		
		void Button_OKClick(object sender, EventArgs e)
		{
            if (_LeaveAllowed)
                DialogResult = DialogResult.OK;
		}
		
		void Button_AddSourceDir_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog SelectDirDLG = new FolderBrowserDialog();

			SelectDirDLG.ShowNewFolderButton = true;
			SelectDirDLG.Description = "Please select a Source Directory";

            if (SelectDirDLG.ShowDialog(this) != DialogResult.OK)
                return;

            this.ComboBox_SourceDir.Items.Add(SelectDirDLG.SelectedPath);
            this.ComboBox_SourceDir.SelectedItem = this.ComboBox_SourceDir.Items[this.ComboBox_SourceDir.Items.Count - 1];
        }
		
		void Button_AddDestinationDir_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog SelectDirDLG = new FolderBrowserDialog();

			SelectDirDLG.ShowNewFolderButton = true;
			SelectDirDLG.Description = "Please select a Destination Directory";

            if (SelectDirDLG.ShowDialog(this) != DialogResult.OK)
                return;

			this.ComboBox_DestinationDir.Items.Add(SelectDirDLG.SelectedPath);
            this.ComboBox_DestinationDir.SelectedItem = this.ComboBox_DestinationDir.Items[this.ComboBox_DestinationDir.Items.Count - 1];
		}

        private void Button_AddFileStructure_Click(object sender, EventArgs e)
        {
            Forms.InputBoxDialog tInputBox = new Forms.InputBoxDialog();

            if (tInputBox.ShowDialog(this) != DialogResult.OK || tInputBox.TextField.Text == "")
                return;

            this.ComboBox_FileStructure.Items.Add(tInputBox.TextField.Text);
            this.ComboBox_FileStructure.SelectedItem = this.ComboBox_FileStructure.Items[this.ComboBox_FileStructure.Items.Count - 1];
        }

        private void Button_DeleteSourceDir_Click(object sender, EventArgs e)
        {
            if (this.ComboBox_SourceDir.Items.Count == 1)
                return;

            this.ComboBox_SourceDir.Items.Remove(this.ComboBox_SourceDir.SelectedItem);

            if (this.ComboBox_SourceDir.Items.Count > 0)
                this.ComboBox_SourceDir.SelectedItem = this.ComboBox_SourceDir.Items[this.ComboBox_SourceDir.Items.Count - 1];
        }

        private void Button_DeleteDestinationDir_Click(object sender, EventArgs e)
        {
            if (this.ComboBox_DestinationDir.Items.Count == 1)
                return;

            this.ComboBox_DestinationDir.Items.Remove(this.ComboBox_DestinationDir.SelectedItem);

            if (this.ComboBox_DestinationDir.Items.Count > 0)
                this.ComboBox_DestinationDir.SelectedItem = this.ComboBox_DestinationDir.Items[this.ComboBox_DestinationDir.Items.Count - 1];
        }

        private void Button_DeleteFileStructure_Click(object sender, EventArgs e)
        {
            if (this.ComboBox_FileStructure.Items.Count == 1)
                return;

            this.ComboBox_FileStructure.Items.Remove(this.ComboBox_FileStructure.SelectedItem);

            if (this.ComboBox_FileStructure.Items.Count > 0)
                this.ComboBox_FileStructure.SelectedItem = this.ComboBox_FileStructure.Items[this.ComboBox_FileStructure.Items.Count - 1];
        }

        private void TextBox_InfoFileTypes_Leave(object sender, EventArgs e)
        {
            if (this.TextBox_InfoFileTypes.Text == "")
            {
                _LeaveAllowed = true;
                return;
            }

            _LeaveAllowed = false;

            bool tValidInfoTypes = true;

            string[] tExtensions = this.TextBox_InfoFileTypes.Text.Split(new char[] { '|' } );

            foreach (string tExtension in tExtensions)
                tValidInfoTypes &= tExtension.StartsWith("*.") && tExtension.Length > 2 && tExtension.LastIndexOf("*") == 0;
            
            if (tValidInfoTypes == false)
            {
                this.TextBox_InfoFileTypes.Focus();
                this.TextBox_InfoFileTypes.SelectAll();

                this.toolTip.Show("Structure: *.cue|*.nfo|*.txt", this.TextBox_InfoFileTypes, 10000);
            }
            else
                _LeaveAllowed = true;
        }
	}
}
