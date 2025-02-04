using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class DefineRoasterForm : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        public DefineRoasterForm()
        {
            InitializeComponent();
        }

        private void DefineRoasterForm_Load(object sender, EventArgs e)
        {
            // Load Employee Numbers into the ComboBox on form load
            LoadEmployeeNumbers();
        }

        // Method to load EmployeeNumbers into the ComboBox
        private void LoadEmployeeNumbers()
        {
            string query = "SELECT EmployeeNumber FROM Users";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True")
)
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbEmployeeNumber.Items.Clear(); // Clear existing items

                        while (reader.Read())
                        {
                            string employeeNumber = reader["EmployeeNumber"].ToString();
                            cmbEmployeeNumber.Items.Add(employeeNumber);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Employee Numbers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button click event to save Roaster data
        private void btnSaveRoaster_Click(object sender, EventArgs e)
        {
            // Validate that an EmployeeNumber is selected
            if (cmbEmployeeNumber.SelectedItem == null)
            {
                MessageBox.Show("Please select an Employee Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string employeeNumber = cmbEmployeeNumber.SelectedItem.ToString();
            DateTime startTime = dtpStartTime.Value;
            DateTime endTime = dtpEndTime.Value;

            // Check if the EndTime is later than the StartTime
            if (endTime <= startTime)
            {
                MessageBox.Show("End Time must be later than Start Time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveRoaster(employeeNumber, startTime, endTime);
        }

        // Method to save Roaster details into the database
        private void SaveRoaster(string employeeNumber, DateTime startTime, DateTime endTime)
        {
            string query = @"
                INSERT INTO Roaster (EmployeeNumber, StartTime, EndTime)
                VALUES (@EmployeeNumber, @StartTime, @EndTime)";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    cmd.Parameters.AddWithValue("@StartTime", startTime);
                    cmd.Parameters.AddWithValue("@EndTime", endTime);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Roaster saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving roaster: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to clear all fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbEmployeeNumber.SelectedIndex = -1;
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
        }
    }
}
