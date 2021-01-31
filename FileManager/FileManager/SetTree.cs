using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace FileManager
{
    class SetTree
    {
        public delegate void DelUpdateTree(TreeNode node);
        public DelUpdateTree updatetree;
        //public delegate void DelRefreshHandler(object sender, TreeViewCancelEventArgs e);
        //public DelRefreshHandler refreshHandler;


        private TreeNode rootNode = new TreeNode("電腦",3,3);
        private TreeNode CNode = new TreeNode("系統保留(C:)",0,0);
        private TreeNode DNode = new TreeNode("新增磁碟(D:)",1,1);
        private FindFolder findFolder = new FindFolder();

        public void initialTree() {
            CNode.Tag = @"C:\";
            DNode.Tag = @"D:\";
            rootNode.Tag = "電腦";
            CNode.Nodes.Add("");
            DNode.Nodes.Add("");
            rootNode.Nodes.Add(CNode);
            rootNode.Nodes.Add(DNode);
            updatetree.Invoke(rootNode);
            
        }
        //產生節點 並替每個節點放個空的節點 實現+號;
       
        public void getDirNodes(string dirPath,TreeNode node) {
            try
            {
                if (node.Text.ToString() == "電腦")
                {
                    return;
                }
                else
                {
                    node.Nodes.Clear();

                    foreach (DirectoryInfo d in findFolder.GetFolder(dirPath).ToArray())
                    {
                        TreeNode dirNode = new TreeNode(d.Name, 2, 2);
                        node.Nodes.Add(dirNode);

                        dirNode.Tag = d.FullName + @"\";
                        //對於是否給 + 號
                        if (getPlus(dirNode.Tag.ToString()) == "GETPLUS")
                        {
                            dirNode.Nodes.Add("");
                        }
                    }
                }
            }
            catch (Exception e) {
                throw;
            }
        }
        private string getPlus(string path)
        {
            //FindFolder newOne = new FindFolder();
            List<DirectoryInfo> dlist = findFolder.GetFolder(path);
            if (dlist != null && dlist.Count > 0)
            {
                return "GETPLUS";
            }
            else
            {
                return "NOPLUS";
            }
        }
        public void RefreshTree(string path, TreeNode node)
        {
            try
            {
                if (node.Tag != null && node.Tag.ToString() == path)
                {
                    getDirNodes(path, node);
                }
                else
                {
                    foreach (TreeNode ss in node.Nodes)
                    {
                        RefreshTree(path, ss);
                    }
                }
            }
            catch (Exception) {

            }
        }

    }
}
