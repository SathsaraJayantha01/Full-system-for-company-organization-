using System;
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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
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
            RegisterEmployeeForm frm = new RegisterEmployeeForm();
            frm.Show();
        }

        private void registerEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterEmployeeForm frm = new RegisterEmployeeForm();
            frm.Show();
        }

        private void approveRejectLeavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApproveLeaveForm frm = new ApproveLeaveForm();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApproveLeaveForm frm = new ApproveLeaveForm();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DefineLeaveQuotaForm frm = new DefineLeaveQuotaForm();
            frm.Show();
        }

        private void defineLeaveQuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineLeaveQuotaForm frm = new DefineLeaveQuotaForm();
            frm.Show();
        }

        private void defineRoasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefineRoasterForm frm = new DefineRoasterForm();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DefineRoasterForm frm = new DefineRoasterForm();
            frm.Show();
        }

        private void viewLeaveReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LeaveReportsForm frm = new LeaveReportsForm();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LeaveReportsForm frm = new LeaveReportsForm();
            frm.Show();
        }
    }
}
