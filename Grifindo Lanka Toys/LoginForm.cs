using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class LoginForm : Form
    {
        // Define the connection string and SQL components
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");
        private SqlCommand cmd;

        // Variables to store user details
        public static string loggedInUser, UType;

        public LoginForm()
        {
            InitializeComponent();
        }

        // Method to clear input fields
        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = 0;
            txtUsername.Focus();
        }

        // Form Load event to populate the ComboBox
        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("--Select--");
            cmbRole.Items.Add("Employee");
            cmbRole.Items.Add("Admin");
            cmbRole.SelectedIndex = 0; // Set default selection
        }

        // Event handler for the Login button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input
                if (cmbRole.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please fill all fields and select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fetching user inputs
                string employeeNumber = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                UType = cmbRole.SelectedItem.ToString();

                // Validate login credentials using EmployeeNumber instead of RealName
                if (ValidateLogin(employeeNumber, password, UType))
                {
                    // Show the welcome message with the RealName
                    MessageBox.Show($"Welcome, {loggedInUser}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load the appropriate dashboard based on the selected role
                    if (UType == "Admin")
                    {
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.Show();
                    }
                    else if (UType == "Employee")
                    {
                        EmployeeDashboard employeeDashboard = new EmployeeDashboard();
                        employeeDashboard.Show();
                    }

                    this.Hide(); // Hide the login form upon successful login
                }
                else
                {
                    MessageBox.Show("Unauthorized Access Denied!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while logging in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to validate user credentials against the database using EmployeeNumber
        private bool ValidateLogin(string employeeNumber, string password, string role)
        {
            bool isValid = false;

            try
            {
                conn.Open();

                // Use a parameterized query to prevent SQL injection
                string query = "SELECT RealName FROM Users WHERE EmployeeNumber = @employeeNumber AND Password = @password AND Role = @role";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@employeeNumber", employeeNumber);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Fetch the RealName if credentials are valid
                    loggedInUser = reader["RealName"].ToString();
                    isValid = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while validating credentials: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close(); // Ensure connection is closed
            }

            return isValid;
        }

        // Event handler for the Clear button
        private void btnClose_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void checkPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            txtPassword.UseSystemPasswordChar = !checkPassword.Checked;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: Handle role selection changes here
        }
    }
}
