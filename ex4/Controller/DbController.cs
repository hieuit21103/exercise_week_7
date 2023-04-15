using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ex4.Control
{
    internal class DbController
    {
        private string connectionString = @"data source=C:\Users\HIEU\source\repos\exercise_week_7\ex4\ex4.db;";
        private SQLiteConnection connection;
        Form1 _parentform;
        string[] khoa = { "K63", "K62", "K61", "K60" };

        public DbController(Form1 parentform)
        {
            connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();
                SQLiteCommand command1 = new SQLiteCommand("CREATE TABLE IF NOT EXISTS sinhvien (ID INT PRIMARY KEY, NAME VARCHAR(50), GENDER VARCHAR(10), NGANH VARCHAR(50), KHOA VARCHAR(50));", connection);
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
                SQLiteCommand command = new SQLiteCommand("SELECT ID FROM SINHVIEN WHERE KHOA=@KHOA", connection);
                command.Parameters.AddWithValue("@KHOA", khoa[i].Substring(1));
                SQLiteDataReader reader = command.ExecuteReader();
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
            SQLiteCommand command = new SQLiteCommand("DELETE FROM SINHVIEN WHERE ID=@ID", connection);
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
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM sinhvien WHERE ID=@ID", connection);
            command.Parameters.AddWithValue("@ID", id);
            SQLiteDataReader reader = command.ExecuteReader();
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
                SQLiteCommand command = new SQLiteCommand("SELECT ID FROM SINHVIEN WHERE KHOA=@KHOA", connection);
                command.Parameters.AddWithValue("@KHOA", khoa[i].Substring(1));
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TreeNode child = new TreeNode(reader["ID"].ToString());
                    parent1.Nodes.Add(child);
                }
                reader.Close();
            }
        }

        public void searchById(int id)
        {

        }
        public void searchByName(string name)
        {

        }
        public void close()
        {
            connection.Close();
        }
    }
}
