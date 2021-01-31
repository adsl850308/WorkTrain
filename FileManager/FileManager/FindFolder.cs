using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    class FindFolder
    {
        private List<DirectoryInfo> FolderList = new List<DirectoryInfo>();
        private List<FileInfo> FileList = new List<FileInfo>();

        //這是用來找檔案
        public List<FileInfo> GetFILE(string dirPath) {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                if (FileList != null && FileList.Count > 0)
                {
                    FileList.Clear();
                }
                foreach (FileInfo dChild in dir.GetFiles("*"))
                {
                    Console.WriteLine(dChild.Name);
                    Console.WriteLine(dChild.FullName);
                    FileList.Add(dChild);
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                return FileList;
                throw;
            }
            return FileList;
        }
        //這是用來找資料夾
        public List<DirectoryInfo> GetFolder(string dirPath) {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (FolderList != null && FolderList.Count > 0)
                {
                    FolderList.Clear();
                }
                foreach (DirectoryInfo dChild in dirs)
                {
                    Console.WriteLine(dChild.Name);//列印目錄名
                    Console.WriteLine(dChild.FullName);//列印路徑和目錄名
                    FolderList.Add(dChild);

                }
            }
            catch (Exception e)
            {
                return FolderList;
                throw;
            }
            return FolderList;

        }
        //採用遞迴方式查找
        //public void GetALL(string dirPath)
        //{
        //    DirectoryInfo dir = new DirectoryInfo(dirPath);


        //    foreach (DirectoryInfo d in dir.GetDirectories())
        //    {
        //        if (d.Name == "System Volume Information") {
        //            continue;
        //        }
        //        Console.WriteLine(d.FullName);
        //        GetALL(dir + d.ToString() + @"\");

        //    }
        //    foreach (FileInfo f in dir.GetFiles())
        //    {
        //        Console.WriteLine(f.FullName);
        //    }

        //}
    }  
}
        
    

