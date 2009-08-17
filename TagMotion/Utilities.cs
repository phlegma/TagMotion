using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Chrismo.TagMotion
{
    public class Timer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long startTime, stopTime, freq;

        public Timer()
        {
        }

        public void Start() 
        { 
            QueryPerformanceCounter(out startTime); 
        }

        public double Stop()
        {
            QueryPerformanceCounter(out stopTime);

            if (QueryPerformanceFrequency(out freq) == false)
                return 0;

            return (double)(stopTime - startTime) / (double)freq;
        }
    }

	public class Utilities
	{
        public delegate void UpdateStatusDelegate(int pValue, int pMax, string pInfoText);

        public static UpdateStatusDelegate StatusDelegate;

        public static void UpdateStatus(int pValue, int pMax, string pInfo)
        {
            StatusDelegate(pValue, pMax, pInfo);
        }


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);
        
        public static string GetConfigParameter(string pFilePath, string pSection, string pParameter)
        {
            System.Text.StringBuilder tStringBuilder = new System.Text.StringBuilder(4096);

            int i = GetPrivateProfileString(pSection, pParameter, "", tStringBuilder, 4096, pFilePath);

            return tStringBuilder.ToString();
        }

        public static void SetConfigParameter(string pFilePath, string pSection, string pParameter, string pValue)
        {
            WritePrivateProfileString(pSection, pParameter, pValue, pFilePath);
        }



        public static List<string> GetFiles(string pDir, string pSearchPattern)
        {
            string[] pSearchPatterns = pSearchPattern.Split('|');

            List<string> tFiles = new List<string>();

            foreach (string tPattern in pSearchPatterns)
                tFiles.AddRange(Directory.GetFiles(pDir, tPattern, SearchOption.TopDirectoryOnly));

            tFiles.Sort();

            return tFiles;
        }
                
		public static string TimeStamp()
		{
			return "[" + System.DateTime.Now.Year.ToString("0000") + "/" + System.DateTime.Now.Month.ToString("00") + "/" +
				System.DateTime.Now.Day.ToString("00") + " - " + System.DateTime.Now.Hour.ToString("00") + ":" +
				System.DateTime.Now.Minute.ToString("00") +	":" + System.DateTime.Now.Second.ToString("00") + "," +
				System.DateTime.Now.Millisecond.ToString("000") + "]";
		}

		public static string GetSizeAsString(long pBytes)
		{
			string sBytes = "";
			
			if (pBytes >= 1073741824)
			{
				Decimal size = Decimal.Divide(pBytes, 1073741824);
				sBytes = String.Format("{0:##.##} GB", size);
			}
			else if (pBytes >= 1048576)
			{        Decimal size = Decimal.Divide(pBytes, 1048576);
				sBytes = String.Format("{0:##.##} MB", size);
			}
			else if (pBytes >= 1024)
			{        Decimal size = Decimal.Divide(pBytes, 1024);
				sBytes = String.Format("{0:##.##} KB", size);
			}
			else if (pBytes > 0 & pBytes < 1024)
			{        Decimal size = pBytes;
				sBytes = String.Format("{0:##.##} Bytes", size);
			}
			else
				sBytes = "0 Bytes";
			
			return sBytes;
		}
				
		
		public static string GetDurationAsString(TimeSpan pDuration)
		{
			string sDuration = "";
			
			if (pDuration.Days > 0)
			{
				sDuration = pDuration.Days.ToString() + " days, ";
				sDuration += pDuration.Hours.ToString("00") + ":";
			}
			else
			{
				if(pDuration.Hours > 0)
					sDuration += pDuration.Hours.ToString("00") + ":";
			}
			
			sDuration += pDuration.Minutes.ToString("00") + ":";
			sDuration += pDuration.Seconds.ToString("00");
			
			return sDuration;
		}
				
		public static string CleanTagString(string pStringToClean)
		{
			if(pStringToClean == null)
				return "";
			
			char[] tInvalidChars = new char[] { '"', '*', '|', '<', '>', '/', '\\', '#', '$', '%' };

            pStringToClean = pStringToClean.Replace("[", "(");
            pStringToClean = pStringToClean.Replace("]", ")");
            pStringToClean = pStringToClean.Replace("/", "-");
			pStringToClean = pStringToClean.Replace("\\", "-");
			
			while (pStringToClean.IndexOfAny(tInvalidChars) != -1)
				pStringToClean = pStringToClean.Remove(pStringToClean.IndexOfAny(tInvalidChars), 1);

			return pStringToClean.Trim();
		}


		public static string CleanFileString(string pStringToClean)
		{
			if (pStringToClean == null)
				return "";

			char[] tInvalidChars = new char[] { '"', '*', '|', '<', '>', '/', ':', '?' };

            pStringToClean = pStringToClean.Replace("?", "¿");
            
            while (pStringToClean.IndexOfAny(tInvalidChars) != -1)
				pStringToClean = pStringToClean.Remove(pStringToClean.IndexOfAny(tInvalidChars), 1);

			return pStringToClean.Trim();
		}
	}
}