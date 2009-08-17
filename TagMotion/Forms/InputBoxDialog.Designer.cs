namespace Chrismo.TagMotion.Forms
{
    partial class InputBoxDialog
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
            this.TextField = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextField
            // 
            this.TextField.BackColor = System.Drawing.Color.Ivory;
            this.TextField.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextField.ForeColor = System.Drawing.Color.Black;
            this.TextField.Location = new System.Drawing.Point(12, 12);
            this.TextField.Name = "TextField";
            this.TextField.Size = new System.Drawing.Size(718, 21);
            this.TextField.TabIndex = 0;
            this.TextField.Text = "[%LABEL]\\[%RELEASE] %RECORDARTIST - %RECORDTITLE (%BITRATE)\\%TRACK - %ARTIST - %T" +
                "ITLE";
            // 
            // button_OK
            // 
            this.button_OK.BackColor = System.Drawing.Color.Ivory;
            this.button_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_OK.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(374, 81);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 30);
            this.button_OK.TabIndex = 86;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = false;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.Ivory;
            this.button_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Cancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(268, 81);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 30);
            this.button_Cancel.TabIndex = 87;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Ivory;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(110, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(620, 14);
            this.label3.TabIndex = 88;
            this.label3.Text = "%RECORDARTIST, %RECORDTITLE, %ARTIST, %TITLE, %YEAR, %TRACK, %GENRE, %LABEL, %REL" +
                "EASE, %BITRATE, %DIR";
            // 
            // InputBoxDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(742, 123);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.TextField);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputBoxDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Structure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button_OK;
        public System.Windows.Forms.Button button_Cancel;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TextField;
    }
}