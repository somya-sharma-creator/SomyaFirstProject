using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    public partial class UserViewForm : Form
    {
        // Private DataGridViewRow DataGridViewRow;

        public UserViewForm()// creating constructor so we don't need to make load function
        {
            InitializeComponent();

            dataGridView1.CellValueChanged += Selected_CheckedChanged;
            dataGridView1.Dock = DockStyle.Fill; // Set the Dock property to Fill
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // give responsiveness
            RefreshDataGridView();// refresh the dg
        }

        public void RefreshDataGridView()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Data source=DESKTOP-ARDALUS\\MSSQLSERVER01;Initial Catalog=demodb; Integrated Security=true;";
                conn.Open();
                string query = "Getdemoinfo";
                SqlCommand command = new SqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();//execute the query and returns the value
                DataTable table = new DataTable();//creating a datatable in dgv
                table.Load(reader);// it will load the value of reader into the data table
                dataGridView1.DataSource = table;//now table will work as the source for the dgv
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // to strech the column size according to the window size
                //dataGridView1.Columns["password"].Visible = false;// to hide passwrd
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)//when we click add user
        {

            Form1 form1 = new Form1();// new form will come with the name form 1

            form1.ShowDialog();//form will come with the particular fields
            RefreshDataGridView();// refresh the grid
        }



        private void dataGridView1_DoubleClick(object sender, EventArgs e)// when we double click the dgv(for update command)
        {
            if (dataGridView1.SelectedRows.Count > 0)//checks if any row is selected or not
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];//returns the selected row as datagridviewrow
                DataTable table = (DataTable)dataGridView1.DataSource;//sends the datasource of dgv to the datatable
                DataRow selectedDataRow = table.Rows[selectedRow.Index];

                Form1 form1 = new Form1(selectedDataRow);
                //form1.SelectedRowData = selectedDataRow; // Pass the selected row's data to Form1
                form1.IsUpdateMode = true; // Set IsUpdateMode to true, indicating "Update" mode
                //Form1 form1 = new Form1(selectedDataRow);
                form1.ShowDialog();
                RefreshDataGridView();
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete row")
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("do you want to delete this row?", row.Cells[7].Value), "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    using (SqlConnection conn = new SqlConnection())
                    {
                        conn.ConnectionString = "data source=desktop-ardalus\\mssqlserver01;initial catalog=demodb; integrated security=true;";
                        conn.Open();
                        SqlCommand command = new SqlCommand("Deletedemoinfo", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", row.Cells[7].Value);

                        command.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("deleted successfully");
                        RefreshDataGridView();
                    }
                }

            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Selected")
            {
                dataGridView1.Rows[e.RowIndex].SetValues(true);
            }

        }


        private void Selected_CheckedChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null)
                {
                    bool isChecked = (bool)checkBoxCell.Value;

                    if (isChecked)
                    {

                        string id = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                    }
                    else
                    {

                    }
                }
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {

            List<string> selectedItem = new List<string>();
            DataGridViewRow drow = new DataGridViewRow();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                drow = dataGridView1.Rows[i];
                if (Convert.ToBoolean(drow.Cells[0].Value) == true) //checking if  checked or not.  
                {
                    string id = drow.Cells[7].Value.ToString();
                    selectedItem.Add(id); //If checked adding it to the list  
                }
            }
            if (MessageBox.Show(string.Format("do you want to delete?", drow.Cells[7].Value), "confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Data source=DESKTOP-ARDALUS\\MSSQLSERVER01;Initial Catalog=demodb; Integrated Security=true;";
                    conn.Open();

                    foreach (string id in selectedItem) //using foreach loop to delete the records stored in list.  
                    {
                        SqlCommand command = new SqlCommand("Deletedemoinfo", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                RefreshDataGridView();
                MessageBox.Show("Deleted successfully");


            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void updatebtn_Click(object sender, EventArgs e)
        {

            List<string> selectedIds = new List<string>();
            DataGridViewRow drow = new DataGridViewRow();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                drow = dataGridView1.Rows[i];
                if (Convert.ToBoolean(drow.Cells[0].Value) == true)
                {
                    string id = drow.Cells[7].Value.ToString();
                    selectedIds.Add(id);
                }
            }


            UpdatePassForm form2 = new UpdatePassForm(selectedIds);
            form2.ShowDialog();

            RefreshDataGridView();

        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
                if (e.ColumnIndex == 7)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.BlanchedAlmond;
                if (e.ColumnIndex == 7)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}






















































            //private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            //{
            //        if (e.RowIndex % 2 == 0) 
            //        {
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Pink;
            //        }
            //        else 
            //        {
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.BlanchedAlmond;
            //        }


            //        if (e.RowIndex >= 0 && e.ColumnIndex == 7) 
            //        {
            //           if (e.RowIndex % 2 == 0)
            //           {
            //              e.CellStyle.ForeColor = Color.Red; 
            //           }
            //           else
            //           {
            //               e.CellStyle.ForeColor = Color.Blue; 
            //           }
            //        }
            //}





//if (dataGridView1.SelectedRows.Count > 0)
//{
//  DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

//string data = selectedRow.Cells[0].Value.ToString();

//MessageBox.Show("Selected Data: " + data);







