using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ex4
{
    public partial class Edit : Form
    {
        Form1 _parentform;
        int id;
        string connectionString;
        public Edit(Form1 parentform, int id, string conn)
        {
            InitializeComponent();
            _parentform = parentform;
            this.id = id;
            connectionString = conn;
            update();
        }
        private void update()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM SINHVIEN WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["ID"].ToString();
                    textBox2.Text = reader["NAME"].ToString();
                    textBox3.Text = reader["NGANH"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" & textBox3.Text != "")
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE SINHVIEN SET ID=@ID1,NAME=@NAME,GENDER=@GENDER,NGANH=@NGANH,KHOA=@KHOA WHERE ID=@ID", connection);
                    cmd.Parameters.AddWithValue("@ID1",Int32.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@NAME",textBox2.Text);
                    cmd.Parameters.AddWithValue("@GENDER",comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@NGANH",textBox3.Text);
                    cmd.Parameters.AddWithValue("@KHOA",comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID",id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            }
        }
    }
}
