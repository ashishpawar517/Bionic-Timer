using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Timers;

namespace Bionic_Timer
{
   

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        // this properties are used for keep the Form on the top

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        //For timer 
        private System.TimeSpan tSpan; 

        public Form1()

        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            tSpan = new System.TimeSpan(0, 2, 0, 0);
            label1.Text = tSpan.Hours+" "+tSpan.Minutes+" "+tSpan.Seconds;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           // SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //label1.Text = timer.ToString();
            //System.TimeSpan second = new System.TimeSpan(0, 0, 0, 1);
            //System.TimeSpan curr = tSpan - second;
            //label1.Text = curr.ToString(); 
            //this.tSpan = curr;
            //this.tSpan = tSpan - new System.TimeSpan(0, 0, 1, 0);

            tSpan = tSpan.Subtract(TimeSpan.FromSeconds(1));
            label1.Text = tSpan.ToString(@"hh\:mm\:ss");
            //label1.Text = tSpan.Hours + " " + tSpan.Minutes + " " + tSpan.Seconds;
            // MessageBox.Show("1 second");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.TimeSpan tSpan = new System.TimeSpan(0, 1, 0, 0);
            timer.Start();
        }
        
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
