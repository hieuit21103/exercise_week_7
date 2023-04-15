using System;
using System.Data.SQLite;
using System.Windows.Forms;

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
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM SINHVIEN WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
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
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                try
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("UPDATE SINHVIEN SET ID=@ID1,NAME=@NAME,GENDER=@GENDER,NGANH=@NGANH,KHOA=@KHOA WHERE ID=@ID", connection);
                    cmd.Parameters.AddWithValue("@ID1", Int32.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@NAME", textBox2.Text);
                    cmd.Parameters.AddWithValue("@GENDER", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@NGANH", textBox3.Text);
                    cmd.Parameters.AddWithValue("@KHOA", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
            }
        }
    }
}
