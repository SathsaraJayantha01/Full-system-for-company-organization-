using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class RemainingLeavesForm : Form
    {
        // Database connection string (update with your actual database details)
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        // Constants for leave limits
        private const int TotalAnnualLeaves = 14;
        private const int TotalCasualLeaves = 7;
        private const int MonthlyShortLeaves = 2;

        public RemainingLeavesForm()
        {
            InitializeComponent();
            btnSearch.Click += btnSearch_Click; // Link the Search button click event
        }

        private void RemainingLeavesForm_Load(object sender, EventArgs e)
        {
        }

        // btnSearch Click Event Handler
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the Employee Number from the textbox
            string employeeNumber = txtEMP.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(employeeNumber))
            {
                MessageBox.Show("Please enter an Employee Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fetch and calculate remaining leaves
            CalculateRemainingLeaves(employeeNumber);
        }

        // Method to calculate and display remaining leaves
        private void CalculateRemainingLeaves(string employeeNumber)
        {
            int usedAnnualLeaves = 0;
            int usedCasualLeaves = 0;
            int usedShortLeaves = 0;

            // Define the SQL query to fetch leaves for the employee
            string query = @"
                SELECT LeaveType, LeaveDate 
                FROM Leaves 
                WHERE EmployeeNumber = @EmployeeNumber";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Count the leaves based on LeaveType
                        while (reader.Read())
                        {
                            string leaveType = reader["LeaveType"].ToString();
                            DateTime leaveDate = Convert.ToDateTime(reader["LeaveDate"]);

                            switch (leaveType)
                            {
                                case "Annual":
                                    usedAnnualLeaves++;
                                    break;
                                case "Casual":
                                    usedCasualLeaves++;
                                    break;
                                case "Short":
                                    // Check if the leave was taken this month
                                    if (leaveDate.Month == DateTime.Now.Month && leaveDate.Year == DateTime.Now.Year)
                                    {
                                        usedShortLeaves++;
                                    }
                                    break;
                            }
                        }
                    }
                }

                // Calculate remaining leaves
                int remainingAnnualLeaves = TotalAnnualLeaves - usedAnnualLeaves;
                int remainingCasualLeaves = TotalCasualLeaves - usedCasualLeaves;
                int remainingShortLeaves = MonthlyShortLeaves - usedShortLeaves;

                // Display the remaining leaves in labels
                lblAnnual.Text = $"Remaining Annual Leaves: {remainingAnnualLeaves}";
                lblCasual.Text = $"Remaining Casual Leaves: {remainingCasualLeaves}";
                lblShort.Text = $"Remaining Short Leaves (this month): {remainingShortLeaves}";
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
