﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class EmployeeDashboard : Form
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH.mm.ss tt");
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure, You want to Exit???",
"Confirm to Exit!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resEx == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplyLeaveForm frm = new ApplyLeaveForm();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeaveStatusForm frm = new LeaveStatusForm();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            RemainingLeavesForm frm = new RemainingLeavesForm();
            frm .Show();
        }

        private void applyForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyLeaveForm frm = new ApplyLeaveForm();
            frm.Show();
        }

        private void viewLeaveStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
           LeaveStatusForm frm = new LeaveStatusForm( );
           frm.Show();
        }

        private void viewRemainingLeavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            RemainingLeavesForm frm = new RemainingLeavesForm();
            frm.Show();
        }

        private void EmployeeDashboard_Load(object sender, EventArgs e)
        {
            lbl.Text = "Welcome to Grifindo Lanka Toys System, " + LoginForm.loggedInUser + "!";
        }

        
    }
}
