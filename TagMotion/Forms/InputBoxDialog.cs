using System;
using System.Text;
using System.Windows.Forms;

namespace Chrismo.TagMotion.Forms
{
    public partial class InputBoxDialog : Form
    {
        public InputBoxDialog()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
