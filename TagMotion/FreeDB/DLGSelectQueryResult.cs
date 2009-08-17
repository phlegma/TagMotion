#region COPYRIGHT (c) 2004 by Brian Weeres
/* Copyright (c) 2004 by Brian Weeres
 * 
 * Email: bweeres@protegra.com; bweeres@hotmail.com
 * 
 * Permission to use, copy, modify, and distribute this software for any
 * purpose is hereby granted, provided that the above
 * copyright notice and this permission notice appear in all copies.
 *
 * If you modify it then please indicate so. 
 *
 * The software is provided "AS IS" and there are no warranties or implied warranties.
 * In no event shall Brian Weeres and/or Protegra Technology Group be liable for any special, 
 * direct, indirect, or consequential damages or any damages whatsoever resulting for any reason 
 * out of the use or performance of this software
 * 
 */
#endregion
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Freedb;

namespace Freedb
{
	/// <summary>
	/// Summary description for DLGSelectQueryResult.
	/// </summary>
	public class DLGSelectQueryResult : System.Windows.Forms.Form
    {
        public Label label_Header;
		private System.Windows.Forms.ListBox LBQueryResults;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private QueryResult _SelectedQueryResult  = null;
        public Button BTNOkay;
        public Button BTNCancel;
		private QueryResultCollection _Results;
		
		/// <summary>
		/// Property SelectedQueryResult (QueryResult)
		/// </summary>
		public QueryResult SelectedQueryResult
		{
			get { return _SelectedQueryResult; }
			set { _SelectedQueryResult = value; }
		}

		public DLGSelectQueryResult(QueryResultCollection results)
		{
			_Results = results;

			InitializeComponent();

            for (int i = 0; i < _Results.Count; i++)
                this.LBQueryResults.Items.Add(String.Format("{0} - {1} [{2}] ({3})",
                    _Results[i].Artist, _Results[i].Title, _Results[i].Genre.ToUpper(), _Results[i].Discid));
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.LBQueryResults = new System.Windows.Forms.ListBox();
            this.label_Header = new System.Windows.Forms.Label();
            this.BTNOkay = new System.Windows.Forms.Button();
            this.BTNCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBQueryResults
            // 
            this.LBQueryResults.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBQueryResults.ItemHeight = 14;
            this.LBQueryResults.Location = new System.Drawing.Point(12, 80);
            this.LBQueryResults.Name = "LBQueryResults";
            this.LBQueryResults.Size = new System.Drawing.Size(541, 144);
            this.LBQueryResults.TabIndex = 0;
            // 
            // label_Header
            // 
            this.label_Header.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Header.Location = new System.Drawing.Point(12, 9);
            this.label_Header.Name = "label_Header";
            this.label_Header.Size = new System.Drawing.Size(541, 57);
            this.label_Header.TabIndex = 1;
            this.label_Header.Text = "Please select an Entry for the Directory:";
            this.label_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTNOkay
            // 
            this.BTNOkay.BackColor = System.Drawing.Color.Ivory;
            this.BTNOkay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTNOkay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNOkay.Location = new System.Drawing.Point(382, 236);
            this.BTNOkay.Name = "BTNOkay";
            this.BTNOkay.Size = new System.Drawing.Size(100, 30);
            this.BTNOkay.TabIndex = 81;
            this.BTNOkay.Text = "OK";
            this.BTNOkay.UseVisualStyleBackColor = false;
            this.BTNOkay.Click += new System.EventHandler(this.BTNOkay_Click);
            // 
            // BTNCancel
            // 
            this.BTNCancel.BackColor = System.Drawing.Color.Ivory;
            this.BTNCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTNCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCancel.Location = new System.Drawing.Point(85, 236);
            this.BTNCancel.Name = "BTNCancel";
            this.BTNCancel.Size = new System.Drawing.Size(100, 30);
            this.BTNCancel.TabIndex = 82;
            this.BTNCancel.Text = "Cancel";
            this.BTNCancel.UseVisualStyleBackColor = false;
            this.BTNCancel.Click += new System.EventHandler(this.BTNCancel_Click);
            // 
            // DLGSelectQueryResult
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(565, 278);
            this.Controls.Add(this.BTNCancel);
            this.Controls.Add(this.BTNOkay);
            this.Controls.Add(this.label_Header);
            this.Controls.Add(this.LBQueryResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DLGSelectQueryResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FreeDB Selection";
            this.ResumeLayout(false);

		}
		#endregion

		private void BTNOkay_Click(object sender, System.EventArgs e)
		{
			if (this.LBQueryResults.SelectedIndex != -1)
				this._SelectedQueryResult = _Results[LBQueryResults.SelectedIndex];
            else
                this._SelectedQueryResult = _Results[0];

			this.DialogResult = DialogResult.OK;
		}

        private void BTNCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
	}
}
