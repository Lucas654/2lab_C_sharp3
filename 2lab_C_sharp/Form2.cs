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
    public partial class Form2 : Form
    {
        Form1 form;
        int Counter;
        int t2, t3, t4;
        double t5, t6, t7, t8;
        public Form2(Form1 f)
        {
            InitializeComponent();
            form = f;
            Counter = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && int.TryParse(textBox2.Text, out t2) && int.TryParse(textBox3.Text, out t3) && int.TryParse(textBox4.Text, out t4) && double.TryParse(textBox5.Text, out t5) && double.TryParse(textBox6.Text, out t6) && double.TryParse(textBox7.Text, out t7) && double.TryParse(textBox8.Text, out t8))
            {

                Data.zavodi.Add(new zavod(textBox1.Text, t2, t4, t3, t5, t6, t8, t7));
                form.comboBox1.Items.Add(Data.zavodi[Data.zavodi.Count - 1].nameZavod);
                this.Close();
            }
            else
                MessageBox.Show("error");


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
