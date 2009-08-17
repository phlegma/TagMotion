using System;
using System.Windows.Forms;

namespace Chrismo.TagMotion.Forms
{
    public partial class HelpBox : Form
    {
        public HelpBox()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
