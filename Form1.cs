using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private DataRow selectedDataRow;
        public bool IsUpdateMode = false;
       


        public Form1(DataRow selectedDataRow = null)
        {
            InitializeComponent();
            //IsUpdateMode = (selectedDataRow != null);
                this.selectedDataRow = selectedDataRow;
            if(selectedDataRow != null)
            {
               // idtxt.Text = selectedDataRow["id"].ToString();
                firsttxt.Text = selectedDataRow["fname"].ToString();
                lasttxt.Text = selectedDataRow["lname"].ToString();
                emailtxt.Text = selectedDataRow["email"].ToString();
                phonetxt.Text = selectedDataRow["phone"].ToString();
                passtxt.Text = selectedDataRow["password"].ToString();
            }
                
            

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void firsttxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void firsttxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void lasttxt_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }


        private void phonetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                string inputText = (sender as System.Windows.Forms.TextBox).Text + e.KeyChar.ToString();
                if (inputText.Count(Char.IsDigit) > 10)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void passtxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private bool Validated()
        {
            bool validated = true;
            if (firsttxt.Text == "")
            {
                errorProvider1.SetError(firsttxt, "Please fill mandatory field");
                validated = false;
            }
            else
            {
                errorProvider1.SetError(firsttxt, "");
            }
            if (lasttxt.Text == "")
            {
                errorProvider1.SetError(lasttxt, "Please fill mandatory field");
                validated = false;
            }
            else
            {
                errorProvider1.SetError(lasttxt, "");
            }
            if (emailtxt.Text == "")
            {
                errorProvider1.SetError(emailtxt, "Please fill mandatory field");
                validated = false;
            }
            else
            {
                errorProvider1.SetError(emailtxt, "");
            }

            if (phonetxt.Text == "")
            {
                errorProvider1.SetError(phonetxt, "Please fill mandatory field");
                validated = false;
            }
            else
            {
                errorProvider1.SetError(phonetxt, "");
            }
            if (phonetxt.Text.Length < 10)
            {
                errorProvider1.SetError(phonetxt, "Please enter valid number");
                validated = false;
            }
            else
            {
                errorProvider1.SetError(phonetxt, "");
            }

            if (passtxt.Text == "")
            {
                errorProvider1.SetError(passtxt, "Please fill mandatory field");
                validated = false;
            }
            else
            {
                errorProvider1.SetError(passtxt, "");
            }

            return validated;
        }


        private void savebtn_Click(object sender, EventArgs e)
        {

            string id,Fname, Lname, email, phone, password;
            //id = idtxt.Text;
            Fname = firsttxt.Text;
            Lname = lasttxt.Text;
            email = emailtxt.Text;
            phone = phonetxt.Text;
            password = passtxt.Text;
            if (Validated())
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data source=DESKTOP-ARDALUS\\MSSQLSERVER01;Initial Catalog=demodb; Integrated Security=true;";
                    conn.Open();

                    // Check if any records exist in the table
                    string checkQuery = "SELECT COUNT(*) FROM demoinfo";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
                    int recordCount = (int)checkCommand.ExecuteScalar();

                    if (recordCount > 0 && IsUpdateMode)
                   
                        {
                        SqlCommand command = new SqlCommand("Updatedemoinfo", conn);
                        command.Parameters.AddWithValue("@id", selectedDataRow["id"]);
                        command.Parameters.AddWithValue("@Fname", Fname);
                        command.Parameters.AddWithValue("@Lname", Lname);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@password", password);
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Information updated.");
                        }
                    else
                    {
                        //using (SqlConnection conn = new SqlConnection())
                        {
                            //conn.ConnectionString = "Data source=DESKTOP-ARDALUS\\MSSQLSERVER01;Initial Catalog=demodb; Integrated Security=true;";
                            //conn.Open();
                            SqlCommand command = new SqlCommand("Insertdemoinfo", conn);
                            {
                                command.Parameters.AddWithValue("@Fname", Fname);
                                command.Parameters.AddWithValue("@Lname", Lname);
                                command.Parameters.AddWithValue("@email", email);
                                command.Parameters.AddWithValue("@phone", phone);
                                command.Parameters.AddWithValue("@password", password);
                            }
                            command.CommandType = CommandType.StoredProcedure;
                           
                            command.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("Information saved.");
                        }

                        //MessageBox.Show("Information saved.");
                    }
                    this.Close();

                   
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

                //userviewform.RefreshDataGridView();
                //NavigateToUserViewForm();
           // }
        }

    private void emailtxt_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (emailtxt.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(emailtxt.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    emailtxt.Focus();
                }
            }
        }
    }

    
}



//private void NavigateToUserViewForm()
//{
//  UserViewForm userviewform = new UserViewForm();
//userviewform.Show();


// }


