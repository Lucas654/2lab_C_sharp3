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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (zavod a in Data.zavodi)
                listBox1.Items.Add($"Назва заводу:{a.nameZavod}   \nКількість цехів: {a.numOfWorkshops}   \nКількість робітників: {a.numOfemployees} \n Кількість майстрів: {a.numOfMasters}");
        }
    }
}
