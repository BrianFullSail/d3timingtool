using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static D3CoE.FormOverlay;

namespace D3CoE
{
    public partial class Form1 : Form
    {
        FormOverlay frm = new FormOverlay();

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                frm.Show();
                FormOverlay.timer1.Start();
                FormOverlay.i = 40;
                FormOverlay.n = 0;
            }
            else
            {
                frm.Hide();
                FormOverlay.timer1.Stop();
                FormOverlay.i = 40;
                FormOverlay.n = 0;
            }
        }
    }
}
