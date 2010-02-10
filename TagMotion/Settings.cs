using System;
using System.Collections.Generic;
using System.Configuration;

namespace Chrismo.TagMotion
{
    public struct Settings
    {
        public const string RECORDARTIST = "%RECORDARTIST";
        public const string RECORDTITLE = "%RECORDTITLE";
        public const string ARTIST = "%ARTIST";
        public const string TITLE = "%TITLE";
        public const string YEAR = "%YEAR";
        public const string TRACK = "%TRACK";
        public const string LABEL = "%LABEL";
        public const string COMMENT = "%COMMENT";
        public const string GENRE = "%GENRE";
        public const string BITRATE = "%BITRATE";
        public const string DIR = "%DIR";
        
        public const string SONGTYPES = "*.mp3|*.ogg|*.flac|*.m4a|*.wma|*.aac|*.aiff";
        public const string PICTYPES = "*.jpg|*.jpeg|*.gif|*.png";
        
        public static List<string> SourceDirs = new List<string>();
        public static List<string> DestinationDirs = new List<string>();
        public static List<string> FileStructures = new List<string>();

        public static int SelectedSourceDir = 0;
        public static int SelectedDestinationDir = 0;
        public static int SelectedFileStructure = 0;

        public static string SourceDir { get { return SourceDirs[SelectedSourceDir]; } }
        public static string DestinationDir { get { return DestinationDirs[SelectedDestinationDir]; } }
        public static string FileStructure { get { return FileStructures[SelectedFileStructure]; } }
        
        public static bool PicturesToTag = false;
        public static bool CreateDummyFile = false;
        public static string SortType = "Path";
        public static bool FreeDBChecking = false;

        public static string InfoTypes = "*.log|*.cue|*.nfo|*.txt";


		public static void Save()
		{
            Properties.Settings.Default.SourceDirs = String.Join("?", SourceDirs.ToArray());
            Properties.Settings.Default.DestinationDirs = String.Join("?", DestinationDirs.ToArray());
            Properties.Settings.Default.FileStructures = String.Join("?", FileStructures.ToArray());
            Properties.Settings.Default.SelectedSourceDir = SelectedSourceDir;
            Properties.Settings.Default.SelectedDestinationDir = SelectedDestinationDir;
            Properties.Settings.Default.SelectedFileStructure = SelectedFileStructure;
            Properties.Settings.Default.InfoTypes = InfoTypes;
            Properties.Settings.Default.SortType = SortType;
            Properties.Settings.Default.FreeDBChecking = FreeDBChecking;

            Properties.Settings.Default.Save();
		}

        public static void Load()
        {
            SourceDirs.AddRange(Properties.Settings.Default.SourceDirs.Split(new char[] { '?' }));

            if (SourceDirs[0] == "")
            {
                SourceDirs.Clear();
                SourceDirs.Add(System.Windows.Forms.Application.StartupPath);
                SelectedSourceDir = 0;
            }
            else
            {
                try { SelectedSourceDir = Properties.Settings.Default.SelectedSourceDir; }
                catch (Exception) { }
            }

            DestinationDirs.AddRange(Properties.Settings.Default.DestinationDirs.Split(new char[] { '?' }));

            if (DestinationDirs[0] == "")
            {
                DestinationDirs.Clear();
                DestinationDirs.Add(System.Windows.Forms.Application.StartupPath);
                SelectedDestinationDir = 0;
            }
            else
            {
                try { SelectedDestinationDir = Properties.Settings.Default.SelectedDestinationDir; }
                catch (Exception) { }
            }

            FileStructures.AddRange(Properties.Settings.Default.FileStructures.Split(new char[] { '?' }));

            if (FileStructures[0] == "")
            {
                FileStructures.Clear();
                FileStructures.AddRange(new string[] { @"%RECORDARTIST\[%YEAR] %RECORDARTIST - %RECORDTITLE\%TRACK - %ARTIST - %TITLE", @"[%LABEL]\[%COMMENT] %RECORDARTIST - %RECORDTITLE (%BITRATE)\%TRACK - %ARTIST - %TITLE" });
            }
            else
            {
                try { SelectedFileStructure = Properties.Settings.Default.SelectedFileStructure; }
                catch (Exception) { }
            }
            
            try { InfoTypes = Properties.Settings.Default.InfoTypes; }
			catch (Exception) { }

            try { SortType = Properties.Settings.Default.SortType; }
			catch (Exception) { }

            try { FreeDBChecking = Properties.Settings.Default.FreeDBChecking; }
			catch (Exception) { }
        }
    }
}