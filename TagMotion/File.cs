using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace Chrismo.TagMotion
{

    public class Picture : File
    {
        private int _Width = 0;
        private int _Height = 0;

        [CategoryAttribute("Info")]
        public int Width { get { return _Width; } }

        [CategoryAttribute("Info")]
        public int Height { get { return _Height; } }

        public Picture(string pFilePath)
            : base(pFilePath)
        {
            _Node.Tag = NodeType.Picture;

            Bitmap tImage = new Bitmap(pFilePath);

            _Width = tImage.Width;
            _Height = tImage.Height;

            tImage.Dispose();
        }

        public void AfterSelect(ref Image pImage, ref PropertyGrid tPropertyGrid)
        {
            pImage = new Bitmap(this.Path);
            tPropertyGrid.SelectedObject = this;
        }
    }



    public class Info : File
    {
        public Info(string pFilePath)
            : base(pFilePath)
        {
            _Node.Tag = NodeType.Info;
        }

        public void AfterSelect(ref Image pImage, ref PropertyGrid tPropertyGrid)
        {
            pImage = null;
            tPropertyGrid.SelectedObject = this;
        }
    }



    public class Song : File
    {
        private string _Artist = "";
        private string _Title = "";
        private int _Track = 0;
        private int _Bitrate = 0;
        private string _Type = "";
        private TimeSpan _Duration = TimeSpan.Zero;
        private string _DurationAsString = "";
        private TagLib.File _TaglibFile = null;
        private bool _IsValid = false;
        private object _SyncRoot = new object();
        private List<TagLib.IPicture> _IPictures = new List<TagLib.IPicture>();

        [CategoryAttribute("Info")]
        public string Type { get { return _Type; } }

        [CategoryAttribute("Info")]
        public int Bitrate { get { return _Bitrate; } }

        [CategoryAttribute("Info")]
        public string Duration { get { return _DurationAsString; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public string Artist { get { return _Artist; } set { _Artist = value; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public string Title { get { return _Title; } set { _Title = value; } }

        [LocalizableAttribute(true), CategoryAttribute("Tags")]
        public int Track { get { return _Track; } set { _Track = value; } }

        [BrowsableAttribute(false)]
        public bool HasValidTags { get { return ValidateTags(); } }

        [BrowsableAttribute(false)]
        public TimeSpan DurationAsTimeSpan { get { return _Duration; } }

        [BrowsableAttribute(false)]
        public bool IsValid { get { return _IsValid; } }

        [BrowsableAttribute(false)]
        public List<TagLib.IPicture> Pictures { get { return _IPictures; } set { _IPictures = value; } }

        public Song(string pFilePath)
            : base(pFilePath)
        {
            _Node.Tag = NodeType.Song;

            _IsValid = this.ReadTags();

            this.UpdateForeColor();

            _DurationAsString = Utilities.GetDurationAsString(_Duration);
        }

        public void AfterSelect(ref Image pImage, ref PropertyGrid tPropertyGrid)
        {
            if (_IPictures.Count > 0)
            {
                try { pImage = this.ConvertID3PictureToImage(_IPictures[0]); }
                catch { }
            }
            else
                pImage = null;

            tPropertyGrid.SelectedObject = this;
        }

        public new void UpdateForeColor()
        {
            if (_Filtered)
                _Node.ForeColor = Color.PaleGoldenrod;
            else
                _Node.ForeColor = (this.HasValidTags ? Color.FromArgb(0, 50, 0) : Color.FromArgb(100, 0, 0));
        }

        public void SaveTags()
        {
            lock (_SyncRoot)
            {
                _TaglibFile.Tag.AlbumArtists = new string[] { _RecordArtist };
                _TaglibFile.Tag.Album = _RecordTitle;
                _TaglibFile.Tag.Performers = new string[] { _Artist };
                _TaglibFile.Tag.Title = _Title;
                _TaglibFile.Tag.Track = (uint)_Track;
                _TaglibFile.Tag.Year = (uint)_Year;
                _TaglibFile.Tag.Publisher = _Label;
                _TaglibFile.Tag.Conductor = _Label;
                _TaglibFile.Tag.Comment = _Release;
                _TaglibFile.Tag.Genres = new string[] { _Genre };

                try
                {
                    _TaglibFile.Save();

                    this.UpdateForeColor();
                }
                catch (Exception ex) { MessageBox.Show("Cannot save tags the file " + _Path + "." + Environment.NewLine + ex.Message); }
            }
        }

        public bool ValidateTags()
        {
            bool tHasValidTags = true;

            if (Settings.FileStructure.Contains(Settings.RECORDARTIST)) tHasValidTags &= _RecordArtist != "";
            if (Settings.FileStructure.Contains(Settings.RECORDTITLE)) tHasValidTags &= _RecordTitle != "";
            if (Settings.FileStructure.Contains(Settings.ARTIST)) tHasValidTags &= _Artist != "";
            if (Settings.FileStructure.Contains(Settings.TITLE)) tHasValidTags &= _Title != "";
            if (Settings.FileStructure.Contains(Settings.YEAR)) tHasValidTags &= _Year != 0;
            if (Settings.FileStructure.Contains(Settings.TRACK)) tHasValidTags &= _Track != 0;
            if (Settings.FileStructure.Contains(Settings.LABEL)) tHasValidTags &= _Label != "";
            if (Settings.FileStructure.Contains(Settings.RELEASE)) tHasValidTags &= _Release != "";
            if (Settings.FileStructure.Contains(Settings.GENRE)) tHasValidTags &= _Genre != "";

            return tHasValidTags;
        }

        public void SavePicturesToTag(TagLib.IPicture[] pPics)
        {
            lock (_SyncRoot)
            {
                if (pPics != null && pPics.Length > 0)
                    _TaglibFile.Tag.Pictures = pPics;

                pPics[0].Description = _RecordArtist + " - " + _RecordTitle;
                pPics[0].Type = TagLib.PictureType.FrontCover;


                _TaglibFile.Save();
            }
        }

        public static TagLib.IPicture ConvertImageToID3Picture(string pImagePath)
        {
            return new TagLib.Picture(pImagePath);
        }

        public Image ConvertID3PictureToImage(TagLib.IPicture pPicture)
        {
            MemoryStream tStream = new MemoryStream(pPicture.Data.Data.Length);

            tStream.Write(pPicture.Data.Data, 0, pPicture.Data.Data.Length);
            tStream.Flush();

            Image tImage = Image.FromStream(tStream);

            tStream.Close();

            return tImage;
        }

        public void SaveID3PictureToImage(TagLib.IPicture pPicture, string pPath)
        {
            if (System.IO.File.Exists(pPath))
                return;

            MemoryStream tStream = new MemoryStream(pPicture.Data.Data.Length);

            tStream.Write(pPicture.Data.Data, 0, pPicture.Data.Data.Length);
            tStream.Flush();

            try
            {
                Image tImage = Image.FromStream(tStream);
                tImage.Save(Utilities.CleanFileString(pPath), System.Drawing.Imaging.ImageFormat.Png);
            }
            finally
            {
                tStream.Close();
            }
        }

        private bool ReadTags()
        {
            try { _TaglibFile = TagLib.File.Create(_Path); }
            catch (PathTooLongException) { return false; }
            catch (TagLib.CorruptFileException) { return false; }
            catch (System.Threading.ThreadAbortException) { return false; }
            catch (Exception) { return false; }

            _RecordArtist = Utilities.CleanTagString(_TaglibFile.Tag.FirstAlbumArtist);
            _RecordTitle = Utilities.CleanTagString(_TaglibFile.Tag.Album);
            _Artist = Utilities.CleanTagString(_TaglibFile.Tag.FirstPerformer);
            _Title = Utilities.CleanTagString(_TaglibFile.Tag.Title);
            _Year = (int)_TaglibFile.Tag.Year;
            _Track = (int)_TaglibFile.Tag.Track;
            _Label = Utilities.CleanTagString(_TaglibFile.Tag.Publisher);
            _Release = Utilities.CleanTagString(_TaglibFile.Tag.Comment);
            _Genre = Utilities.CleanTagString(_TaglibFile.Tag.FirstGenre);
            _Bitrate = _TaglibFile.Properties.AudioBitrate;
            _Duration = _TaglibFile.Properties.Duration;
            _Type = _TaglibFile.Properties.Description;

            if (_RecordArtist == "") _RecordArtist = _Artist;
            if (_Label == "") _Label = Utilities.CleanTagString(_TaglibFile.Tag.Conductor);

            if (_Type.Contains("VBR"))
                _Bitrate = GetVariableBitrate();

            _IPictures.AddRange(_TaglibFile.Tag.Pictures);



            return true;
        }

        private int GetVariableBitrate()
        {
            return (int)(_FileSize * 8.0 / (_Duration.Minutes * 60.0 + _Duration.Seconds + _Duration.Milliseconds / 1000.0) / 1000.0);
        }
    }

    public class File
    {
        protected string _Path = "";
        protected string _RecordArtist = "";
        protected string _RecordTitle = "";
        protected int _Year = 0;
        protected string _Genre = "";
        protected string _Label = "";
        protected string _Release = "";
        protected int _RecordBitrate = 0;
        protected long _FileSize = 0;
        protected string _FileSizeAsString = "";
        protected bool _Filtered = false;

        protected TreeNode _Node = null;

        [CategoryAttribute("Info")]
        public string Size { get { return _FileSizeAsString; } }

        [ReadOnly(true), CategoryAttribute("Tags")]
        public string RecordArtist { get { return _RecordArtist; } set { _RecordArtist = value; } }

        [ReadOnly(true), CategoryAttribute("Tags")]
        public string RecordTitle { get { return _RecordTitle; } set { _RecordTitle = value; } }

        [ReadOnly(true), CategoryAttribute("Tags")]
        public string Label { get { return _Label; } set { _Label = value; } }

        [ReadOnly(true), CategoryAttribute("Tags")]
        public string Release { get { return _Release; } set { _Release = value; } }

        [ReadOnly(true), CategoryAttribute("Tags")]
        public int Year { get { return _Year; } set { _Year = value; } }

        [ReadOnly(true), CategoryAttribute("Tags")]
        public string Genre { get { return _Genre; } set { _Genre = value; } }

        [BrowsableAttribute(false)]
        public string Path { get { return _Path; } }

        [BrowsableAttribute(false)]
        public int RecordBitrate { get { return _RecordBitrate; } set { _RecordBitrate = value; } }

        [BrowsableAttribute(false)]
        public long SizeAsLong { get { return _FileSize; } }

        [BrowsableAttribute(false)]
        public TreeNode Node { get { return _Node; } set { _Node = value; } }

        [BrowsableAttribute(false)]
        public bool Filtered { get { return _Filtered; } set { _Filtered = value; } }


        public File(string pFilePath)
        {
            _Path = pFilePath;
            _FileSize = new FileInfo(_Path).Length;
            _FileSizeAsString = Utilities.GetSizeAsString(_FileSize);

            // if file is readonly, then change attributes
            if (System.IO.File.GetAttributes(_Path).ToString().Contains("ReadOnly"))
                System.IO.File.SetAttributes(_Path, FileAttributes.Normal);

            _Node = new TreeNode(this.Path);

            Font tFont = new Font("Arial", 8, FontStyle.Regular);
            _Node.NodeFont = tFont;
        }

        public void UpdateForeColor()
        {
            if (_Filtered)
                _Node.ForeColor = Color.PaleGoldenrod;
        }

        public void Copy(string pNewFilePath, bool pOverwrite)
        {
            FileInfo fi = new FileInfo(pNewFilePath);

            if (!fi.Directory.Exists)
                Directory.CreateDirectory(fi.DirectoryName);

            if (!Settings.CreateDummyFile)
            {
                if (!System.IO.File.Exists(_Path))
                {
                    MessageBox.Show(_Path + " does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_Path == pNewFilePath)
                    return;

                System.IO.File.Copy(_Path, pNewFilePath, pOverwrite);
                System.IO.File.SetAttributes(pNewFilePath, FileAttributes.Normal);
            }
            else
            {
                if (System.IO.File.Exists(pNewFilePath) == false)
                    System.IO.File.Create(pNewFilePath).Close();
            }
        }

        public bool Delete(bool pConfirmDialog)
        {
            if (pConfirmDialog)
                if (MessageBox.Show("Do you really want to delete " + _Path, "File Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return false;

            try
            {
                System.IO.File.Delete(_Path);

                _Node.Remove();

                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message); return false;
            }
        }

        public string Rename(int pCounter)
        {
            string tNewFileName = Settings.FileStructure.ToUpper();

            tNewFileName = tNewFileName.Replace(Settings.RECORDARTIST, _RecordArtist);
            tNewFileName = tNewFileName.Replace(Settings.RECORDTITLE, _RecordTitle);
            tNewFileName = tNewFileName.Replace(Settings.GENRE, _Genre);
            tNewFileName = tNewFileName.Replace(Settings.YEAR, _Year.ToString("0000"));
            tNewFileName = tNewFileName.Replace(Settings.LABEL, _Label);
            tNewFileName = tNewFileName.Replace(Settings.RELEASE, _Release);
            tNewFileName = tNewFileName.Replace(Settings.BITRATE, _RecordBitrate.ToString("000"));
            tNewFileName = tNewFileName.Replace(Settings.DIR, new System.IO.FileInfo(_Path).Directory.Name);

            if (this is Song)
            {
                tNewFileName = tNewFileName.Replace(Settings.ARTIST, ((Song)this).Artist);
                tNewFileName = tNewFileName.Replace(Settings.TRACK, ((Song)this).Track.ToString("00"));
                tNewFileName = tNewFileName.Replace(Settings.TITLE, ((Song)this).Title);
            }
            else
            {
                tNewFileName = tNewFileName.Replace(Settings.ARTIST, _RecordArtist);
                tNewFileName = tNewFileName.Replace(Settings.TRACK, "00");

                string tText = this is Picture ? this.RecordArtist : "Info";

                tNewFileName = pCounter > 0 ? tNewFileName.Replace(Settings.TITLE, this.RecordTitle + " " + pCounter.ToString("0")) : tNewFileName.Replace(Settings.TITLE, this.RecordTitle);
            }

            tNewFileName = Utilities.CleanFileString(tNewFileName);

            while (tNewFileName.Length > 250)
                tNewFileName = tNewFileName.Substring(0, tNewFileName.Length - 1);

            tNewFileName += new FileInfo(_Path).Extension;

            return System.IO.Path.Combine(Settings.DestinationDir, tNewFileName);
        }

        public string Rename()
        {
            return this.Rename(0);
        }
    }
}