using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chrismo.TagMotion.Forms
{
	public partial class FilterDialog : Form
    {
        public int BitrateMin;
        public int BitrateMax;

        public int YearMin;
        public int YearMax;

        public int DurationMin;
        public int DurationMax;

        private bool _LeaveAllowed = true;


        public FilterDialog()
		{
			InitializeComponent();

            BitrateMin = Convert.ToInt32(this.textBox_BitrateMin.Text);
            BitrateMax = Convert.ToInt32(this.textBox_BitrateMax.Text);

            YearMin = Convert.ToInt32(this.textBox_YearMin.Text);
            YearMax = Convert.ToInt32(this.textBox_YearMax.Text);

            DurationMin = Convert.ToInt32(this.textBox_YearMin.Text);
            DurationMax = Convert.ToInt32(this.textBox_YearMax.Text);
		}

		void Button_OKClick(object sender, EventArgs e)
		{
            if(_LeaveAllowed)
                DialogResult = DialogResult.OK;
		}


        private void textBox_BitrateMin_Leave(object sender, EventArgs e)
        {
            _LeaveAllowed = false;

            if (Int32.TryParse(this.textBox_BitrateMin.Text, out BitrateMin) == false)
            {
                this.textBox_BitrateMin.Focus();
                this.textBox_BitrateMin.SelectAll();
            }
            else
                _LeaveAllowed = true;
        }

        private void textBox_BitrateMax_Leave(object sender, EventArgs e)
        {
            _LeaveAllowed = false;

            if (Int32.TryParse(this.textBox_BitrateMax.Text, out BitrateMax) == false)
            {
                this.textBox_BitrateMax.Focus();
                this.textBox_BitrateMax.SelectAll();
            }
            else
                _LeaveAllowed = true;
        }

        private void textBox_YearMin_Leave(object sender, EventArgs e)
        {
            _LeaveAllowed = false;

            if (Int32.TryParse(this.textBox_YearMin.Text, out YearMin) == false)
            {
                this.textBox_YearMin.Focus();
                this.textBox_YearMin.SelectAll();
            }
            else
                _LeaveAllowed = true;
        }

        private void textBox_YearMax_Leave(object sender, EventArgs e)
        {
            _LeaveAllowed = false;

            if (Int32.TryParse(this.textBox_YearMax.Text, out YearMax) == false)
            {
                this.textBox_YearMax.Focus();
                this.textBox_YearMax.SelectAll();
            }
            else
                _LeaveAllowed = true;
        }

        private void textBox_DurationMin_Leave(object sender, EventArgs e)
        {
            _LeaveAllowed = false;

            if (Int32.TryParse(this.textBox_DurationMin.Text, out DurationMin) == false)
            {
                this.textBox_DurationMin.Focus();
                this.textBox_DurationMin.SelectAll();
            }
            else
                _LeaveAllowed = true;
        }

        private void textBox_DurationMax_Leave(object sender, EventArgs e)
        {
            _LeaveAllowed = false;

            if (Int32.TryParse(this.textBox_DurationMax.Text, out DurationMax) == false)
            {
                this.textBox_DurationMax.Focus();
                this.textBox_DurationMax.SelectAll();
            }
            else
                _LeaveAllowed = true;
        }
	}
}
