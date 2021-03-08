using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Drawing.Imaging;

namespace TaskManager
{
    class FindProcesscs
    {
        public List<ProcessInfo> processList { get; set; }
        public List<string> processhwnd = new List<string>();
        int nX, nY, nX2, nY2;
        int nWidth, nHeight;

        public class ProcessInfo
        {
            public string processName { get; set; }
            public System.Windows.Media.ImageSource processIcon { get; set; }
            public System.Windows.Media.ImageSource windowpicture { get; set; }


            
        }
       
        
        public List<ProcessInfo> getProcessInfo()
        {
           
            processList = new List<ProcessInfo>();
            Process[] ps = Process.GetProcesses();
            foreach (Process pp in ps)
            {
                if (pp.MainWindowHandle != IntPtr.Zero && pp.MainWindowTitle !="")
                {
                    Icon sys = Icon.ExtractAssociatedIcon(pp.MainModule.FileName);
                    processhwnd.Add(pp.MainWindowHandle.ToString());
                    //try
                    //{
                        processList.Add(new ProcessInfo() { processName = pp.ProcessName,
                            processIcon = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(sys.Handle, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions()),
                           });
                    //}
                    //catch (Exception)
                    //{
                    //}
                    Console.WriteLine(pp.MainWindowTitle);


                }
            }

            return processList;
        }

        [DllImport("user32.dll")]
        public static extern Boolean GetWindowRect(IntPtr hWnd, ref Rectangle bounds);

        public void CaptureWindow()
        {
            /* 取得目標視窗的 Handle
             * 需要加上 using System.Diagnostics;
             */
            //Process[] process = Process.GetProcessesByName("notepad");

            /* 取得該視窗的大小與位置 */
            Rectangle bounds = new Rectangle();


            GetWindowRect((IntPtr)4458304,ref bounds);

            /* 抓取截圖 */
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            Graphics gfx = Graphics.FromImage(screenshot);
            gfx.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);

            /* 利用 PictureBox 顯示出來 */
            
        }
    }
}
 

