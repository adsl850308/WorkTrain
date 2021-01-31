namespace FileManager
{
    partial class Refresh
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Refresh));
            this.directoryTree = new System.Windows.Forms.TreeView();
            this.FileListShow = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directoryTree
            // 
            this.directoryTree.LineColor = System.Drawing.Color.White;
            this.directoryTree.Location = new System.Drawing.Point(9, 10);
            this.directoryTree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.directoryTree.Name = "directoryTree";
            this.directoryTree.Size = new System.Drawing.Size(185, 394);
            this.directoryTree.TabIndex = 0;
            this.directoryTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.directoryTree_AfterCollapse);
            this.directoryTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.directoryTree_BeforeExpand);
            this.directoryTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.directoryTree_AfterExpand);
            this.directoryTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.directoryTree_NodeMouseClick);
            // 
            // FileListShow
            // 
            this.FileListShow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.FileListShow.HideSelection = false;
            this.FileListShow.Location = new System.Drawing.Point(197, 41);
            this.FileListShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FileListShow.Name = "FileListShow";
            this.FileListShow.Size = new System.Drawing.Size(409, 362);
            this.FileListShow.TabIndex = 1;
            this.FileListShow.UseCompatibleStateImageBehavior = false;
            this.FileListShow.View = System.Windows.Forms.View.Details;
            this.FileListShow.ItemActivate += new System.EventHandler(this.FileListShow_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名稱";
            this.columnHeader1.Width = 260;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icone_windows.png");
            this.imageList1.Images.SetKeyName(1, "hdd.png");
            this.imageList1.Images.SetKeyName(2, "folderopened_yellow.png");
            this.imageList1.Images.SetKeyName(3, "mycomputer.png");
            this.imageList1.Images.SetKeyName(4, "crystal_txt.png");
            this.imageList1.Images.SetKeyName(5, "document_xml.png");
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(197, 10);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 26);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(586, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 26);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Refresh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.FileListShow);
            this.Controls.Add(this.directoryTree);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Refresh";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView directoryTree;
        private System.Windows.Forms.ListView FileListShow;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
    }
}

