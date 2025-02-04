using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class LeaveReportsForm : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        public LeaveReportsForm()
        {
            InitializeComponent();
        }

        private void LeaveReportsForm_Load(object sender, EventArgs e)
        {
            // Set default options for the ComboBoxes
            cmbLeaveType.Items.AddRange(new string[] { "--Select--", "All", "Annual", "Casual", "Short" });
            cmbStatus.Items.AddRange(new string[] { "--Select--", "All", "Pending", "Approved", "Rejected" });

            // Set default selection
            cmbLeaveType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        // Method to generate the report
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string employeeNumber = txtEmployeeNumber.Text.Trim();
            string leaveType = cmbLeaveType.SelectedItem.ToString();
            string status = cmbStatus.SelectedItem.ToString();
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            // Validate the input fields
            if (cmbLeaveType.SelectedIndex == 0 || cmbStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please select valid options for Leave Type and Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fetch and display the filtered data
            LoadLeaveReports(employeeNumber, leaveType, status, startDate, endDate);
        }

        // Method to load filtered leave reports into the DataGridView
        private void LoadLeaveReports(string employeeNumber, string leaveType, string status, DateTime startDate, DateTime endDate)
        {
            string query = "SELECT LeaveID, EmployeeNumber, LeaveType, LeaveDate, Status FROM Leaves WHERE LeaveDate BETWEEN @StartDate AND @EndDate";

            if (!string.IsNullOrEmpty(employeeNumber))
                query += " AND EmployeeNumber = @EmployeeNumber";

            if (leaveType != "All")
                query += " AND LeaveType = @LeaveType";

            if (status != "All")
                query += " AND Status = @Status";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    if (!string.IsNullOrEmpty(employeeNumber))
                        cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);

                    if (leaveType != "All")
                        cmd.Parameters.AddWithValue("@LeaveType", leaveType);

                    if (status != "All")
                        cmd.Parameters.AddWithValue("@Status", status);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvLeaveReports.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to export DataGridView data to CSV
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgvLeaveReports.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "LeaveReports.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // Write the header
                        for (int i = 0; i < dgvLeaveReports.Columns.Count; i++)
                        {
                            sw.Write(dgvLeaveReports.Columns[i].HeaderText);
                            if (i < dgvLeaveReports.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();

                        // Write the data
                        foreach (DataGridViewRow row in dgvLeaveReports.Rows)
                        {
                            for (int i = 0; i < dgvLeaveReports.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                    sw.Write(row.Cells[i].Value.ToString());
                                if (i < dgvLeaveReports.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("CSV file saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Method to clear all filter fields
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            txtEmployeeNumber.Clear();
            cmbLeaveType.SelectedIndex = 0; // Reset to "--Select--"
            cmbStatus.SelectedIndex = 0; // Reset to "--Select--"
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            // Clear the DataGridView
            dgvLeaveReports.DataSource = null;
        }
    }
}
