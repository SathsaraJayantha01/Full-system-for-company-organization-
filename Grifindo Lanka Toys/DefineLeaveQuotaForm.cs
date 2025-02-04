using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class DefineLeaveQuotaForm : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        public DefineLeaveQuotaForm()
        {
            InitializeComponent();
        }

        private void DefineLeaveQuotaForm_Load(object sender, EventArgs e)
        {
            // Initialize default values for leave quotas
            numAnnualLeaves.Value = 14;
            numCasualLeaves.Value = 7;
            numShortLeaves.Value = 2;
        }

        // Method to clear all fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeNumber.Clear();
            numAnnualLeaves.Value = 14;
            numCasualLeaves.Value = 7;
            numShortLeaves.Value = 2;
        }

        // Method to save or update leave quotas in the database
        private void btnSaveQuota_Click(object sender, EventArgs e)
        {
            string employeeNumber = txtEmployeeNumber.Text.Trim();

            // Validate employee number
            if (string.IsNullOrEmpty(employeeNumber))
            {
                MessageBox.Show("Please enter a valid Employee Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate that the employee exists
            if (!EmployeeExists(employeeNumber))
            {
                MessageBox.Show("Employee does not exist. Please enter a valid Employee Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int annualLeaves = (int)numAnnualLeaves.Value;
            int casualLeaves = (int)numCasualLeaves.Value;
            int shortLeaves = (int)numShortLeaves.Value;

            // Save or update leave quotas
            SaveOrUpdateLeaveQuota(employeeNumber, annualLeaves, casualLeaves, shortLeaves);
        }

        // Method to check if the employee exists in the database
        private bool EmployeeExists(string employeeNumber)
        {
            // Assuming 'Users' table contains 'EmployeeNumber' field
            string query = "SELECT COUNT(*) FROM Users WHERE EmployeeNumber = @EmployeeNumber";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to save or update leave quotas in the database
        private void SaveOrUpdateLeaveQuota(string employeeNumber, int annualLeaves, int casualLeaves, int shortLeaves)
        {
            string query = @"
                IF EXISTS (SELECT * FROM LeaveQuota WHERE EmployeeNumber = @EmployeeNumber)
                BEGIN
                    UPDATE LeaveQuota
                    SET AnnualLeaves = @AnnualLeaves, CasualLeaves = @CasualLeaves, ShortLeaves = @ShortLeaves
                    WHERE EmployeeNumber = @EmployeeNumber
                END
                ELSE
                BEGIN
                    INSERT INTO LeaveQuota (EmployeeNumber, AnnualLeaves, CasualLeaves, ShortLeaves)
                    VALUES (@EmployeeNumber, @AnnualLeaves, @CasualLeaves, @ShortLeaves)
                END";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    cmd.Parameters.AddWithValue("@AnnualLeaves", annualLeaves);
                    cmd.Parameters.AddWithValue("@CasualLeaves", casualLeaves);
                    cmd.Parameters.AddWithValue("@ShortLeaves", shortLeaves);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Leave quotas saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields after successful save
                    btnClear_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving leave quotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
