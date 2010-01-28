using System;
using System.Collections.Generic;

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
        
        public const string SONGTYPES = "*.mp3|*.ogg|*.flac|*.m4a|*.wma";
        public const string PICTYPES = "*.jpg|*.jpeg|*.gif|*.png";
        
        public const string ConfigPath = @"TagMotion.config";
        public const string ConfigSection = "AppSettings";
        
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

        public static string InfoTypes = "*.cue|*.nfo|*.txt";

        
        public static void Save()
        {
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "SourceDirs", String.Join("?", SourceDirs.ToArray()));
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "SelectedSourceDir", SelectedSourceDir.ToString());
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "DestinationDirs", String.Join("?", DestinationDirs.ToArray()));
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "SelectedDestinationDir", SelectedDestinationDir.ToString());
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "FileStructures", String.Join("?", FileStructures.ToArray()));
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "SelectedFileStructure", SelectedFileStructure.ToString());
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "InfoTypes", InfoTypes);
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "SortType", SortType);
            Utilities.SetConfigParameter(ConfigPath, ConfigSection, "FreeDBChecking", FreeDBChecking.ToString());
        }

        public static void Load()
        {
            SourceDirs.AddRange(@Utilities.GetConfigParameter(ConfigPath, ConfigSection, "SourceDirs").Split(new char[] { '?' }));

            if (SourceDirs[0] == "")
            {
                SourceDirs.Clear();
                SourceDirs.Add("C:");
            }

            DestinationDirs.AddRange(@Utilities.GetConfigParameter(ConfigPath, ConfigSection, "DestinationDirs").Split(new char[] { '?' }));

            if (DestinationDirs[0] == "")
            {
                DestinationDirs.Clear();
                DestinationDirs.Add("C:");
            }

            FileStructures.AddRange(@Utilities.GetConfigParameter(ConfigPath, ConfigSection, "FileStructures").Split(new char[] { '?' }));

            if (FileStructures[0] == "")
            {
                FileStructures.Clear();
                FileStructures.AddRange(new string[] { @"%RECORDARTIST\[%YEAR] %RECORDARTIST - %RECORDTITLE\%TRACK - %ARTIST - %TITLE", @"[%LABEL]\[%COMMENT] %RECORDARTIST - %RECORDTITLE (%BITRATE)\%TRACK - %ARTIST - %TITLE" });
            }

            try { SelectedSourceDir = Convert.ToInt32(Utilities.GetConfigParameter(ConfigPath, ConfigSection, "SelectedSourceDir")); }
            catch(Exception) { }

            try { SelectedDestinationDir = Convert.ToInt32(Utilities.GetConfigParameter(ConfigPath, ConfigSection, "SelectedDestinationDir")); }  
            catch(Exception) { }

            try { SelectedFileStructure = Convert.ToInt32(Utilities.GetConfigParameter(ConfigPath, ConfigSection, "SelectedFileStructure")); } 
            catch(Exception) { }

            try { InfoTypes = @Utilities.GetConfigParameter(ConfigPath, ConfigSection, "InfoTypes"); }
            catch (Exception) { }

            try { SortType = @Utilities.GetConfigParameter(ConfigPath, ConfigSection, "SortType"); }
            catch (Exception) { }

            try { FreeDBChecking = Convert.ToBoolean(@Utilities.GetConfigParameter(ConfigPath, ConfigSection, "FreeDBChecking")); }
            catch (Exception) { }
        }
    }
}