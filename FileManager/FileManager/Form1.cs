using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FileManager
{
    public partial class Refresh : Form
    {
        private SetTree setTree = new SetTree();
        private ShowList ShowList = new ShowList();
        private List<string> openlist = new List<string>();
        private string lastPath = null;
        

        public Refresh()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //綁定圖片
            directoryTree.ImageList = imageList1;
            FileListShow.SmallImageList = imageList1;
            ShowList.addItem = UpdateList;
            ShowList.addIcon = UpdateList;
            ShowList.cleanView = CleanListView;
            setTree.updatetree = UpdateTreeNode;
            //setTree.refreshHandler += directoryTree_BeforeExpand;
            setTree.initialTree();
        }
        //在richbox 上放圖片
        private void richTextBoxImage(int i,string path) {
            Clipboard.SetDataObject(this.imageList1.Images[i]);
            DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            if (richTextBox1.CanPaste(dataFormat))
            {
                richTextBox1.Text = path;
                richTextBox1.Paste(dataFormat);
            }
        }
        //新增listView上資料夾
        public void UpdateList(string filename,string filePath,int index) {
           ListViewItem item = FileListShow.Items.Add(filename);
            item.Tag = filePath;
            item.ImageIndex = index;
        }
        public void UpdateList(string filename, string filePath,Icon fileicon)
        {
            ListViewItem item = FileListShow.Items.Add(filename);
            imageList1.Images.Add(filename,fileicon);
            item.ImageKey = filename;
            item.Tag = filePath;
        }
        //新增節點
        public void UpdateTreeNode(TreeNode node) {
            directoryTree.Nodes.Add(node);
        }
        //清空listview
        public void CleanListView() {
            FileListShow.Items.Clear();

        }

        private void directoryTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                setTree.getDirNodes(e.Node.Tag.ToString(), e.Node);
            }
            catch (Exception)
            {
            }
        }

        private void directoryTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            openlist.Add(e.Node.Tag.ToString());
            e.Node.Expand();
        }

        //private void directoryTree_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    try
        //    {
        //        Console.WriteLine("hiiiiiiii");
        //        ShowList.TreeToList(e.Node.Tag.ToString());
        //        richTextBoxImage(e.Node.ImageIndex, e.Node.Tag.ToString());
        //        lastPath = e.Node.Tag.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowList.TreeToList(e.Node.Tag.ToString());
        //        richTextBoxImage(e.Node.ImageIndex, e.Node.Tag.ToString());
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void FileListShow_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                if (FileListShow.SelectedItems.Count > 0)
                {
                    string path = FileListShow.SelectedItems[0].Tag.ToString();
                    lastPath= FileListShow.SelectedItems[0].Tag.ToString();
                    ShowList.OpenFile(path);
                    richTextBoxImage(2, path);
                }
            }
            catch (Exception ex)
            {
                ShowList.TreeToList(lastPath);
                richTextBoxImage(2, lastPath);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string refreshpath = lastPath;
                ShowList.OpenFile(refreshpath);
                foreach (string allPath in openlist)
                {
                    setTree.RefreshTree(allPath, directoryTree.Nodes[0]);
                }
               
            }
            catch (Exception) {
                string refreshpath = lastPath;
                ShowList.OpenFile(refreshpath);
                foreach (string allPath in openlist)
                {
                    setTree.RefreshTree(allPath, directoryTree.Nodes[0]);
                }
               

            }
        }

        private void directoryTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            openlist.Remove(e.Node.Tag.ToString());
        }

        private void directoryTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                Console.WriteLine("hiiiiiiii");
                ShowList.TreeToList(e.Node.Tag.ToString());
                richTextBoxImage(e.Node.ImageIndex, e.Node.Tag.ToString());
                lastPath = e.Node.Tag.ToString();
            }
            catch (Exception ex)
            {
                ShowList.TreeToList(e.Node.Tag.ToString());
                richTextBoxImage(e.Node.ImageIndex, e.Node.Tag.ToString());
                MessageBox.Show(ex.Message);
            }
        }
    }
}
