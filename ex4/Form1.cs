using System;
using System.Windows.Forms;
using ex4.Control;

namespace ex4
{
    public partial class Form1 : Form
    {
        DbController database;
        public Form1()
        {
            InitializeComponent();
            database = new DbController(this);
            init();
            
        }

        private void init()
        {
            database.init();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode childNode = e.Node;
            if (Int32.TryParse(childNode.Text, out int id))
            {
                label1.Text = database.display(Int32.Parse(childNode.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (Int32.TryParse(selectedNode.Text, out int i)) {
                database.edit(Int32.Parse(selectedNode.Text));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if(selectedNode != null)
            {
                database.remove(Int32.Parse(selectedNode.Text));
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            database.refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            database.close();
        }
    }
}
