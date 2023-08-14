using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class UpdatePassForm : Form
    {
        private List<string> selectedIds;

        public UpdatePassForm(List<string> ids)
        {
            InitializeComponent();
            selectedIds = ids;
        }
        // public UpdatePassForm()
        // {
        //InitializeComponent();
        //}

        private void UpdatePassForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newpasswordtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) || (sender as System.Windows.Forms.TextBox).Text.Count(Char.IsLetterOrDigit) == 6)
            {
                e.Handled = true;
            }
        }

        private void updatebtnn_Click(object sender, EventArgs e)
        {
            string newpassword;
            newpassword=  newpasswordtxt.Text;

            if (!string.IsNullOrEmpty(newpassword))
            {
                if (MessageBox.Show("Do you want to update passwords?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = "Data source=DESKTOP-ARDALUS\\MSSQLSERVER01;Initial Catalog=demodb; Integrated Security=true;";
                        conn.Open();

                        foreach (string id in selectedIds)
                        {
                            SqlCommand command = new SqlCommand("Changepassdemoinfo", conn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@newpassword", newpassword);
                            command.ExecuteNonQuery();
                        }

                        conn.Close();
                    }

                    MessageBox.Show("Passwords updated successfully.");
                    this.Close();   
                }
            }
        }
    }
}



    