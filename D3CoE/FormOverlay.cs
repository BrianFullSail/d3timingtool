using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;

namespace D3CoE
{
    public partial class FormOverlay : Form
    {
        public static double i = 40;
        public static double n = 40;
        RECT rect;

        public const string WINDOW_NAME = "Diablo III";
        private IntPtr handle = FindWindow(null, WINDOW_NAME);

        public struct RECT
        {
            public int left, top, right, bottom;
        }

        Graphics g;
        Pen myPen = new Pen(Color.Red);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowsName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        public FormOverlay()
        {
            InitializeComponent();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            
            this.BackColor = Color.Bisque;
            this.TransparencyKey = Color.Bisque;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            GetWindowRect(handle, out rect);
            this.Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            this.Top = rect.top;
            this.Left = rect.left;

        }

        private void FormOverlay_Paint(object sender, PaintEventArgs e)
        {
            
            g = e.Graphics;
            g.DrawRectangle(myPen, 1195, 1125, 170, 170);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i--;
            n++;
            label1.Text = i.ToString("0:0") + " Seconds";
            if(n >= 0 && n < 40)
            {;
                label1.ForeColor = Color.Blue;
                if (i == 0)
                {
                    i =40;
                }
            }
            else if (n > 39 && n < 80)
            {
                label1.ForeColor = Color.Gray;
                if (i == 0)
                {
                    i =40;
                }
            }
            else if(n > 79)
            {
                label1.ForeColor = Color.Green;
                if (i == 0)
                {
                    i =40;
                }
                if(n == 120)
                {
                    n = 0;
                }
            }
        }

    }
}
