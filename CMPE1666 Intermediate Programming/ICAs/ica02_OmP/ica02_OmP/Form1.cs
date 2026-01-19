/*
 * Name: Om Patel
 * Assignment: ICA 02-Application Lifecycle, Timeline
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ica02_OmP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Form Constructor
            Trace.WriteLine("Form1 Constructor triggered.");
        }

        //Form Load Event
        private void Form1_Load(object sender, EventArgs e)
        {
            Trace.WriteLine("Form1 Load event triggered.");
        }

        //Form Closing Event
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Trace.WriteLine("Form1 FormClosing event triggered.");
        }

        //Form Activated Event
        private void Form1_Activated(object sender, EventArgs e)
        {
            Trace.WriteLine("Form1 Activated event triggered.");
        }

        //Form Paint Event
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Trace.WriteLine("Form1 Paint event triggered.");
        }

        //Form Closed Event
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Trace.WriteLine("Form1 FormClosed event triggered.");
        }

        //Form Deactivate Event
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Trace.WriteLine("Form1 Deactivate event triggered.");
        }

        //Form Shown Event
        private void Form1_Shown(object sender, EventArgs e)
        {
            Trace.WriteLine("Form1 Shown event triggered.");
        }  
    }
}
