using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Grifindo_Lanka_Toys
{
    public partial class LeaveStatusForm : Form
    {
        // Database connection string
        private SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True");


        public LeaveStatusForm()
        {
            InitializeComponent();
            btnSearch.Click += btnSearch_Click; // Link the Search button
            dataGridView1.CellContentClick += dataGridView1_CellContentClick; // Link the Delete button click event
        }

        private void LeaveStatusForm_Load(object sender, EventArgs e)
        {
        }

        // btnSearch Click Event Handler
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string employeeNumber = txtEMP.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(employeeNumber))
            {
                MessageBox.Show("Please enter an Employee Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load data into DataGridView
            LoadLeaveData(employeeNumber);
        }

        // Method to load leave data and add a Delete button
        private void LoadLeaveData(string employeeNumber)
        {
            string query = @"
                SELECT LeaveID, LeaveType, LeaveDate, Status 
                FROM Leaves 
                WHERE EmployeeNumber = @EmployeeNumber";

            try
            {
                dataGridView1.DataSource = null;

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;

                        // Add a Delete button column if it doesn't already exist
                        if (dataGridView1.Columns.Contains("Delete"))
                        {
                            dataGridView1.Columns.Remove("Delete");
                        }

                        DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                        {
                            HeaderText = "Action",
                            Name = "Delete",
                            Text = "Delete",
                            UseColumnTextForButtonValue = true
                        };

                        dataGridView1.Columns.Add(deleteButtonColumn);
                    }
                    else
                    {
                        MessageBox.Show("No records found for the specified Employee Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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

        // Handle Delete button click event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is the Delete button
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                int leaveId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["LeaveID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this leave record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteLeaveRecord(leaveId);

                    // Refresh the data grid
                    string employeeNumber = txtEMP.Text.Trim();
                    LoadLeaveData(employeeNumber);
                }
            }
        }

        // Method to delete a leave record from the database
        private void DeleteLeaveRecord(int leaveId)
        {
            string deleteQuery = "DELETE FROM Leaves WHERE LeaveID = @LeaveID";

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KU79D43;Initial Catalog=Grifindo Lanka Toys;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@LeaveID", leaveId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        // Optional: Exit button event handler (if you have an Exit button)
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
