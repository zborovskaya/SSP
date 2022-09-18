using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSP_1
{
    public partial class Form1 : Form
    {
        private Dictionary dictionary = new Dictionary();
        private List<String> translation = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //dictionary = new Dictionary();
           // bool lang = false;
           // if (comboBox1.SelectedIndex == 0) { lang = true; }
           // translation= dictionary.getTranslation(textBox1.Text.Trim(), lang);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool lang = false;
            if (comboBox1.SelectedIndex == 0) { lang = true; }
            translation = dictionary.getTranslation(textBox1.Text.Trim(), lang);
            textBox2.Text = "";
            if (translation.Count != 0)
            {
                
                foreach(String word in translation)
                {
                    textBox2.Text = textBox2.Text + word + Environment.NewLine;
                }
                
            }else
            {
                textBox2.Text = "We do not have this word!";
            }
           
        }
    }
}
