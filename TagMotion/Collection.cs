using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Chrismo.TagMotion
{
    public enum SortType
    {
        Year = 0,
        Artist,
        Path,
        Comment,
        CreationTime
    }


    public enum NodeType
    {
        Collection = 0,
        Record,
        Song,
        Picture,
        Info
    }

    public class Collection
    {
        private string _Path = "";
        private List<Record> _Records = new List<Record>();
        private string _Artist = "";
        private string _Label = "";
        private string _Comment = "";
        private string _Genre = "";
        private int _ProgressValue = 0;
        private int _ProgressMax;
        private TreeNode _Node = null;
        private bool _StopReading = false;

        [CategoryAttribute("Info")]
        public string Duration { get { return Utilities.GetDurationAsString(GetCollectionDuration()); } }

        [CategoryAttribute("Info")]
        public string Size { get { return Utilities.GetSizeAsString(GetCollectionSize()); } }

        [CategoryAttribute("Tags")]
        public string Artist { get { return _Artist; } set { _Artist = value; } }

        [CategoryAttribute("Tags")]
        public string Label { get { return _Label; } set { _Label = value; } }

        [CategoryAttribute("Tags")]
        public string Comment { get { return _Comment; } set { _Comment = value; } }

        [CategoryAttribute("Tags")]
        public string Genre { get { return _Genre; } set { _Genre = value; } }

        [BrowsableAttribute(false)]
        public string Path { get { return _Path; } }

        [BrowsableAttribute(false)]
        public List<Record> Records { get { return _Records; } }

        [BrowsableAttribute(false)]
        public TreeNode Node { get { return _Node; } set { _Node = value; } }

        [BrowsableAttribute(false)]
        public bool StopReading { get { return _StopReading; } set { _StopReading = value; } }


        public Collection(string pDir)
        {
            if (!Directory.Exists(pDir))
            {
                MessageBox.Show("Source Directory does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Path = pDir;
        }


        public void ReadDirectory()
        {
            _Records.Clear();

            _Node = new TreeNode(this.Path);
            _Node.Tag = NodeType.Collection;

            _ProgressMax = Directory.GetDirectories(_Path).Length;

            TreeNode tRecordsNode = new TreeNode("Records: ");
            _Node.Nodes.Add(tRecordsNode);

            this.GetAllRecords(_Path);

            _Node.Nodes[0].Text += _Records.Count;
            _Node.Nodes[0].Expand();

            _Node.Expand();

            if (_Records.Count > 0)
                this.ReadProperties();
        }



        public void AfterSelect(ref Image pImage, ref PropertyGrid tPropertyGrid)
        {
            pImage = null;
            tPropertyGrid.SelectedObject = this;
        }



        public void Copy()
        {
            _ProgressMax = _Records.Count;
            _ProgressValue = 0;

            foreach (Record tRecord in _Records.Where(delegate(Record R) { return R.HasValidTags; }))
            {
                _ProgressValue++;
                Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Copying Record ... " + tRecord.Path);

                if (Filter.CopyOnlyFiltered)
                {
                    if (!tRecord.Filtered)
                        tRecord.Copy(true);
                }
                else
                    tRecord.Copy(true);
            }
        }


        public void Sort(SortType pSortType)
        {
            Comparer tComparer = new Comparer();
                        
            switch (pSortType)
            {
                case SortType.Year: _Records.Sort(tComparer.SortByYear); break;
                case SortType.Artist: _Records.Sort(tComparer.SortByArtist); break;
                case SortType.Comment: _Records.Sort(tComparer.SortByComment); break;
                case SortType.Path: _Records.Sort(tComparer.SortByPath); break;
                case SortType.CreationTime: _Records.Sort(tComparer.SortByCreationTime); break;
                default: return;
            }

            _Node.Nodes[0].Nodes.Clear();

            foreach (Record tRecord in _Records)
                _Node.Nodes[0].Nodes.Add(tRecord.Node);

            _Node.Nodes[0].Expand();
        }


        public static void LoadFromXML(string pFilePath, ref TreeView pTreeView)
        {
            TreeviewHandler tTreeViewHandler = new TreeviewHandler();

            tTreeViewHandler.XmlToTreeView(pFilePath, pTreeView);
        }
        
        public void SaveToXML(string pFilePath)
        {
            TreeviewHandler tTreeViewHandler = new TreeviewHandler();

            TreeView tTreeView = new TreeView();

            tTreeView.Nodes.Add(_Node);

            tTreeViewHandler.TreeViewToXml(tTreeView, pFilePath);
        }

        public void SaveToHTML(string pFilePath)
        {
            if (System.IO.File.Exists(pFilePath) == true)
                System.IO.File.Delete(pFilePath);

            FileStream tFile = new FileStream(pFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter tWriter = new StreamWriter(tFile, System.Text.Encoding.UTF8);

            tWriter.BaseStream.Seek(0, SeekOrigin.End);

            tWriter.WriteLine("<html><head><title>music collection</title>");
            tWriter.WriteLine("<style type=\"text/css\"><!--body {margin: 50px;}body, th, td, p, div, li {font-family: Helvetica, Verdana, Arial, sans-serif; font-size: 12px; color: #DCD581 ;}");
            tWriter.WriteLine("h1 {font-size: 28px;font-weight: bold;}h2 {font-size: 14px;font-weight: bold;}");
            tWriter.WriteLine("table.border {border: 1px solid #666666; border-collapse: collapse;}");
            tWriter.WriteLine("th {font-weight: bold;vertical-align: top;padding: 5px;text-align: left;background: #DCD581 ;border-right: 1px solid #000000;color: #000000;}");
            tWriter.WriteLine("td {vertical-align: top;padding: 5px;text-align: left;border-top: 1px solid #666666;border-right: 1px solid #666666;}");
            tWriter.WriteLine("td.key {background: #DCD581;font-weight: bold;}");
            tWriter.WriteLine("a:link {color: #DCD581 ;text-decoration:none;}a:visited {color: #DCD581 ;text-decoration:none;}</style>");
            tWriter.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\"></HEAD>");
            tWriter.WriteLine("<BODY bgcolor=\"#000000\"><h1>music collection</h1><br><br><br><br><h2>share music</h2>");
            tWriter.WriteLine("<table cellpadding=\"0\" cellspacing=\"0\" class=\"border\" width=\"1000px\">");
            tWriter.WriteLine("<tr><th>#</th><th>artist (label)</th><th>title</th><th>year</th></tr>");
            tWriter.Flush();

            string tArtist;
            string tTitle;
            string tYear;
            int tCounter = 0;

            foreach (Record tRecord in _Records)
            {
                tCounter++;

                if (tRecord.Artist.Contains("(") == true)
                {
                    tArtist = "<a href=http://www.discogs.com/label/" + tRecord.Artist.Replace(" ", "+").Replace("(", "").Replace(")", "").Replace("-", "%E2%80%93") + ">" + tRecord.Artist + "</a>";
                    tTitle = "<a href=http://www.discogs.com/label/" + tRecord.Artist.Replace(" ", "+").Replace("(", "").Replace(")", "").Replace("-", "%E2%80%93") + ">" + tRecord.Title + "</a>";
                    tYear = "<a href=http://www.discogs.com/label/" + tRecord.Artist.Replace(" ", "+").Replace("(", "").Replace(")", "").Replace("-", "%E2%80%93") + ">" + tRecord.Year.ToString() + "</a>";
                }
                else
                {
                    tArtist = "<a href=http://www.discogs.com/artist/" + tRecord.Artist.Replace(" ", "+").Replace("-", "%E2%80%93") + ">" + tRecord.Artist + "</a>";
                    tTitle = "<a href=http://www.discogs.com/artist/" + tRecord.Artist.Replace(" ", "+").Replace("-", "%E2%80%93") + ">" + tRecord.Title + "</a>";
                    tYear = "<a href=http://www.discogs.com/artist/" + tRecord.Artist.Replace(" ", "+").Replace("-", "%E2%80%93") + ">" + tRecord.Year.ToString() + "</a>";
                }

                tWriter.WriteLine("<tr><td>" + tCounter.ToString("0000") + "</td><td>" + tArtist + "</td><td>" + tTitle + "</td><td>" + tYear + "</td></tr>");
                tWriter.Flush();
            }

            tWriter.WriteLine("</table></body></html>");
            tWriter.Flush();
            tWriter.Close();
        }

        public void SaveToTXT(string pFilePath)
        {
            System.Collections.Generic.List<string> tList = new System.Collections.Generic.List<string>();

            if (System.IO.File.Exists(pFilePath) == true)
                System.IO.File.Delete(pFilePath);

            FileStream tFile = new FileStream(pFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter tWriter = new StreamWriter(tFile, System.Text.Encoding.UTF8);

            tWriter.BaseStream.Seek(0, SeekOrigin.End);

            foreach (Record tRecord in _Records)
            {
                if (!tRecord.Filtered)
                {
                    string tLine = Settings.FileStructure.ToUpper();

                    if (tLine.Contains(Settings.RECORDARTIST))
                        tLine = tLine.Replace(Settings.RECORDARTIST, tRecord.Artist);

                    if (tLine.Contains(Settings.RECORDTITLE))
                        tLine = tLine.Replace(Settings.RECORDTITLE, tRecord.Title);

                    if (tLine.Contains(Settings.ARTIST))
                        tLine = tLine.Replace(Settings.ARTIST, tRecord.Artist);

                    if (tLine.Contains(Settings.TITLE))
                        tLine = tLine.Replace(Settings.TITLE, tRecord.Title);

                    if (tLine.Contains(Settings.YEAR))
                        tLine = tLine.Replace(Settings.YEAR, tRecord.Year.ToString("0000"));

                    if (tLine.Contains(Settings.TRACK))
                        tLine = tLine.Replace(Settings.TRACK, "");

                    if (tLine.Contains(Settings.LABEL))
                        tLine = tLine.Replace(Settings.LABEL, tRecord.Label);

                    if (tLine.Contains(Settings.COMMENT))
                        tLine = tLine.Replace(Settings.COMMENT, tRecord.Comment);

                    if (tLine.Contains(Settings.BITRATE))
                        tLine = tLine.Replace(Settings.BITRATE, tRecord.Bitrate.ToString());

                    if (tLine.Contains(Settings.GENRE))
                        tLine = tLine.Replace(Settings.GENRE, tRecord.Genre);

                    tList.Add(tLine);
                }
            }

            tList.Sort();

            tWriter.Write(String.Join(Environment.NewLine, tList.ToArray()));

            tWriter.Flush();
            tWriter.Close();
        }


        public void SaveTags(string pField, string pValue)
        {
            _ProgressMax = _Records.Count;
            _ProgressValue = 0;

            foreach (Record tRecord in _Records)
            {
                _ProgressValue++;
                Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Saving Tags :: " + tRecord.Path);

                switch (pField)
                {
                    case "Artist": tRecord.Artist = _Artist; break;
                    case "Label": tRecord.Label = _Label; break;
                    case "Comment": tRecord.Comment = _Comment; break;
                    case "Genre": tRecord.Genre = _Genre; break;
                }

                tRecord.SaveTags();
            }

            Utilities.UpdateStatus(_ProgressMax, _ProgressMax, "Saving Tags finished");
        }
        
        public Record GetRecord(string pPath)
        {
            if(pPath == "")
                // Record.Path == Collection.Path
                return _Records.First(delegate(Record R) { return R.Path == _Path; });
            else
                return _Records.First(delegate(Record R) { return R.Path == System.IO.Path.Combine(_Path, pPath); });
        }

        private void ReadProperties()
        {
            // change only one property
            _Artist = _Records.All(delegate(Record R) { return R.Artist == _Records[0].Artist; }) ? _Records[0].Artist : "";
            _Label = _Records.All(delegate(Record R) { return R.Label == _Records[0].Label; }) ? _Records[0].Label : "";
            _Comment = _Records.All(delegate(Record R) { return R.Comment == _Records[0].Comment; }) ? _Records[0].Comment : "";
            _Genre = _Records.All(delegate(Record R) { return R.Genre == _Records[0].Genre; }) ? _Records[0].Genre : "";
        }

        private void GetAllRecords(string pDir)
        {
            if (_StopReading)
                return;

            if (_Path == Directory.GetParent(pDir).FullName)
            {
                _ProgressValue++;
                Utilities.UpdateStatus(_ProgressValue, _ProgressMax, "Reading :: " + pDir);
            }

            Record tRecord = new Record(@pDir);

            if (tRecord.IsValid)
            {
                if (tRecord.Node.Text == this.Path)
                    tRecord.Node.Text = tRecord.Node.Text.Substring(this.Path.Length);
                else
                    tRecord.Node.Text = tRecord.Node.Text.Substring(this.Path.Length + 1);

                // if  Record.Tags not completly filled, query from FreeDB
                if (Settings.FreeDBChecking && !tRecord.HasValidTags)
                {
                    if (tRecord.QueryFreeDB(false))
                        tRecord.UpdateForeColors();
                }

                _Records.Add(tRecord);

                _Node.Nodes[0].Nodes.Add(tRecord.Node);
            }

            // recursiv reading
            if (Directory.GetDirectories(pDir) != null)
                if (Directory.GetDirectories(pDir).Length > 0)
                    foreach (string tSubDir in Directory.GetDirectories(pDir))
                        GetAllRecords(tSubDir);
        }

        private TimeSpan GetCollectionDuration()
        {
            TimeSpan tCollectionDuration = TimeSpan.Zero;

            foreach (Record tRecord in _Records)
                tCollectionDuration += tRecord.DurationAsTimeSpan;

            return tCollectionDuration;
        }

        private long GetCollectionSize()
        {
            long tCollectionSize = 0;

            foreach (Record tRecord in _Records)
                tCollectionSize += tRecord.SizeAsLong;

            return tCollectionSize;
        }

        public class Comparer : IComparer<Record>
        {
            public int Compare(Record Record1, Record Record2)
            {
                return 0;
            }

            public int SortByYear(Record Record1, Record Record2)
            {
                int tResult = Convert.ToInt32(Record2.Year).CompareTo(Convert.ToInt32(Record1.Year));

                if (tResult == 0)
                {
                    tResult = Record1.Artist.CompareTo(Record2.Artist);

                    if (tResult == 0)
                        tResult = Record1.Title.CompareTo(Record2.Title);
                }
                return tResult;
            }

            public int SortByArtist(Record Record1, Record Record2)
            {
                int tResult = Record1.Artist.CompareTo(Record2.Artist);

                if (tResult == 0)
                {
                    tResult = Convert.ToInt32(Record1.Year).CompareTo(Convert.ToInt32(Record2.Year));

                    if (tResult == 0)
                        tResult = Record1.Title.CompareTo(Record2.Title);
                }
                return tResult;
            }

            public int SortByPath(Record Record1, Record Record2)
            {
                return Record1.Path.CompareTo(Record2.Path);
            }

            public int SortByComment(Record Record1, Record Record2)
            {
                return Record1.Comment.CompareTo(Record2.Comment);
            }

            public int SortByCreationTime(Record Record1, Record Record2)
            {
                return Record2.CreationTime.CompareTo(Record1.CreationTime);
            }
        }
    }
}