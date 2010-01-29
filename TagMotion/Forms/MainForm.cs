using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;

namespace Chrismo.TagMotion.Forms
{
    public partial class MainForm : Form
    {
        private Collection _Collection;
        private SettingsDialog _SettingsDialog = new SettingsDialog();
        private FilterDialog _Filter = new FilterDialog();
        private TreeNode _SelectedNode;
        private Thread _Thread;

        private string _DirPath;
        private string _FilePath;
        private string _PropertyLabel;
        private string _PropertyValue;
        private int _SelectedSourceDir;
        private bool _ReadingSourceDirectory = false;
        private bool _DropAllowed = true;

        private Random _Random = new Random();

        public MainForm()
        {
            InitializeComponent();

            Utilities.StatusDelegate = new Utilities.UpdateStatusDelegate(UpdateStatus);

            Settings.Load();

            _SelectedSourceDir = Settings.SelectedSourceDir;

            this.FillSettingsDLG();
            this.SetStartText();
            this.SetToolTips();
        }

        private void FillSettingsDLG()
        {
            foreach (string tSourceDir in Settings.SourceDirs)
                _SettingsDialog.ComboBox_SourceDir.Items.Add(tSourceDir);

            foreach (string tDestinationDir in Settings.DestinationDirs)
                _SettingsDialog.ComboBox_DestinationDir.Items.Add(tDestinationDir);

            foreach (string tFileStructure in Settings.FileStructures)
                _SettingsDialog.ComboBox_FileStructure.Items.Add(tFileStructure);

            _SettingsDialog.ComboBox_SourceDir.Text = Settings.SourceDirs[Settings.SelectedSourceDir];
            _SettingsDialog.ComboBox_DestinationDir.Text = Settings.DestinationDirs[Settings.SelectedDestinationDir];
            _SettingsDialog.ComboBox_FileStructure.Text = Settings.FileStructures[Settings.SelectedFileStructure];
            _SettingsDialog.TextBox_InfoFileTypes.Text = Settings.InfoTypes;
            _SettingsDialog.comboBox_SortType.Text = Settings.SortType;
            _SettingsDialog.checkBox_DummyCreation.Checked = Settings.CreateDummyFile;
            _SettingsDialog.checkBox_FreeDBQuery.Checked = Settings.FreeDBChecking;
        }

        private void FillTreeview()
        {
            try
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(FillTreeview));
                else
                {
                    this.TreeView.Nodes.Clear();

                    this.TreeView.Nodes.Add(_Collection.Node);

                    this.MoveSplitter(this.PropertyGrid, this.PropertyGrid.Width / 4);

                    this.Statusbar.Text = Settings.SourceDir + " read.";

                    this.TreeView.Focus();

                    _SelectedNode = this.TreeView.SelectedNode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception :: " + ex.GetType() + Environment.NewLine + "Message: " + ex.Message);
            }
        }

        private void ReadSourceDirectory()
        {
			Timer tTimer = new Timer();

			tTimer.Start();

            _Collection = new Collection(Settings.SourceDir);

            try
            {
                _Collection.ReadDirectory();
            }
            catch (OutOfMemoryException ex)
            {
                _Collection.StopReading = true;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(FileNotFoundException) && ex.Message.Contains("System.Core"))
                    MessageBox.Show("You need to install the latest Version of the .NET Runtime. (3.5 or higher)");
                else
                    MessageBox.Show("Error during Reading the Source Directory:" + Environment.NewLine + ex.Message);

                return;
            }

            switch (Settings.SortType)
            {
                case "Path": _Collection.Sort(SortType.Path); break;
                case "CreationTime": _Collection.Sort(SortType.CreationTime); break;
                case "Artist": _Collection.Sort(SortType.Artist); break;
                case "Year": _Collection.Sort(SortType.Year); break;
                case "Comment": _Collection.Sort(SortType.Comment); break;
            }

            this.FillTreeview();

			this.Statusbar.Text += String.Format(" ({0} sec)", tTimer.Stop().ToString("##0.000"));
            this.button_ReadSourceDirectory.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.media_playback_start;

            _ReadingSourceDirectory = false;

