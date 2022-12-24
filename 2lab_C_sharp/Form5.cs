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
    public partial class Form5 : Form
    {
        Form1 form;
        public Form5(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text!=string.Empty && int.TryParse(textBox5.Text, out int t5) && int.TryParse(textBox6.Text, out int t6))
            {
                try
                {
                    long temp = uint.Parse(textBox4.Text);
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
                        if (Data.zavodi[form.comboBox1.SelectedIndex].HireEmpl(new Master(textBox2.Text, textBox1.Text, textBox3.Text, textBox4.Text, t5, t6)))
                    {

                        form.label4.Text = "Кількість майстрів: " + Data.zavodi[form.comboBox1.SelectedIndex].numOfMasters;
                        this.Close();
                        form.listBox2.Items.Clear();


                        foreach (var worker in Data.zavodi[form.comboBox1.SelectedIndex].people)
                        {
                            if (worker.Value.GetType().ToString().Split('.')[1] == "Master")
                                foreach (var outPut in Data.zavodi[form.comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                                    form.listBox2.Items.Add(outPut);
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
