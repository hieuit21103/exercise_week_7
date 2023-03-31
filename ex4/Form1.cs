using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ex4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initDb();
            initTree();
        }

        private void initTree()
        {
            TreeNode root = new TreeNode();
            root.Text = "Sinh viên";
            treeView1.Nodes.Add(root);
            TreeNode parent = treeView1.Nodes[0];
            foreach (string khoa in khoa)
            {
                parent.Nodes.Add(new TreeNode() { Text = khoa });
            }
            for (int i = 0; i < 4; i++)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT NAME FROM SINHVIEN WHERE KHOA=@KHOA", connection);
                command.Parameters.AddWithValue("@KHOA", khoa[i].Substring(1));
                MySqlDataReader reader = command.ExecuteReader();
                TreeNode parent1 = parent.Nodes[i];
                while (reader.Read())
                {
                    TreeNode child = new TreeNode(reader["NAME"].ToString());
                    parent1.Nodes.Add(child);
                }
                reader.Close();
                connection.Close();
            }
        }

        private void initDb()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command1 = new MySqlCommand("CREATE TABLE IF NOT EXISTS sinhvien (ID INT PRIMARY KEY, NAME VARCHAR(50), GENDER VARCHAR(10), NGANH VARCHAR(50), KHOA VARCHAR(50));", connection);
            try
            {
                connection.Open();
                command1.ExecuteNonQuery();
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

        private string[] khoa = { "K63", "K62", "K61", "K60" };
        string connectionString = "server=localhost;port=3306;database=sinhvien;user=root;password=1234;";

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode childNode = e.Node;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM sinhvien WHERE NAME=@NAME",conn);
            command.Parameters.AddWithValue("@NAME", childNode.Text);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                label1.Text = $"MSV:{reader["ID"]}\nTên:{reader["NAME"]}\nGiới tính:{reader["GENDER"]}\nKhóa:{reader["KHOA"]}\nNgành:{reader["NGANH"]}";
            }
            reader.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if(selectedNode != null)
            {
                this.functionDb(selectedNode.Text, 2);
            }
        }

        private void functionDb(string name,int method)
        {
            switch(method)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        private void updateTree()
        {
            TreeNode parent = treeView1.Nodes[0];
            for (int i = 0; i < 4; i++)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT NAME FROM SINHVIEN WHERE KHOA=@KHOA", connection);
                command.Parameters.AddWithValue("@KHOA", khoa[i].Substring(1));
                MySqlDataReader reader = command.ExecuteReader();
                TreeNode parent1 = parent.Nodes[i];
                while (reader.Read())
                {
                    TreeNode child = new TreeNode(reader["NAME"].ToString());
                    parent1.Nodes.Add(child);
                }
                reader.Close();
                connection.Close();
            }
        }
    }
}
