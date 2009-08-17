namespace Chrismo.TagMotion.Forms
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.button_OK = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox_Text = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.BackColor = System.Drawing.Color.Ivory;
            this.button_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(260, 278);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 30);
            this.button_OK.TabIndex = 87;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 138);
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // listBox_Text
            // 
            this.listBox_Text.BackColor = System.Drawing.Color.Ivory;
            this.listBox_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Text.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Text.ForeColor = System.Drawing.Color.Black;
            this.listBox_Text.FormattingEnabled = true;
            this.listBox_Text.ItemHeight = 15;
            this.listBox_Text.Items.AddRange(new object[] {
            "TagMotion is written by chrismo in 2008/2009.",
            "",
            "The library TagLib is used to implement Tag-Reading and Tag-Writing.",
            "TagLib is written by Scott Wheeler.",
            "(http://developer.kde.org/~wheeler/taglib.htm)",
            "",
            "TagMotion is licensed under the GNU license.",
            "",
            "",
            "THX to Global Noises..."});
            this.listBox_Text.Location = new System.Drawing.Point(12, 12);
            this.listBox_Text.Name = "listBox_Text";
            this.listBox_Text.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox_Text.Size = new System.Drawing.Size(442, 165);
            this.listBox_Text.TabIndex = 89;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(544, 320);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox_Text);
            this.Controls.Add(this.button_OK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox_Text;
    }
}