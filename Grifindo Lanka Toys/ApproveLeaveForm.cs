using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class ApproveLeaveForm : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        public ApproveLeaveForm()
        {
            InitializeComponent();

            dataGridView2.DataError += dataGridView2_DataError;

            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
        }

        private void ApproveLeaveForm_Load(object sender, EventArgs e)
        {
            LoadLeavesData();
        }

        // Method to load leaves data into the DataGridView
        private void LoadLeavesData()
        {
            string query = @"
                SELECT 
                    l.LeaveID, 
                    l.EmployeeNumber, 
                    u.RealName AS Name, 
                    l.LeaveType, 
                    l.LeaveDate, 
                    l.Status 
                FROM Leaves l
                INNER JOIN Users u ON l.EmployeeNumber = u.EmployeeNumber
                WHERE l.Status IN ('Pending', 'Approved', 'Rejected')";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.Columns.Clear();

                    // Add columns manually
                    dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "LeaveID",
                        HeaderText = "Leave ID",
                        Name = "LeaveID",
                        ReadOnly = true
                    });

                    dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "EmployeeNumber",
                        HeaderText = "Employee Number",
                        Name = "EmployeeNumber",
                        ReadOnly = true
                    });

                    // New Name column
                    dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Name",
                        HeaderText = "Name",
                        Name = "Name",
                        ReadOnly = true
                    });

                    dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "LeaveType",
                        HeaderText = "Leave Type",
                        Name = "LeaveType",
                        ReadOnly = true
                    });

                    dataGridView2.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "LeaveDate",
                        HeaderText = "Leave Date",
                        Name = "LeaveDate",
                        ReadOnly = true
                    });

                    // Add ComboBoxColumn for Status
                    DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
                    {
                        DataPropertyName = "Status",
                        HeaderText = "Status",
                        Name = "Status",
                        DataSource = new string[] { "Pending", "Approve", "Reject" },
                        DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                        FlatStyle = FlatStyle.Flat
                    };
                    dataGridView2.Columns.Add(statusColumn);

                    // Add Button Column for Save
                    DataGridViewButtonColumn saveButtonColumn = new DataGridViewButtonColumn
                    {
                        HeaderText = "Save",
                        Name = "SaveButton",
                        Text = "Save",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridView2.Columns.Add(saveButtonColumn);

                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // DataError event handler to handle ComboBox errors
        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Suppress the error message
            e.ThrowException = false;
        }

        // CellContentClick event handler to handle Save button clicks
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the Save button column
            if (e.ColumnIndex == dataGridView2.Columns["SaveButton"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                if (row.Cells["LeaveID"].Value != null)
                {
                    string leaveID = row.Cells["LeaveID"].Value.ToString();
                    string newStatus = row.Cells["Status"].Value?.ToString();

                    if (!string.IsNullOrEmpty(newStatus))
                    {
                        UpdateLeaveStatus(leaveID, newStatus);
                        MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLeavesData(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        // Method to update the leave status in the database
        private void UpdateLeaveStatus(string leaveID, string newStatus)
        {
            string query = "UPDATE Leaves SET Status = @Status WHERE LeaveID = @LeaveID";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@LeaveID", leaveID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
