using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bees_management_system
{
    public partial class Form1 : Form
    {
        private Queen queen;

        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Collecting nectar", "Honey production" });
            workers[1] = new Worker(new string[] { "Eggs care", "Teaching young bees" });
            workers[2] = new Worker(new string[] { "Keeping the hive", "Patrol with stings" });
            workers[3] = new Worker(new string[] { "Collecting nectar", "Honey production", "Eggs care", "Teaching young bees", "Keeping the hive", "Patrol with stings" });
            queen = new Queen(workers);
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }

        private void assignJob_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value) == false)
                MessageBox.Show("There aren't any available bees to do this job. '" + workerBeeJob.Text + "' cannot be done during this shift.", "The queen of bees says...");
            else
                MessageBox.Show("'" + workerBeeJob.Text + "' will be finished in " + shifts.Value + " shifts.", "The queen of bees says...");
        }
    }
}
