using System;
using System.Windows.Forms;

namespace Chrismo.TagMotion
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            Form tForm = new Forms.MainForm();

            try
            {
                Application.Run(tForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tForm.Dispose();
            }
		}		
	}
}
