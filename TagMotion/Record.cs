using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using TagLib;
using Freedb;

namespace Chrismo.TagMotion
{
    public class Record
    {
        private string _Path = "";
        private string _RecordArtist = "";
        private string _RecordTitle = "";
        private int _Year = 0;
        private string _Label = "";
        private string _Release = "";
        private string _Genre = "";
        private int _Bitrate = 0;
        private string _Type = "";
        private List<Song> _Songs = new List<Song>();
        private List<Picture> _Pictures = new List<Picture>();
        private List<Info> _Infos = new List<Info>();
        private int _ProgressValue = 0;
        private int _ProgressMax;
        private bool _IsValid = false;
        private DateTime _CreationTime;
        private bool _Filtered = false;
        private TreeNode _Node = null;
        private string _DiscID = "";
        private string _QueryPostfix = "";

        [CategoryAttribute("Info")]
        public string Type { get { return _Type; } }

        [CategoryAttribute("Info")]
        public int Bitrate { get { return _Bitrate; } }

        [CategoryAttribute("Info")]
        public string Duration { get { return Utilities.GetDurationAsString(GetDirDuration()); } }

        [CategoryAttribute("Info")]
        public string Size { get { return Utilities.GetSizeAsString(GetDirSize()); } }

        [CategoryAttribute("Info")]
        public string DiscID { get { return _DiscID; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public string Artist { get { return _RecordArtist; } set { _RecordArtist = value; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public string Title { get { return _RecordTitle; } set { _RecordTitle = value; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public string Label { get { return _Label; } set { _Label = value; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public string Release { get { return _Release; } set { _Release = value; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public int Year { get { return _Year; } set { _Year = value; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public string Genre { get { return _Genre; } set { _Genre = value; } }

        [BrowsableAttribute(false)]
        public string Path { get { return _Path; } }

        [BrowsableAttribute(false)]
        public List<Song> Songs { get { return _Songs; } }

        [BrowsableAttribute(false)]
        public List<Picture> Pictures { get { return _Pictures; } }

        [BrowsableAttribute(false)]
        public List<Info> Infos { get { return _Infos; } }

        [BrowsableAttribute(false)]
        public bool HasValidTags { get { return _Songs.All(delegate(Song S) { return S.HasValidTags; }) && ValidateTags(); } }

        [BrowsableAttribute(false)]
        public long SizeAsLong { get { return GetDirSize(); } }

        [BrowsableAttribute(false)]
        public TimeSpan DurationAsTimeSpan { get { return GetDirDuration(); } }

        [BrowsableAttribute(false)]
        public bool IsValid { get { return _IsValid; } }

        [BrowsableAttribute(false)]
        public DateTime CreationTime { get { return _CreationTime; } }

        [BrowsableAttribute(false)]
        public bool Filtered { get { return _Filtered; } set { _Filtered = value; } }
        
        [BrowsableAttribute(false)]
        public TreeNode Node { get { return _Node; } set { _Node = value; } }


        public Record(string pDirPath)
        {
            _Path = pDirPath;

            _Node = new TreeNode(this.Path);
            _Node.Tag = NodeType.Record;

            Font tFont = new Font("Arial", 9, FontStyle.Bold);
            _Node.NodeFont = tFont;

            _IsValid = this.ReadDirectory();
            _DiscID = this.GetDiscID();

            this.UpdateForeColor();
        }


        public void AfterSelect(ref Image pImage, ref PropertyGrid tPropertyGrid)
        {
            if (_Pictures.Count > 0)
                pImage = new Bitmap(_Pictures[0].Path);
            else
                pImage = null;

            tPropertyGrid.SelectedObject = this;
        }

        public void UpdateForeColor()
        {
            if(_Filtered)
                _Node.ForeColor = Color.PaleGoldenrod;
            else
                _Node.ForeColor = (this.HasValidTags ? Color.DarkGreen : Color.DarkRed);
        }

        public void UpdateForeColors()
        {
            foreach (Song tSong in _Songs)
            {
                tSong.Filtered = this.Filtered;
                tSong.UpdateForeColor();
            }

            foreach (Picture tPic in _Pictures)
            {
                tPic.Filtered = this.Filtered;
                tPic.UpdateForeColor();
            }

            foreach (Info tInfo in _Infos)
            {
                tInfo.Filtered = this.Filtered;
                tInfo.UpdateForeColor();
            }

            this.UpdateForeColor();
        }


        public void Copy(bool pUpdateStatus)
        {
            if (_Filtered || !this.HasValidTags)
                return;

            _ProgressMax = _Songs.Count + _Pictures.Count;
            _ProgressValue = 0;

            string tNewFilePath;

            foreach (Song tSong in _Songs)
            {
                tNewFilePath = tSong.Rename();

                if (pUpdateStatus)
                {
                    _ProgressValue++;
                    Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Copying Song :: " + tNewFilePath);
                }

                tSong.Copy(tNewFilePath, true);
            }

            int tCounter = 0;

            foreach (Picture tPic in _Pictures)
            {
                tNewFilePath = tPic.Rename(tCounter);

                if (pUpdateStatus)
                {
                    _ProgressValue++;
                    Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Copying Picture :: " + tNewFilePath);
                }

                tPic.Copy(tNewFilePath, true);
                tCounter++;
            }

            if (tCounter == 1)
                tCounter = 0;

            foreach (Info tInfo in _Infos)
            {
                tNewFilePath = tInfo.Rename(tCounter);

                if (pUpdateStatus)
                {
                    _ProgressValue++;
                    Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Copying Info :: " + tNewFilePath);
                }

                tInfo.Copy(tNewFilePath, true);
                tCounter++;
            }

            if (pUpdateStatus)
                Utilities.UpdateStatus(_ProgressMax, _ProgressMax, _Path + " successfully copied.");
        }

        public void Sort(SortType pSortType)
        {
            Comparer tComparer = new Comparer();

            switch (pSortType)
            {
                case SortType.Year: _Songs.Sort(tComparer.SortByYear); break;
                case SortType.Artist: _Songs.Sort(tComparer.SortByArtist); break;
                case SortType.Release: _Songs.Sort(tComparer.SortByRelease); break;
                case SortType.Path: _Songs.Sort(tComparer.SortByPath); break;
            }
        }

        public bool Delete()
        {
            DialogResult tAnswer = MessageBox.Show("Do you really want to delete " + _Path, "Directory Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (tAnswer != DialogResult.OK)
                return false;

            try
            {
                Directory.Delete(_Path, true);

                _Node.Remove();

                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Please delete the Directory manually.");

                return false;
            }
        }

        public Song GetSong(string pPath)
        {
            return _Songs.First(delegate(Song S) { return S.Path == _Path + "\\" +  pPath; });            
        }
        
        public Picture GetPicture(string pPath)
        {
            return _Pictures.First(delegate(Picture P) { return P.Path == _Path + "\\" + pPath; });
        }
        
        public Info GetInfo(string pPath)
        {
            return _Infos.First(delegate(Info I) { return I.Path == _Path + "\\" + pPath; });
        }


        public void AutoTagFromFileName(string pFileStructure, string pCollectionPath)
        {
            string tFileStructure;

            foreach (Song tSong in _Songs)
            {
                tFileStructure = pFileStructure;

                System.IO.FileInfo tFileInfo = new System.IO.FileInfo(tSong.Path);
                string tFileName = tSong.Path.Substring(pCollectionPath.Length + 1);

                Dictionary<string, string> tList = new Dictionary<string, string>();

                List<string> tExpressions = new List<string>(new string[] { Settings.ARTIST, Settings.TITLE, Settings.TRACK,
                    Settings.YEAR, Settings.RECORDARTIST, Settings.RECORDTITLE, Settings.LABEL, Settings.GENRE, Settings.RELEASE });

                int tPosition = 0;

                while (tFileStructure.Contains('%'))
                {
                    if (tFileStructure[tPosition] == '%')
                    {
                        string tExpression = GetExpression(tFileStructure.Substring(tPosition), tExpressions);
 
                        if (tExpression != "")
                        {
                            string tNextSeperator = "";
                            string tValue;

                            if (tFileStructure.Substring(tPosition + tExpression.Length).IndexOf('%') < 0)
                            {
                                if (tFileStructure.Substring(tExpression.Length).Length > 0)
                                    tValue = tFileName.Substring(tPosition, tFileName.Substring(tPosition).IndexOf(tFileStructure.Substring(tExpression.Length)));
                                else
                                    tValue = tFileName.Substring(tPosition, tFileName.Substring(tPosition).IndexOf(tFileInfo.Extension));
                            }
                            else
                            {
                                tNextSeperator = tFileStructure.Substring(tPosition + tExpression.Length, tFileStructure.Substring(tPosition + tExpression.Length).IndexOf('%'));
                                tValue = tFileName.Substring(tPosition, tFileName.Substring(tPosition).IndexOf(tNextSeperator));
                            }

                            tList.Add(tExpression, tValue);

                            tFileStructure = tFileStructure.Substring(tPosition + tExpression.Length + tNextSeperator.Length);
                            tFileName = tFileName.Substring(tPosition + tValue.Length + tNextSeperator.Length);
                            tPosition = 0;
                        }
                    }
                    else
                    {
                        if (tFileStructure[tPosition] == tFileName[tPosition])
                            tPosition++;
                        else
                            throw new ArgumentException("FileStructure not correct.");
                    }
                }

                foreach (KeyValuePair<string, string> tPair in tList)
                {
                    if (tPair.Key == Settings.TRACK) tSong.Track = Convert.ToInt32(tPair.Value);
                    if (tPair.Key == Settings.ARTIST) tSong.Artist = tPair.Value;
                    if (tPair.Key == Settings.TITLE) tSong.Title = tPair.Value;

                    if (tPair.Key == Settings.LABEL)
                    {
                        tSong.Label = tPair.Value;
                        this.Label = tPair.Value;
                    }

                    if (tPair.Key == Settings.RELEASE)
                    {
                        tSong.Release = tPair.Value;
                        this.Release = tPair.Value;
                    }

                    if (tPair.Key == Settings.RECORDARTIST)
                    {
                        tSong.RecordArtist = tPair.Value;
                        this.Artist = tPair.Value;
                    }

                    if (tPair.Key == Settings.RECORDTITLE)
                    {
                        tSong.RecordTitle = tPair.Value;
                        this.Title = tPair.Value;
                    }

                    if (tPair.Key == Settings.YEAR)
                    {
                        tSong.Year = Convert.ToInt32(tPair.Value);
                        this.Year = Convert.ToInt32(tPair.Value);
                    }

                    if (tPair.Key == Settings.GENRE)
                    {
                        tSong.Genre = tPair.Value;
                        this.Genre = tPair.Value;
                    }
                }

                tSong.SaveTags();
            }
        }
         
        private string GetExpression(string pString, List<string> pExpressions)
        {
            foreach (string tExpression in pExpressions)
                if (pString.StartsWith(tExpression))
                    return tExpression;

            return "";
        }

        public void SaveTags()
        {
            _ProgressMax = _Songs.Count;
            _ProgressValue = 0;

            foreach (Song tSong in _Songs)
            {
                _ProgressValue++;
                Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Saving Tags :: " + tSong.Path);

                tSong.RecordArtist = _RecordArtist;
                tSong.RecordTitle = _RecordTitle;
                tSong.Year = _Year;
                tSong.Label = _Label;
                tSong.Release = _Release;
                tSong.Genre = _Genre;

                tSong.SaveTags();
            }

            _ProgressMax = _Pictures.Count;
            _ProgressValue = 0;

            foreach (Picture tPic in _Pictures)
            {
                _ProgressValue++;
                Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Saving Tags :: " + tPic.Path);

                this.FillPictureProperties(tPic);
            }

            _ProgressMax = _Infos.Count;
            _ProgressValue = 0;

            foreach (Info tInfo in _Infos)
            {
                _ProgressValue++;
                Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Saving Tags :: " + tInfo.Path);

                this.FillInfoProperties(tInfo);
            }

            this.ValidateTags();
            this.UpdateForeColor();

            Utilities.UpdateStatus(_ProgressMax, _ProgressMax, _Path + " successfully saved");
        }


        public void SaveTagPicturesToFile()
        {
            if (_Songs[0].Pictures.Count > 1)
                for (int i = 0; i < _Songs[0].Pictures.Count; i++)
                    _Songs[0].SaveID3PictureToImage(_Songs[0].Pictures[i], _Path + "\\TagPicture " + (i + 1) + ".jpg");
            else
                _Songs[0].SaveID3PictureToImage(_Songs[0].Pictures[0], _Path + "\\TagPicture.jpg");
        }


        public void SavePictureToTag(Picture pPicture)
        {
            IPicture[] tPics = new IPicture[1];

            tPics[0] = Song.ConvertImageToID3Picture(pPicture.Path);

            for (int i = 0; i < _Songs.Count; i++)
            {
                Utilities.UpdateStatus(i, _Songs.Count, "Save Image To Tag :: " + _Songs[i].Path);

                try
                {
                    _Songs[i].SavePicturesToTag(tPics);
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                _Songs[i].Pictures.Add(tPics[0]);
            }
        }

        public void SavePicturesToTag()
        {
            IPicture[] tPics = new IPicture[_Pictures.Count];

            for(int i = 0; i < _Pictures.Count; i++)
                tPics[i] = Song.ConvertImageToID3Picture(_Pictures[i].Path);

            for (int i = 0; i < _Songs.Count; i++)
            {
                Utilities.UpdateStatus(_ProgressMax, _ProgressMax, "Save Image To Tag :: " + _Songs[i].Path);

                _Songs[i].SavePicturesToTag(tPics);
            }
        }

        public bool ReadDirectory()
        {
            if (!Directory.Exists(_Path))
            {
                MessageBox.Show(_Path + " does not exist.", "Read Directory failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _Songs.Clear();
            _Pictures.Clear();
            _Infos.Clear();
            _Node.Nodes.Clear();

            _CreationTime = new DirectoryInfo(_Path).CreationTime;

            List<string> tPaths = Utilities.GetFiles(_Path, Settings.SONGTYPES);

            TreeNode tSongsNode = new TreeNode("Songs: ");
            _Node.Nodes.Add(tSongsNode);

            foreach(string tPath in tPaths)
            {
                Song tSong = new Song(tPath);

                if (tSong.IsValid)
                {
                    tSong.ValidateTags();
                    _Songs.Add(tSong);

                    _Node.Nodes[0].Nodes.Add(tSong.Node);
                    tSong.Node.Text = tSong.Node.Text.Substring(this.Path.Length + 1);
                }
            }

            _Node.Nodes[0].Text += _Songs.Count;
            _Node.Nodes[0].Expand();

            if (_Songs.Count == 0)
                return false;

            _RecordArtist = _Songs.All(delegate(Song S) { return S.RecordArtist == _Songs[0].RecordArtist; }) ? _Songs[0].RecordArtist : "";
            _RecordTitle = _Songs.All(delegate(Song S) { return S.RecordTitle == _Songs[0].RecordTitle; }) ? _Songs[0].RecordTitle : "";
            _Label = _Songs.All(delegate(Song S) { return S.Label == _Songs[0].Label; }) ? _Songs[0].Label : "";
            _Release = _Songs.All(delegate(Song S) { return S.Release == _Songs[0].Release; }) ? _Songs[0].Release : "";
            _Year = _Songs.All(delegate(Song S) { return S.Year == _Songs[0].Year; }) ? _Songs[0].Year : 0;
            _Genre = _Songs.All(delegate(Song S) { return S.Genre == _Songs[0].Genre; }) ? _Songs[0].Genre : "";
            _Type = _Songs.All(delegate(Song S) { return S.Type == _Songs[0].Type; }) ? _Songs[0].Type : "";

            int tBitrate = 0;

            foreach (Song tSong in _Songs)
                tBitrate += tSong.Bitrate;

            _Bitrate = tBitrate / _Songs.Count;

            foreach (Song tSong in _Songs)
                tSong.RecordBitrate = _Bitrate;

            tPaths = Utilities.GetFiles(_Path, Settings.PICTYPES);

            TreeNode tPicsNode = new TreeNode("Pictures: ");
            _Node.Nodes.Add(tPicsNode);

            foreach (string tPath in tPaths)
            {
                Picture tPic = new Picture(tPath);

                this.FillPictureProperties(tPic);

                _Pictures.Add(tPic);

                _Node.Nodes[1].Nodes.Add(tPic.Node);
                tPic.Node.Text = tPic.Node.Text.Substring(this.Path.Length + 1);
            }

            _Node.Nodes[1].Text += _Pictures.Count;
            _Node.Nodes[1].Expand();

            tPaths = Utilities.GetFiles(_Path, Settings.InfoTypes);

            TreeNode tInfosNode = new TreeNode("Infos: ");
            _Node.Nodes.Add(tInfosNode);

            foreach (string tPath in tPaths)
            {
                Info tInfo = new Info(tPath);

                this.FillInfoProperties(tInfo);

                _Infos.Add(tInfo);

                _Node.Nodes[2].Nodes.Add(tInfo.Node);
                tInfo.Node.Text = tInfo.Node.Text.Substring(this.Path.Length + 1);
            }

            _Node.Nodes[2].Text += _Infos.Count;
            _Node.Nodes[2].Expand();

            return true;
        }

        public bool ValidateTags()
        {
            bool tHasValidTags = true;

            if (Settings.FileStructure.Contains(Settings.RECORDARTIST)) tHasValidTags &= _RecordArtist != "";
            if (Settings.FileStructure.Contains(Settings.RECORDTITLE)) tHasValidTags &= _RecordTitle != "";
            if (Settings.FileStructure.Contains(Settings.YEAR)) tHasValidTags &= _Year != 0;
            if (Settings.FileStructure.Contains(Settings.LABEL)) tHasValidTags &= _Label != "";
            if (Settings.FileStructure.Contains(Settings.RELEASE)) tHasValidTags &= _Release != "";
            if (Settings.FileStructure.Contains(Settings.GENRE)) tHasValidTags &= _Genre != "";

            return tHasValidTags;
        }

        public bool QueryFreeDB(bool pShowFailureDialog)
        {
            _DiscID = this.GetDiscID();

            FreedbHelper _FreeDB = new FreedbHelper(); ;

            _FreeDB.UserName = "User";
            _FreeDB.Hostname = "Private";
            _FreeDB.ClientName = "TagMotion";
            _FreeDB.Version = "1.0";
            _FreeDB.SetDefaultSiteAddress("freedb.freedb.org");

            QueryResult tQueryResult;
            QueryResultCollection tQueryResultCollection;

            string tResponse = _FreeDB.Query(_DiscID + "+" + _QueryPostfix, out tQueryResult, out tQueryResultCollection);

            if (tResponse == FreedbHelper.ResponseCodes.CODE_210 || tResponse == FreedbHelper.ResponseCodes.CODE_211)
            {
                DLGSelectQueryResult tDialog = new DLGSelectQueryResult(tQueryResultCollection);

                tDialog.label_Header.Text += Environment.NewLine + Environment.NewLine + new DirectoryInfo(this.Path).Name;

                if (tDialog.ShowDialog() != DialogResult.OK)
                    return false;

                tQueryResult = tDialog.SelectedQueryResult;
            }
            else if (tResponse != FreedbHelper.ResponseCodes.CODE_200)
            {
                if (pShowFailureDialog)
                    MessageBox.Show("Could not retrieve CD Info.");

                return false;
            }

            CDEntry tCDEntry;

            tResponse = _FreeDB.Read(tQueryResult, out tCDEntry);

            if (tResponse != FreedbHelper.ResponseCodes.CODE_210)
                MessageBox.Show("Unable to retrieve cd entry. Code: " + tResponse);

            _RecordArtist = tCDEntry.Artist;
            _RecordTitle = tCDEntry.Title;
            _Year = tCDEntry.Year == "" ? 0 : Convert.ToInt32(tCDEntry.Year);
            _Genre = tCDEntry.Genre;

            for (int i = 0; i < tCDEntry.Tracks.Count; i++)
            {
                _Songs[i].RecordArtist = tCDEntry.Artist;
                _Songs[i].RecordTitle = tCDEntry.Title;
                _Songs[i].Track = i + 1;
                _Songs[i].Artist = tCDEntry.Artist;
                _Songs[i].Title = tCDEntry.Tracks[i].Title;
                _Songs[i].Year = tCDEntry.Year == "" ? 0 : Convert.ToInt32(tCDEntry.Year);
                _Songs[i].Genre = tCDEntry.Genre;

                _Songs[i].SaveTags();
            }

            foreach (Picture tPic in _Pictures)
                this.FillPictureProperties(tPic);

            foreach (Info tInfo in _Infos)
                this.FillInfoProperties(tInfo);

            return true;
        }

        public string GetDiscID()
        {
            double tOffset = 0;
            _QueryPostfix = _Songs.Count.ToString();

            TOC[] CDToc = new TOC[_Songs.Count + 1];

            CDToc[0].Minute = 0;
            CDToc[0].Second = 2;

            TimeSpan tDuration = new TimeSpan(0, 0, 2);

            for (int i = 0; i < _Songs.Count; i++)
            {
                tOffset = (((tDuration.Minutes * 60) + tDuration.Seconds) * 75) + tDuration.Milliseconds / 10;
                _QueryPostfix += "+" + string.Format("{0}", tOffset);

                tDuration += _Songs[i].DurationAsTimeSpan;

                CDToc[i + 1].Minute = tDuration.Hours * 60 + tDuration.Minutes;
                CDToc[i + 1].Second = (int)(tDuration.Seconds + tDuration.Milliseconds / 1000.0);
            }

            int numSecs = CDToc[_Songs.Count].Minute * 60 + CDToc[_Songs.Count].Second;

            _QueryPostfix += "+" + numSecs;
            
            int t = 0, n = 0;

            for (int i = 0; i < _Songs.Count; i++)
                n += (int)CDDBSum((CDToc[i].Minute * 60) + CDToc[i].Second);

            t = (int)((CDToc[_Songs.Count].Minute * 60) + CDToc[_Songs.Count].Second) - ((CDToc[0].Minute * 60) + CDToc[0].Second);

            int Result = (n % 0xff) << 24 | t << 8 | _Songs.Count;

            byte[] tBytes = BitConverter.GetBytes(Result);

            string[] tIDString = BitConverter.ToString(tBytes).Split(new char[] { '-' });

            string tDiscID = "";

            for (int i = 3; i >= 0; i--)
                tDiscID += tIDString[i];

            return tDiscID.ToString();
        }

        private static ulong CDDBSum(int n)
        {
            ulong tReturn = 0;

            while (n > 0)
            {
                tReturn = tReturn + (ulong)(n % 10);
                n /= 10;
            }

            return tReturn;
        }

        private struct TOC
        {
            public int Minute;
            public int Second;
        }

        private void FillPictureProperties(Picture tPicture)
        {
            tPicture.RecordArtist = _RecordArtist;
            tPicture.RecordTitle = _RecordTitle;
            tPicture.Year = _Year;
            tPicture.Label = _Label;
            tPicture.Release = _Release;
            tPicture.RecordBitrate = _Bitrate;
            tPicture.Genre = _Genre;
        }

        private void FillInfoProperties(Info tInfo)
        {
            tInfo.RecordArtist = _RecordArtist;
            tInfo.RecordTitle = _RecordTitle;
            tInfo.Year = _Year;
            tInfo.Label = _Label;
            tInfo.Release = _Release;
            tInfo.RecordBitrate = _Bitrate;
            tInfo.Genre = _Genre;
        }

        private TimeSpan GetDirDuration()
        {
            TimeSpan tDirDuration = TimeSpan.Zero;

            foreach (Song tSong in _Songs)
                tDirDuration += tSong.DurationAsTimeSpan;

            return tDirDuration;
        }

        private long GetDirSize()
        {
            long tDirSize = 0;

            foreach (Song tSong in _Songs)
                tDirSize += tSong.SizeAsLong;

            foreach (Picture tPic in _Pictures)
                tDirSize += tPic.SizeAsLong;

            foreach (Info tInfo in _Infos)
                tDirSize += tInfo.SizeAsLong;

            return tDirSize;
        }

        
        public class Comparer : IComparer<Song>
        {
            public int Compare(Song Song1, Song Song2)
            {
                return 0;
            }

            public int SortByYear(Song Song1, Song Song2)
            {
                int tResult = Convert.ToInt32(Song2.Year).CompareTo(Convert.ToInt32(Song1.Year));

                if (tResult == 0)
                {
                    tResult = Song1.Artist.CompareTo(Song2.Artist);

                    if (tResult == 0)
                        tResult = Song1.Title.CompareTo(Song2.Title);
                }
                return tResult;
            }

            public int SortByArtist(Song Song1, Song Song2)
            {
                int tResult = Song1.Artist.CompareTo(Song2.Artist);

                if (tResult == 0)
                {
                    tResult = Convert.ToInt32(Song1.Year).CompareTo(Convert.ToInt32(Song2.Year));

                    if (tResult == 0)
                        tResult = Song1.Title.CompareTo(Song2.Title);
                }
                return tResult;
            }

            public int SortByPath(Song Song1, Song Song2)
            {
                return Song1.Path.CompareTo(Song2.Path);
            }

            public int SortByRelease(Song Song1, Song Song2)
            {
                return Song1.Release.CompareTo(Song2.Release);
            }
        }
    }
}