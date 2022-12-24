using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab_C_sharp
{
    public partial class Form3 : Form
    {
        Form1 form;
        public Form3(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text!=string.Empty && int.TryParse(textBox5.Text, out int t5) && comboBox1.SelectedIndex > -1)
            {
                try
                {
                    long temp = int.Parse(textBox4.Text);
                    int iterator = 0;
                    while (temp > 0)
                    {
                        iterator++;
                        temp /= 10;
                    }
                    if (iterator != 10)
                    {
                        MessageBox.Show("Індивідуальний податковий номер має складатись з 10 цифр",
                        "Помилка введення даних",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                        return;
                    }
                    else
                        if (Data.zavodi[form.comboBox1.SelectedIndex].HireEmpl(new Worker(textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, t5, comboBox1.SelectedItem.ToString())))
                    {

                        form.label3.Text = "Кількість робітників: " + Data.zavodi[form.comboBox1.SelectedIndex].numOfemployees;
                        this.Close();
                        form.listBox1.Items.Clear();

                        string[] output = Data.zavodi[comboBox1.SelectedIndex].ToString().Split(',');
                        foreach (var worker in Data.zavodi[comboBox1.SelectedIndex].people)
                        {
                            if (worker.Value.GetType().ToString().Split('.')[1] == "Worker")
                                foreach (var outPut in Data.zavodi[comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                                    form.listBox1.Items.Add(outPut);
                        }
                    }
                    else
                        MessageBox.Show("Даний ID вже зайнятий");
                }
                catch (Exception)
                {
                    MessageBox.Show("Індивідуальний податковий номер має складатись з 10 цифр",
                    "Помилка введення даних",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
                MessageBox.Show("Дані введені некорректно");
        }
    }
}
