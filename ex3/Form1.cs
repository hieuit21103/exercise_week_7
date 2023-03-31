using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initFont();
            initDropDown();
        }

        List<string> list = new List<string>();
        List<int> size = new List<int>()
        {
            8,
            10,
            12,
            14,
            16,
            18,
            20,
            24,
            28,
            32,
            40,
            48,
            56,
            64,
            72
        };

        private void initFont()
        {
            InstalledFontCollection installedFont = new InstalledFontCollection();
            FontFamily[] families = installedFont.Families;
            foreach (FontFamily family in families)
            {
                list.Add(family.Name);
            }
        }
        private void initDropDown()
        {
            foreach(string font in list)
            {
                comboBox1.Items.Add(font);
            }
            comboBox1.SelectedIndex = 0;
            foreach (int size in size)
            {
                comboBox2.Items.Add(size);
            }
            comboBox2.SelectedIndex= 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionLength > 0)
            {
                Font current = richTextBox1.SelectionFont;
                if(current != null)
                {
                    richTextBox1.SelectionFont = new Font(comboBox1.SelectedItem.ToString(), current.Size, current.Style);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionLength > 0)
            {
                Font current = richTextBox1.SelectionFont;
                if(current != null)
                {
                    richTextBox1.SelectionFont = new Font(current.FontFamily, float.Parse(comboBox2.SelectedItem.ToString()), current.Style);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    Color selectedColor = colorDialog1.Color;
                    richTextBox1.SelectionColor = selectedColor;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count1 == 0)
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    Font currentFont = richTextBox1.SelectionFont;
                    FontStyle newFontStyle = currentFont.Style | FontStyle.Bold;
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                    count1 = 1;
                }
            }
            else
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    Font currentFont = richTextBox1.SelectionFont;
                    FontStyle newFontStyle = currentFont.Style & ~FontStyle.Bold;
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                    count1 = 0;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (count2 == 0)
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    Font currentFont = richTextBox1.SelectionFont;
                    FontStyle newFontStyle = currentFont.Style | FontStyle.Italic;
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                    count2 = 1;
                }
            }
            else
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    Font currentFont = richTextBox1.SelectionFont;
                    FontStyle newFontStyle = currentFont.Style & ~FontStyle.Italic;
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                    count2 = 0;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (count3 == 0)
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    Font currentFont = richTextBox1.SelectionFont;
                    FontStyle newFontStyle = currentFont.Style | FontStyle.Underline;
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                    count3 = 1;
                }
            }
            else
            {
                if (richTextBox1.SelectionLength > 0)
                {
                    Font currentFont = richTextBox1.SelectionFont;
                    FontStyle newFontStyle = currentFont.Style & ~FontStyle.Underline;
                    richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                    count3 = 0;
                }
            }
        }

        private int count1 = 0;
        private int count2 = 0;
        private int count3 = 0;
    }
}
