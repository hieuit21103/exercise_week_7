using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

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
            students.Add(new Student { id = 1, name = "hieu", major = "CNTT" });
            students.Add(new Student { id = 2, name = "hien", major = "CNTT" });
            students.Add(new Student { id = 3, name = "hiep", major = "CNTT" });
            listBox1.DisplayMember = "name"; 
            listBox1.ValueMember = "id;name;major";
            listBox1.DataSource = students;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            Student student = listBox1.SelectedItem as Student;
            label1.Text = student.displayInfomation.ToString();
        }
    }

    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string major { get; set; }
        public string displayInfomation
        {
            get { return $"{name} \nMSV: {id}\nKhoa: {major}"; }
        }
    }
}
