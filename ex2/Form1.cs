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
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Age");
            listView1.Columns.Add("Gender");
        }

        private List<Person> people = new List<Person>
        {
            new Person { Name = "John", Age = 30, Gender = "Male" },
            new Person { Name = "Jane", Age = 25, Gender = "Female" },
            new Person { Name = "Bob", Age = 40, Gender = "Male" }
        };
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
