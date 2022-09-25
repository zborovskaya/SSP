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
        private Translator dictionary = new Translator();
        private List<Item> translation = new List<Item>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "Введите слово";
            }else
            {
                label1.Text = "Write word";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selected = comboBox1.SelectedIndex;
            translation = dictionary.getTranslation(textBox1.Text.Trim(), selected);
            textBox2.Text = "";
            if (translation.Count != 0)
            {
                if (selected == 0)
                {
                    foreach (Item word in translation)
                    {
                        textBox2.Text = textBox2.Text + word.getRussianWord() +" - " + word.getEnglishWord() + Environment.NewLine;
                    }
                }else
                {
                    foreach (Item word in translation)
                    {
                        textBox2.Text = textBox2.Text + word.getEnglishWord() + " - " + word.getRussianWord() + Environment.NewLine;
                    }
                }
                
            }else
            {
                textBox2.Text = "We do not have this word!";
            }
        }
    }
}
