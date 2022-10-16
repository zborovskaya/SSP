using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSP_1
{
    public partial class Form1 : Form
    {
        private Translator dictionary = new Translator();
        private List<Item> translation = new List<Item>();
        private TranslatorDAO dao= new TranslatorDAO();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //comboBox2.Items.AddRange(new string[] { "translator", "school","university" });
            //comboBox2.SelectedIndex = 0;
            label4.Text = "";

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
            }
            else
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
            try
            {
                
                dictionary.readItems();
                if (dictionary.isBlocked())
                {
                    textBox2.Text = "The file was not found!";
                }
                else
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
                                textBox2.Text = textBox2.Text + word.getRussianWord() + " - " + word.getEnglishWord() + Environment.NewLine;
                            }
                        }
                        else
                        {
                            foreach (Item word in translation)
                            {
                                textBox2.Text = textBox2.Text + word.getEnglishWord() + " - " + word.getRussianWord() + Environment.NewLine;
                            }
                        }

                    }
                    else
                    {
                        textBox2.Text = "We do not have this word!";
                    }
                }
            }
            catch(Exception ex)
            {
                textBox2.Text = ex.Message;
                //textBox2.Text = "Some problems with reading";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            dictionary.setPath(filename);
            // читаем файл в строку
            label2.Text = filename;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item();
                label4.Text = "";
                bool f1 = !Regex.IsMatch(textBox3.Text, "[A-Яa-я]+", RegexOptions.IgnoreCase);
                bool f2 = !Regex.IsMatch(textBox4.Text, "[A-za-z]+", RegexOptions.IgnoreCase);
                if (!Regex.IsMatch(textBox3.Text, "[А-Яа-я]+", RegexOptions.IgnoreCase)
                    || !Regex.IsMatch(textBox4.Text, "[A-za-z]+", RegexOptions.IgnoreCase))
                {
                    label4.Text = "Input word is not correct";
                    return;
                }
                dictionary.readItems(); ;
                item.setRussianWord(textBox3.Text);
                item.setEnglishWord(textBox4.Text);
                try
                {
                    if (!dictionary.getItem().Contains(item))
                    { dictionary.addWord(item); }

                }
                catch (Exception exp)
                {
                    label4.Text = exp.Message;
                }

                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch
            {
                label4.Text = "Some proplems with database";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.ShowDialog();
        }
    }
}
