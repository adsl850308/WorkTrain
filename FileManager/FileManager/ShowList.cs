using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace FileManager
{
    class ShowList
    {
        public delegate void DelAddItem(string filename, string filePath, int index);
        public DelAddItem addItem;
        public delegate void DelAddIcon(string filename, string filePath, Icon fileicon);
        public DelAddIcon addIcon;
        public delegate void DelClean();
        public DelClean cleanView;

        private string curPath = null;
        private FindFolder findFolder = new FindFolder();

        //列出所有當前目錄file
        public void ShowItem(string dirPath)
        {

            if (dirPath == "電腦")
            {
                return;
            }
            else
            {
                try
                {
                    List<DirectoryInfo> dirinfo = findFolder.GetFolder(dirPath);
                    List<FileInfo> fileinfo = findFolder.GetFILE(dirPath);
                    foreach (DirectoryInfo d in dirinfo)
                    {
                        addItem.Invoke(d.Name, d.FullName, 2);
                    }
                    foreach (FileInfo f in fileinfo)
                    {
                        Icon fileIcon = SystemIcon.GetIconByFileName(f.FullName);
                        addIcon.Invoke(f.Name, f.FullName, fileIcon);
                    }
                }
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public void TreeToList(string path) {
            if (curPath != path)
            {
                cleanView();
                ShowItem(path);
                curPath = path;
            }
        }
        public void OpenFile(string path) {
            if (Directory.Exists(path))
            {
                Console.WriteLine("777777777777777777777777777777");
                cleanView();
                ShowItem(path);
            }
            else {
                try
                {
                    Process.Start(path);
                }
                catch (Exception) {

                }
            }
        }
      
    }
}
