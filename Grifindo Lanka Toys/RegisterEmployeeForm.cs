using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class RegisterEmployeeForm : Form
    {
        // Database connection string
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        public RegisterEmployeeForm()
        {
            InitializeComponent();
        }

        // Form Load Event
        private void RegisterEmployeeForm_Load(object sender, EventArgs e)
        {
            // Generate a new Employee Number when the form loads
            GenerateEmployeeNumber();

            // Populate the roles combo box
            PopulateRolesComboBox();
        }

        // Method to generate a new Employee Number
        private void GenerateEmployeeNumber()
        {
            string latestEmployeeNumber = "";
            int newEmployeeNumber = 1;

            // SQL query to fetch the latest EmployeeNumber from the Users table
            string query = "SELECT TOP 1 EmployeeNumber FROM Users ORDER BY EmployeeNumber DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        latestEmployeeNumber = result.ToString();
                        // Extract the numeric part from the EmployeeNumber (e.g., "EMP-01" -> 1)
                        int.TryParse(latestEmployeeNumber.Replace("EMP-", ""), out newEmployeeNumber);
                        newEmployeeNumber++;
                    }
                }

                // Generate the new EmployeeNumber (e.g., "EMP-02")
                lblEMP.Text = $"EMP-{newEmployeeNumber:D2}";
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to populate the roles combo box
        private void PopulateRolesComboBox()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("--Select--");
            cmbRole.Items.Add("Employee");
            cmbRole.Items.Add("Admin");
            cmbRole.SelectedIndex = 0; // Set default to "--Select--"
        }

        // Method to register a new employee
        private void txtRegister_Click(object sender, EventArgs e)
        {
            string employeeNumber = lblEMP.Text.Trim();
            string realName = txtRealname.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            // Validation checks
            if (string.IsNullOrEmpty(realName) || string.IsNullOrEmpty(password) || role == "--Select--" || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert data into the Users table
            string query = "INSERT INTO Users (EmployeeNumber, RealName, Password, Role) VALUES (@EmployeeNumber, @RealName, @Password, @Role)";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    cmd.Parameters.AddWithValue("@RealName", realName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Generate a new Employee Number for the next registration
                        GenerateEmployeeNumber();

                        // Clear the form fields after successful registration
                        txtRealname.Clear();
                        txtPassword.Clear();
                        cmbRole.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Failed to register employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button click event to close the form
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resEx = MessageBox.Show("Are you sure you want to Exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resEx == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkPassword.Checked;
        }
    }
}
