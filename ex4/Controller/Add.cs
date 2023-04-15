using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex4
{
    public partial class Add : Form
    {
        Form1 _parentform;
        string connectionString;
        public Add(Form1 parentform, string connection)
        {
            _parentform = parentform;
            connectionString = connection;
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsLower(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsLower(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addToDb()
        {
            int id = Int32.Parse(textBox1.Text);
            string name = textBox2.Text;
            string gender = comboBox1.SelectedItem.ToString();
            int khoa = Int32.Parse(comboBox2.SelectedItem.ToString());
            string nganh = textBox3.Text;
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("INSERT INTO SINHVIEN VALUES(@ID,@NAME,@GENDER,@NGANH,@KHOA)", connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@NAME", name);
                command.Parameters.AddWithValue("@GENDER", gender);
                command.Parameters.AddWithValue("@KHOA", khoa);
                command.Parameters.AddWithValue("@NGANH", nganh);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" & textBox3.Text != "")
            {
                addToDb();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }
    }
}
