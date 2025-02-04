using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class ApplyLeaveForm : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        private const int MaxAnnualLeaves = 14;
        private const int MaxCasualLeaves = 7;
        private const int MaxShortLeavesPerMonth = 2;

        public ApplyLeaveForm()
        {
            InitializeComponent();
        }

        private void ApplyLeaveForm_Load(object sender, EventArgs e)
        {
            cmbLeaveType.Items.Add("--Select--");
            cmbLeaveType.Items.Add("Annual");
            cmbLeaveType.Items.Add("Casual");
            cmbLeaveType.Items.Add("Short");
            cmbLeaveType.SelectedIndex = 0;

            // Initially hide the timeTime DateTimePicker
            timeTime.Visible = false;
        }

        // Method to clear input fields
        private void ClearFields()
        {
            txtEMP.Clear();
            cmbLeaveType.SelectedIndex = 0;
            txtReason.Clear();
            dateDate.Value = DateTime.Now;
            timeTime.Value = DateTime.Now;
            txtEMP.Focus();

            // Hide the timeTime picker by default
            timeTime.Visible = false;
        }

        // Event handler for ComboBox selection change
        private void cmbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show the timeTime DateTimePicker only if "Short" is selected
            if (cmbLeaveType.SelectedItem.ToString() == "Short")
            {
                timeTime.Visible = true;
            }
            else
            {
                timeTime.Visible = false;
            }
        }

        // Event handler for the Apply button
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEMP.Text))
            {
                MessageBox.Show("Please enter a valid Employee Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEMP.Focus();
                return;
            }

            if (cmbLeaveType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Leave Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLeaveType.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please enter a reason for leave.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return;
            }

            try
            {
                string employeeNumber = txtEMP.Text.Trim();
                string leaveType = cmbLeaveType.SelectedItem.ToString();
                DateTime leaveDate = dateDate.Value;
                string timeSlot = timeTime.Visible ? timeTime.Value.ToString("HH:mm:ss") : null;
                string reason = txtReason.Text.Trim();

                if (!CheckLeaveAvailability(employeeNumber, leaveType, leaveDate, timeSlot))
                    return;

                InsertLeaveApplication(employeeNumber, leaveType, leaveDate, timeSlot, reason);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while applying for leave: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private bool CheckLeaveAvailability(string employeeNumber, string leaveType, DateTime leaveDate, string timeSlot)
        {
            int leaveCount = GetLeaveCount(employeeNumber, leaveType);

            switch (leaveType)
            {
                case "Annual":
                    if (leaveCount >= MaxAnnualLeaves || (leaveDate - DateTime.Now).TotalDays < 7)
                    {
                        MessageBox.Show("Annual Leave limit reached or apply 7 days in advance.", "Validation Error");
                        return false;
                    }
                    break;
                case "Casual":
                    if (leaveCount >= MaxCasualLeaves)
                    {
                        MessageBox.Show("Casual Leave limit reached.", "Validation Error");
                        return false;
                    }
                    break;
                case "Short":
                    if (leaveCount >= MaxShortLeavesPerMonth || timeTime.Value <= DateTime.Now)
                    {
                        MessageBox.Show("Short Leave limit reached or invalid time slot.", "Validation Error");
                        return false;
                    }
                    break;
            }
            return true;
        }

        private void InsertLeaveApplication(string employeeNumber, string leaveType, DateTime leaveDate, string timeSlot, string reason)
        {
            string query = "INSERT INTO Leaves (EmployeeNumber, LeaveType, LeaveDate, TimeSlot, Reason, Status) VALUES (@EmployeeNumber, @LeaveType, @LeaveDate, @TimeSlot, @Reason, 'pending')";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                cmd.Parameters.AddWithValue("@LeaveType", leaveType);
                cmd.Parameters.AddWithValue("@LeaveDate", leaveDate);
                cmd.Parameters.AddWithValue("@TimeSlot", timeSlot ?? DBNull.Value.ToString());
                cmd.Parameters.AddWithValue("@Reason", reason);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Leave applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
        }

        private int GetLeaveCount(string employeeNumber, string leaveType)
        {
            int count = 0;
            try
            {
                string query = "SELECT COUNT(*) FROM Leaves WHERE EmployeeNumber = @EmployeeNumber AND LeaveType = @LeaveType";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    cmd.Parameters.AddWithValue("@LeaveType", leaveType);

                    conn.Open();
                    count = (int)cmd.ExecuteScalar();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking leave count: " + ex.Message);
            }
            return count;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to cancel?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resEx == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
