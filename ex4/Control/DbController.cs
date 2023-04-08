using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ex4.Control
{
    internal class DbController
    {
        private string connectionString = "server = localhost; port=3306;database=sinhvien;user=root;password=1234";
        private MySqlConnection connection;
        Form1 _parentform;
        string[] khoa = { "K63", "K62", "K61", "K60" };

        public DbController(Form1 parentform)
        {
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command1 = new MySqlCommand("CREATE TABLE IF NOT EXISTS sinhvien (ID INT PRIMARY KEY, NAME VARCHAR(50), GENDER VARCHAR(10), NGANH VARCHAR(50), KHOA VARCHAR(50));", connection);
                command1.ExecuteNonQuery();
                _parentform = parentform;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void init()
        { 
            TreeNode root = new TreeNode();
            root.Text = "Sinh viên";
            _parentform.treeView1.Nodes.Add(root);
            TreeNode parent = _parentform.treeView1.Nodes[0];
            foreach (string khoa1 in khoa)
            {
                parent.Nodes.Add(new TreeNode(khoa1));

            }
            for (int i = 0; i < khoa.Length; i++)
            {
                TreeNode parent1 = parent.Nodes[i];
                MySqlCommand command = new MySqlCommand("SELECT ID FROM SINHVIEN WHERE KHOA=@KHOA", connection);
                command.Parameters.AddWithValue("@KHOA", khoa[i].Substring(1));
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TreeNode child = new TreeNode(reader["ID"].ToString());
                    parent1.Nodes.Add(child);
                }
                reader.Close();
            }
        }
        public void add()
        {
            Add form = new Add(_parentform, connectionString);
            form.ShowDialog();
        }

        public void remove(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM SINHVIEN WHERE ID=@ID", connection);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();
        }
        public void edit(int id)
        {
            Edit form = new Edit(_parentform, id, connectionString);
            form.ShowDialog();
        }
        public string display(int id)
        {
            string result = null;
            MySqlCommand command = new MySqlCommand("SELECT * FROM sinhvien WHERE ID=@ID", connection);
            command.Parameters.AddWithValue("@ID", id);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = $"MSV:{reader["ID"]}\nTên:{reader["NAME"]}\nGiới tính:{reader["GENDER"]}\nKhóa:{reader["KHOA"]}\nNgành:{reader["NGANH"]}";
            }
            reader.Close();
            return result;
        }
        public void refresh()
        {
            _parentform.treeView1.Nodes.Clear();
            TreeNode root = new TreeNode();
            root.Text = "Sinh viên";
            _parentform.treeView1.Nodes.Add(root);
            TreeNode parent = _parentform.treeView1.Nodes[0];
            foreach (string khoa1 in khoa)
            {
                parent.Nodes.Add(new TreeNode(khoa1));

            }
            for (int i = 0; i < khoa.Length; i++)
            {
                TreeNode parent1 = parent.Nodes[i];
                MySqlCommand command = new MySqlCommand("SELECT ID FROM SINHVIEN WHERE KHOA=@KHOA", connection);
                command.Parameters.AddWithValue("@KHOA", khoa[i].Substring(1));
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TreeNode child = new TreeNode(reader["ID"].ToString());
                    parent1.Nodes.Add(child);
                }
                reader.Close();
            }
        }
        public void close()
        {
            connection.Close();
        }
    }
}
