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

namespace sistem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void dispetcher() 
        {
            timer1.Interval = 10000;
            timer1.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dispetcher();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var allProcess = from pr in Process.GetProcesses(".")
                             orderby pr.Id
                             select pr;
            foreach (var proc in allProcess)
            {
                string[] arr = { "" + proc.ProcessName, "" + proc.Id + "MB",
                    "" + proc.WorkingSet64 /1000000 + " MB", "" + proc.VirtualMemorySize64 / 1000000 + "MB", "" + proc.MachineName, "" + proc.BasePriority};
                dataGridView1.Rows.Add(arr);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var z = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            foreach (var process in Process.GetProcessesByName(z))
            {
                process.Kill();
            }
        }
    }
}
