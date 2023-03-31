using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            if (people != null)
            {
                foreach (Person p in people)
                {
                    ListViewItem item = new ListViewItem(p.Name);
                    item.SubItems.Add(p.Age.ToString());
                    item.SubItems.Add(p.Gender);
                    listView1.Items.Add(item);
                }
            }
        }

        public List<Person> people { get; set; } 

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ListViewItem foundItem = listView1.FindItemWithText(textBox1.Text, false, 0, true);
            if(foundItem != null)
            {
                listView1.TopItem = foundItem;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Child childForm = new Child(this);
            childForm.Show();
        }

        public void addList(string name,int age,string gender)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(age.ToString());
            item.SubItems.Add(gender);
            listView1.Items.Add(item);
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
