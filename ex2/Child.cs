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
    public partial class Child : Form
    {

        private Form1 _parentForm;
        public Child(Form1 parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Trống");
            }
            else
            {
                this.Name = textBox1.Text;
            }
            if(!Int32.TryParse(textBox2.Text, out int value)) {
                MessageBox.Show("Sai cú pháp");

            }
            else
            {
                this.Age = Int32.Parse(textBox2.Text);
            }
            this.Gender = comboBox1.SelectedText.ToString();
            if(this.Name != "" && this.Age != -1) {
                _parentForm.addList(Name,Age,Gender);
                this.Close();
            }
        }

        public string Name = "";
        public int Age = -1;
        public string Gender;
    }
}
