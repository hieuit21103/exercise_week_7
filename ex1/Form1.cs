using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initItem();
        }

        public void initItem()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("hieu", 1));
            students.Add(new Student("hien", 2));
            students.Add(new Student("hiep", 3));
            listBox1.DisplayMember = "name"; 
            listBox1.ValueMember = "id";
            listBox1.DataSource = students;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = listBox1.SelectedValue.ToString();
        }
    }

    class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public Student(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string getName()
        {
            return name;
        }
        public int getId()
        {
            return id;
        }
    }
}