            Settings.SelectedSourceDir = _SelectedSourceDir;
        }

        private void ReadSourceDirectory_Click(object sender, EventArgs e)
        {
            _ReadingSourceDirectory = !_ReadingSourceDirectory;

            if (_ReadingSourceDirectory)
            {
                this.button_ReadSourceDirectory.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.media_playback_stop;

                _Thread = new Thread(ReadSourceDirectory);
                _Thread.Start();
            }
            else
            {
                _Collection.StopReading = true;

                this.button_ReadSourceDirectory.BackgroundImage = global::Chrismo.TagMotion.Properties.Resources.media_playback_start;
            }
        }

        private void SaveCollectionAs_Click(object sender, EventArgs e)
        {
            if (_Collection == null)
                return;

            SaveFileDialog DLG = new SaveFileDialog();

            DLG.FileName = Path.Combine(Settings.DestinationDir, new DirectoryInfo(_Collection.Path).Name);
            DLG.Filter = "txt files (*.txt)|*.txt|html files (*.html)|*.html|xml files (*.xml)|*.xml";

            if (DLG.ShowDialog() != DialogResult.OK)
                return;

            if (DLG.FileName.EndsWith(".txt"))
                _Collection.SaveToTXT(DLG.FileName);

            if (DLG.FileName.EndsWith(".html"))
                _Collection.SaveToHTML(DLG.FileName);

            if (DLG.FileName.EndsWith(".xml"))
                _Collection.SaveToXML(DLG.FileName);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            string tSortType = Settings.SortType;
            string tFileStructure = Settings.FileStructure;

            if (_SettingsDialog.ShowDialog(this) != DialogResult.OK)
                return;


            Settings.SourceDirs.Clear();

            foreach (string tItem in _SettingsDialog.ComboBox_SourceDir.Items)
                Settings.SourceDirs.Add(tItem);

            Settings.SelectedSourceDir = _SettingsDialog.ComboBox_SourceDir.SelectedIndex;


            Settings.DestinationDirs.Clear();

            foreach (string tItem in _SettingsDialog.ComboBox_DestinationDir.Items)
                Settings.DestinationDirs.Add(tItem);

            Settings.SelectedDestinationDir = _SettingsDialog.ComboBox_DestinationDir.SelectedIndex;


            Settings.FileStructures.Clear();

            foreach (string tItem in _SettingsDialog.ComboBox_FileStructure.Items)
                Settings.FileStructures.Add(tItem);

            Settings.SelectedFileStructure = _SettingsDialog.ComboBox_FileStructure.SelectedIndex;


            Settings.InfoTypes = _SettingsDialog.TextBox_InfoFileTypes.Text;
            Settings.SortType = _SettingsDialog.comboBox_SortType.Text;
            Settings.CreateDummyFile = _SettingsDialog.checkBox_DummyCreation.Checked;
            Settings.FreeDBChecking = _SettingsDialog.checkBox_FreeDBQuery.Checked;

			Settings.Save();



            if (_Collection == null)
                return;

            if (Settings.SortType != tSortType)
            {
                switch (Settings.SortType)
                {
                    case "Path": _Collection.Sort(SortType.Path); break;
                    case "CreationTime": _Collection.Sort(SortType.CreationTime); break;
                    case "Artist": _Collection.Sort(SortType.Artist); break;
                    case "Year": _Collection.Sort(SortType.Year); break;
                    case "Comment": _Collection.Sort(SortType.Comment); break;
                }

                this.FillTreeview();
            }

            if (tFileStructure != Settings.FileStructure)
                foreach (Record tRecord in _Collection.Records)
                    tRecord.UpdateForeColors();

            this.SetToolTips();
        }

        private void MoveSplitter(PropertyGrid propertyGrid, int x)
        {
            try
            {
#if !LINUX
                object propertyGridView = typeof(PropertyGrid).InvokeMember("gridView",
                    BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, propertyGrid, null);

                propertyGridView.GetType().InvokeMember("MoveSplitterTo",
                    BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, propertyGridView, new object[] { x });
# endif
            }
            catch (TargetInvocationException)
            { }
        }

        private bool FilterRecord(Record pRecord)
        {
            bool tReturn = pRecord.Bitrate < Filter.Bitrate.Min ||
                pRecord.Bitrate > Filter.Bitrate.Max ||
                pRecord.Year < Filter.Year.Min ||
                pRecord.Year > Filter.Year.Max ||
                pRecord.DurationAsTimeSpan.TotalMinutes < Filter.Duration.Min ||
                pRecord.DurationAsTimeSpan.TotalMinutes > Filter.Duration.Max;

            if (Filter.Type != "All Types") tReturn |= pRecord.Type != Filter.Type;
            if (Filter.Artist != "") tReturn |= pRecord.Artist != Filter.Artist;
            if (Filter.Label != "") tReturn |= pRecord.Label != Filter.Label;

            return tReturn;

        }

        private void Filter_Click(object sender, EventArgs e)
        {
            if (_Filter.ShowDialog(this) != DialogResult.OK)
                return;

            Filter.Bitrate.Min = _Filter.BitrateMin;
            Filter.Bitrate.Max = _Filter.BitrateMax;
            Filter.Year.Min = _Filter.YearMin;
            Filter.Year.Max = _Filter.YearMax;
            Filter.Duration.Min = _Filter.DurationMin;
            Filter.Duration.Max = _Filter.DurationMax;

            Filter.Artist = _Filter.textBox_Artist.Text;
            Filter.Label = _Filter.textBox_Label.Text;

            Filter.Type = _Filter.Type.Text;
            Filter.CopyOnlyFiltered = _Filter.checkBox_CopyOnlyFilteredRecords.Checked;

            if (_Collection == null)
                return;

            foreach (Record tRecord in _Collection.Records)
            {
                tRecord.Filtered = FilterRecord(tRecord);
                tRecord.UpdateForeColors();
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {
            new Forms.HelpBox().ShowDialog(this);
        }

        private void About_Click(object sender, EventArgs e)
        {
            new Forms.AboutBox().ShowDialog(this);
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _SelectedNode = e.Node;

            Image tImage = null;

            if (e.Node.Tag == null)
                return;

            switch ((NodeType)e.Node.Tag)
            {
                case NodeType.Collection:
                    _Collection.AfterSelect(ref tImage, ref this.PropertyGrid);
                    break;
                case NodeType.Record:
                    _Collection.GetRecord(e.Node.Text).AfterSelect(ref tImage, ref this.PropertyGrid);
                    break;
                case NodeType.Song:
                    _Collection.GetRecord(e.Node.Parent.Parent.Text).GetSong(e.Node.Text).AfterSelect(ref tImage, ref this.PropertyGrid);
                    break;
                case NodeType.Picture:
                    _Collection.GetRecord(e.Node.Parent.Parent.Text).GetPicture(e.Node.Text).AfterSelect(ref tImage, ref this.PropertyGrid);
                    break;
                case NodeType.Info:
                    _Collection.GetRecord(e.Node.Parent.Parent.Text).GetInfo(e.Node.Text).AfterSelect(ref tImage, ref this.PropertyGrid);
                    break;
            }

            this.PictureBox.Image = tImage;
            this.PictureBox.Show();
        }

        private void TreeViewNode_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.TreeView.SelectedNode = e.Node;

            this.contextMenu.Items[0].Visible = false;
            this.contextMenu.Items[1].Visible = false;
            this.contextMenu.Items[2].Visible = false;
            this.contextMenu.Items[3].Visible = false;
            this.contextMenu.Items[4].Visible = false;
            this.contextMenu.Items[5].Visible = false;

            if (e.Button != MouseButtons.Right || e.Node.Tag == null)
                return;

            switch ((NodeType)e.Node.Tag)
            {
                // 0 == Copy
                // 1 == Fill Tags
                // 2 == FreeDB Query
                // 3 == Store Image In Tags
                // 4 == Extract Image To File
                // 5 == Delete

                case NodeType.Collection:

                    this.contextMenu.Items[0].Visible = true;
                    this.contextMenu.Items[1].Visible = false;
                    this.contextMenu.Items[2].Visible = false;
                    this.contextMenu.Items[3].Visible = true;
                    this.contextMenu.Items[4].Visible = true;
                    this.contextMenu.Items[5].Visible = false;
                    break;

                case NodeType.Record:

                    this.contextMenu.Items[0].Visible = true;
                    this.contextMenu.Items[1].Visible = true;
                    this.contextMenu.Items[2].Visible = true;
                    this.contextMenu.Items[3].Visible = false;
                    this.contextMenu.Items[4].Visible = false;
                    this.contextMenu.Items[5].Visible = true;
                    break;

                case NodeType.Song:

                    this.contextMenu.Items[0].Visible = true;
                    this.contextMenu.Items[1].Visible = false;
                    this.contextMenu.Items[2].Visible = false;
                    this.contextMenu.Items[3].Visible = false;
                    this.contextMenu.Items[4].Visible = true;
                    this.contextMenu.Items[5].Visible = true;
                    break;

                case NodeType.Picture:

                    this.contextMenu.Items[0].Visible = false;
                    this.contextMenu.Items[1].Visible = false;
                    this.contextMenu.Items[2].Visible = false;
                    this.contextMenu.Items[3].Visible = true;
                    this.contextMenu.Items[4].Visible = false;
                    this.contextMenu.Items[5].Visible = true;
                    break;

                case NodeType.Info:

                    this.contextMenu.Items[0].Visible = false;
                    this.contextMenu.Items[1].Visible = false;
                    this.contextMenu.Items[2].Visible = false;
                    this.contextMenu.Items[3].Visible = false;
                    this.contextMenu.Items[4].Visible = false;
                    this.contextMenu.Items[5].Visible = true;
                    break;
            }

            this.contextMenu.Show(e.Location);
        }

        private void CopyCollection()
        {
            DisableButtons();

            try { _Collection.Copy(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            EnableButtons();
        }

        private void CopyRecord()
        {
            this.DisableButtons();

            try { _Collection.GetRecord(_DirPath).Copy(true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            this.EnableButtons();
        }

        private void CopySong()
        {
            this.DisableButtons();

            Record tRecord = _Collection.GetRecord(_DirPath);
            Song tSong = tRecord.GetSong(_FilePath);

            try { tSong.Copy(tSong.Rename(), true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            this.EnableButtons();
        }

        private void CopyPicture()
        {
            Record tRecord = _Collection.GetRecord(_DirPath);
            Picture tPicture = tRecord.GetPicture(_FilePath);

            try { tPicture.Copy(tPicture.Rename(), true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CopyInfo()
        {
            Record tRecord = _Collection.GetRecord(_DirPath);
            Info tInfo = tRecord.GetInfo(_FilePath);

            try { tInfo.Copy(tInfo.Rename(), true); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void EnableButtons()
        {
            _DropAllowed = true;

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(EnableButtons));
            else
            {
                this.contextMenu.Enabled = true;
                this.button_Settings.Enabled = true;
                this.ProgressBar.Value = this.ProgressBar.Maximum;
                this.Statusbar.Text = "finished";
                this.Refresh();

                Settings.CreateDummyFile = false;
            }
        }

        private void DisableButtons()
        {
            _DropAllowed = false;

            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(DisableButtons));
            else
            {
                this.contextMenu.Enabled = false;
                this.button_Settings.Enabled = false;
                this.Refresh();
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (this.TreeView.SelectedNode == null)
                return;

            switch ((NodeType)this.TreeView.SelectedNode.Tag)
            {
                case NodeType.Collection:

                    _Thread = new Thread(CopyCollection);
                    _Thread.Start();
                    break;

                case NodeType.Record:

                    _DirPath = this.TreeView.SelectedNode.Text;

                    _Thread = new Thread(CopyRecord);
                    _Thread.Start();
                    break;

                case NodeType.Song:

                    _DirPath = this.TreeView.SelectedNode.Parent.Parent.Text;
                    _FilePath = this.TreeView.SelectedNode.Text;

                    _Thread = new Thread(CopySong);
                    _Thread.Start();
                    break;

                case NodeType.Picture:

                    _DirPath = this.TreeView.SelectedNode.Parent.Parent.Text;
                    _FilePath = this.TreeView.SelectedNode.Text;

                    _Thread = new Thread(CopyPicture);
                    _Thread.Start();
                    break;

                case NodeType.Info:

                    _DirPath = this.TreeView.SelectedNode.Parent.Parent.Text;
                    _FilePath = this.TreeView.SelectedNode.Text;

                    _Thread = new Thread(CopyInfo);
                    _Thread.Start();
                    break;
            }

            if (Settings.CreateDummyFile)
                this.Statusbar.Text = this.TreeView.SelectedNode.Text + " created.";
        }

        private void DisposePictureBoxImage()
        {
            if (this.PictureBox.Image != null)
                this.PictureBox.Image.Dispose();

            this.PictureBox.Image = null;
            this.PictureBox.Show();

            GC.Collect();
            GC.SuppressFinalize(this);
        }

        private void AutoTag_Click(object sender, EventArgs e)
        {
            Forms.InputBoxDialog tInputBox = new Forms.InputBoxDialog();

            Record tRecord = _Collection.GetRecord(this.TreeView.SelectedNode.Text);

            tInputBox.TextField.Text = tRecord.Songs[0].Path.Substring(_Collection.Path.Length + 1);

            if (tInputBox.ShowDialog(this) != DialogResult.OK || tInputBox.TextField.Text == "")
                return;

            try
            {
                tRecord.AutoTagFromFileName(tInputBox.TextField.Text, _Collection.Path);

                tRecord.UpdateForeColors();
            }
            catch { MessageBox.Show("An Error occured durion AutoTag." + Environment.NewLine + "Please verify your specified File Structure", "Error"); }
        }


        private void FreeDBQuery_Click(object sender, EventArgs e)
        {
            Record tRecord = _Collection.GetRecord(this.TreeView.SelectedNode.Text);

            if (tRecord.QueryFreeDB(true))
                tRecord.UpdateForeColors();
        }

        private void StoreImages()
        {
            this.DisableButtons();

            Picture tPicture;

            foreach (Record tRecord in _Collection.Records)
            {
                if (tRecord.Pictures.Count == 1 && tRecord.Songs[0].Pictures.Count == 0)
                {
                    tPicture = tRecord.Pictures[0];

                    tRecord.SavePictureToTag(tPicture);
                }
            }

            this.EnableButtons();
        }

        private void StoreImage()
        {
            Record tRecord = _Collection.GetRecord(_SelectedNode.Parent.Parent.Text);

            Picture tPicture = tRecord.GetPicture(_SelectedNode.Text);

            this.DisableButtons();

            tRecord.SavePictureToTag(tPicture);

            this.EnableButtons();
        }

        private void StoreImage_Click(object sender, EventArgs e)
        {
            switch ((NodeType)this.TreeView.SelectedNode.Tag)
            {
                case NodeType.Collection:

                    _Thread = new Thread(StoreImages);
                    _Thread.Start();
                    break;

                case NodeType.Picture:

                    _Thread = new Thread(StoreImage);
                    _Thread.Start();
                    break;
            }
        }

        private void ExtractImages()
        {
            string tImagePath;

            Record tRecord;

            this.DisableButtons();

            for (int i = 0; i < _Collection.Records.Count; i++)
            {
                tRecord = _Collection.Records[i];

                tImagePath = System.IO.Path.Combine(tRecord.Path, tRecord.Artist + " - " + tRecord.Title + ".jpg");

                int j = 0;

                while (j < tRecord.Songs.Count)
                {
                    if (tRecord.Songs[j].Pictures.Count > 0)
                    {
                        tRecord.Songs[j].SaveID3PictureToImage(tRecord.Songs[j].Pictures[0], tImagePath);
                        j = tRecord.Songs.Count;
                    }
                    else
                        j++;
                }
            }

            _Collection.ReadDirectory();
            this.FillTreeview();

            this.EnableButtons();
        }

        private void ExtractImage_Click(object sender, EventArgs e)
        {
            string tImagePath;

            Record tRecord;
            Song tSong;

            switch ((NodeType)this.TreeView.SelectedNode.Tag)
            {
                case NodeType.Collection:

                    _Thread = new Thread(ExtractImages);
                    _Thread.Start();
                    break;

                case NodeType.Song:

                    tRecord = _Collection.GetRecord(_SelectedNode.Parent.Parent.Text);
                    tSong = tRecord.GetSong(_SelectedNode.Text);

                    if (tSong.Pictures.Count == 0)
                    {
                        MessageBox.Show("Song has no embedded Pictures.");
                        return;
                    }

                    tImagePath = System.IO.Path.Combine(tRecord.Path, tRecord.Artist + " - " + tRecord.Title + ".jpg");

                    if (System.IO.File.Exists(tImagePath))
                    {
                        MessageBox.Show(tImagePath + " exists already.");
                        return;
                    }

                    try
                    {
                        tSong.SaveID3PictureToImage(tSong.Pictures[0], tImagePath);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Could not extract image." + Environment.NewLine + ex.Message);
                        return;
                    }

                    tRecord.ReadDirectory();
                    tRecord.UpdateForeColors();
                    break;
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.TreeView.SelectedNode == null)
                return;

            Record tRecord;

            switch ((NodeType)this.TreeView.SelectedNode.Tag)
            {
                case NodeType.Collection:

                    MessageBox.Show("Deleting the complete Collection is not supported.");
                    break;

                case NodeType.Record:

                    this.DisposePictureBoxImage();

                    tRecord = _Collection.GetRecord(this.TreeView.SelectedNode.Text);

                    _Collection.Records.Remove(tRecord);
                    tRecord.Delete();

                    break;

                case NodeType.Song:

                    tRecord = _Collection.GetRecord(this.TreeView.SelectedNode.Parent.Parent.Text);

                    Song tSong = tRecord.GetSong(this.TreeView.SelectedNode.Text);

                    tRecord.Songs.Remove(tSong);
                    tSong.Delete(true);
                    tRecord.ReadDirectory();
                    break;

                case NodeType.Picture:

                    this.DisposePictureBoxImage();

                    tRecord = _Collection.GetRecord(this.TreeView.SelectedNode.Parent.Parent.Text);

                    Picture tPicture = tRecord.GetPicture(this.TreeView.SelectedNode.Text);

                    tRecord.Pictures.Remove(tPicture);
                    tPicture.Delete(false);

                    GC.Collect();
                    GC.SuppressFinalize(tPicture);

                    tRecord.ReadDirectory();
                    
                    break;

                case NodeType.Info:

                    tRecord = _Collection.GetRecord(this.TreeView.SelectedNode.Parent.Parent.Text);

                    Info tInfo = tRecord.GetInfo(this.TreeView.SelectedNode.Text);

                    tRecord.Infos.Remove(tInfo);
                    tInfo.Delete(false);
                    tRecord.ReadDirectory();
                    break;
            }
        }

        private void SaveCollectionTags()
        {
            _Collection.SaveTags(_PropertyLabel, _PropertyValue);
        }

        private void SaveRecordTags()
        {
            _Collection.GetRecord(_DirPath).SaveTags();
        }

        private void SaveSongTags()
        {
            Record tRecord = _Collection.GetRecord(_DirPath);

            tRecord.GetSong(_FilePath).SaveTags();

            tRecord.UpdateForeColors();
        }

        private void PropertyGrid_ValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            switch ((NodeType)_SelectedNode.Tag)
            {
                case NodeType.Collection:

                    if (MessageBox.Show(String.Format("Rename {0} Field of all Records to {1}?",
                        e.ChangedItem.Label, e.ChangedItem.Value), "Rename", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        switch (e.ChangedItem.Label.ToString())
                        {
                            case "Artist": _Collection.Artist = e.OldValue.ToString(); break;
                            case "Label": _Collection.Label = e.OldValue.ToString(); break;
                            case "Comment": _Collection.Comment = e.OldValue.ToString(); break;
                            case "Genre": _Collection.Genre = e.OldValue.ToString(); break;
                        }

                        return;
                    }

                    _PropertyLabel = e.ChangedItem.Label.ToString();
                    _PropertyValue = e.ChangedItem.Value.ToString();

                    _Thread = new Thread(SaveCollectionTags);
                    _Thread.Start();

                    break;

                case NodeType.Record:

                    if (e.ChangedItem.Label == "Artist")
                    {
                        if (MessageBox.Show(String.Format("Rename Song Artists of all Songs to {0}, too?",
                            e.ChangedItem.Value, e.ChangedItem.Value), "Rename", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            Record tRecord = _Collection.GetRecord(this.TreeView.SelectedNode.Text);

                            foreach (Song tSubSong in tRecord.Songs)
                                tSubSong.Artist = tRecord.Artist;
                        }
                    }

                    _DirPath = this.TreeView.SelectedNode.Text;
                    _PropertyLabel = e.ChangedItem.Label.ToString();
                    _PropertyValue = e.ChangedItem.Value.ToString();

                    _Thread = new Thread(SaveRecordTags);
                    _Thread.Start();

                    break;

                case NodeType.Song:

                    _DirPath = this.TreeView.SelectedNode.Parent.Parent.Text;
                    _FilePath = this.TreeView.SelectedNode.Text;

                    _Thread = new Thread(SaveSongTags);
                    _Thread.Start();

                    break;
            }
        }

        public void UpdateStatus(int pValue, int pMax, string pInfoText)
        {
            if (this.InvokeRequired)
                this.Invoke(new Utilities.UpdateStatusDelegate(UpdateStatus), new object[] { pValue, pMax, pInfoText });
            else
            {
                pValue = pValue > pMax ? pMax : pValue;

                this.ProgressBar.Maximum = pMax;
                this.ProgressBar.Value = pValue;
                                
                this.Statusbar.Text = String.Format("{0}/{1} :: {2}", pValue.ToString(), pMax.ToString(), pInfoText);
                this.statusStrip1.Refresh();

                //this.Refresh();
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                if (Directory.Exists(((string[])e.Data.GetData(DataFormats.FileDrop))[0]) && _DropAllowed)
                    e.Effect = DragDropEffects.Link;
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {
            string[] tDirs = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (tDirs.Length > 1)
            {
                MessageBox.Show("Multiple Directories are not supported.");
                return;
            }

            if (Directory.Exists(tDirs[0]) == false)
                return;

            _SelectedSourceDir = Settings.SelectedSourceDir;

            Settings.SourceDirs.Add(tDirs[0]);
            Settings.SelectedSourceDir = Settings.SourceDirs.Count - 1;

            this.ReadSourceDirectory_Click(sender, e);
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            TreeNode tSelectedNode = this.TreeView.SelectedNode;

            switch (e.KeyChar)
            {
                case (char)10:
                case (char)13:

                    if (tSelectedNode.IsExpanded)
                        tSelectedNode.Collapse(true);
                    else
                        tSelectedNode.Expand();
                    break;
            }
        }

        private void SetStartText()
        {
            string[] tWelcome = new string[] {
                "Hello World", "Organize Your Music, Bitch",
                "Music doesn't lie. If there is something to be changed in this world, then it can only happen through music. (Jimmy Hendrix)", 
                "Music is everybody's possession. It's only publishers who think that people own it. (John Lennon)", 
                "When words leave off, music begins. (Heinrich Heine)", 
                "I love putting the music together. It's like art. (Erykah Badu)", 
                "If it's illegal to rock and roll, throw my ass in jail! (Kurt Cobain)", 
                "Jazz is about being in the moment. (Herbie Hancock)", 
                "Whoever controls the media, controls the mind. (Jim Morrison)", 
                };

            this.Statusbar.Text = tWelcome[new System.Random().Next(0, tWelcome.Length)];
        }

        private void SetToolTips()
        {
            this.toolTip.SetToolTip(this.button_Settings, "Settings" + Environment.NewLine + Environment.NewLine +
                "Source:\t\t" + Settings.SourceDir + Environment.NewLine + "Destination:\t" + Settings.DestinationDir +
                Environment.NewLine + "File Structure:\t" + Settings.FileStructure + Environment.NewLine +
                "Info Filetypes:\t" + Settings.InfoTypes);

            this.toolTip.SetToolTip(this.button_ReadSourceDirectory, "Read Source Directory" + Environment.NewLine +
                Environment.NewLine + Settings.SourceDir);

            this.toolTip.SetToolTip(this.button_Filter, "Filter" + Environment.NewLine + Environment.NewLine +
                "Bitrate:\t\t" + Filter.Bitrate.Min + " - " + Filter.Bitrate.Max + Environment.NewLine +
                "Year:\t\t" + Filter.Year.Min + " - " + Filter.Year.Max + Environment.NewLine +
                "Duration:\t" + Filter.Duration.Min + " - " + Filter.Duration.Max + Environment.NewLine +
                "Artist:\t" + Filter.Artist + Environment.NewLine + "Label:\t" + Filter.Label);
        }
    }
}