using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _2lab_C_sharp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory("FactoryData");

        }

        private void addFactoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = "Кількість відділів: " + Data.zavodi[comboBox1.SelectedIndex].numOfWorkshops;
            label3.Text = "Кількість робітників: " + Data.zavodi[comboBox1.SelectedIndex].numOfemployees;
            label4.Text = "Кількість майстрів: " + Data.zavodi[comboBox1.SelectedIndex].numOfMasters;
            label5.Text = "Заробітна плата робітника: " + Data.zavodi[comboBox1.SelectedIndex].salaryEmpl;
            label6.Text = "Заробітна плата майстра: " + Data.zavodi[comboBox1.SelectedIndex].salaryMaster;
            label7.Text = "Прибуток за місяць з робітника: " + Data.zavodi[comboBox1.SelectedIndex].incomeEmpl;
            label8.Text = "Прибуток за місяць з майстра: " + Data.zavodi[comboBox1.SelectedIndex].incomeMaster;

            listBox1.Items.Clear();

            
            foreach (var worker in Data.zavodi[comboBox1.SelectedIndex].people)
            {
                if (worker.Value.GetType().ToString().Split('.')[1] == "Worker")
                    foreach (var output in Data.zavodi[comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                        listBox1.Items.Add(output);
            }

            listBox2.Items.Clear();

            
            foreach (var worker in Data.zavodi[comboBox1.SelectedIndex].people)
            {
                if (worker.Value.GetType().ToString().Split('.')[1] == "Master")
                    foreach (var outPut in Data.zavodi[comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                        listBox2.Items.Add(outPut);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                Form3 form3 = new Form3(this);
                form3.Show();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (!Data.zavodi[comboBox1.SelectedIndex].Fire(textBox1.Text))
                {
                    MessageBox.Show("Немає працівника з таким ID");
                }
                else
                {
                    MessageBox.Show("Працівник звільненний");
                    label3.Text = "Кількість робітників: " + Data.zavodi[comboBox1.SelectedIndex].numOfemployees;
                    label4.Text = "Кількість майстрів: " + Data.zavodi[comboBox1.SelectedIndex].numOfMasters;
                }
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                Form5 form5 = new Form5(this);
                form5.Show();
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                
            }
                
        }

        private void обToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void порівнятиЗаводиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            Data.zavodi.Sort();
            form4.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                label9.Text = "Кількість відділів: " + Data.zavodi[comboBox1.SelectedIndex].numOfWorkshops;
                label3.Text = "Кількість робітників: " + Data.zavodi[comboBox1.SelectedIndex].numOfemployees;
                label4.Text = "Кількість майстрів: " + Data.zavodi[comboBox1.SelectedIndex].numOfMasters;
                label5.Text = "Заробітна плата робітника: " + Data.zavodi[comboBox1.SelectedIndex].salaryEmpl;
                label6.Text = "Заробітна плата майстра: " + Data.zavodi[comboBox1.SelectedIndex].salaryMaster;
                label7.Text = "Прибуток за місяць з робітника: " + Data.zavodi[comboBox1.SelectedIndex].incomeEmpl;
                label8.Text = "Прибуток за місяць з майстра: " + Data.zavodi[comboBox1.SelectedIndex].incomeMaster;
            }
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C:\\Users\\lucaa\\source\\repos\\2lab_C_sharp — копия\\2lab_C_sharp\bin\\Debug\\FactoryData\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save factory information";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var filepath = saveFileDialog1.FileName;

                if (comboBox1.SelectedIndex > -1)
                {
                    using (var file = File.CreateText(filepath))
                    {
                        string[] output = Data.zavodi[comboBox1.SelectedIndex].ToString().Split(',');
                        foreach (var item in output)
                        {
                            file.WriteLine(item);
                        }

                        if (Data.zavodi[comboBox1.SelectedIndex].workshops.Count > 0)
                        {
                            for (int i = 0; i < Data.zavodi[comboBox1.SelectedIndex].workshops.Count; i++)
                            {
                                string[] outp = Data.zavodi[comboBox1.SelectedIndex].workshops[i].ToString().Split(',');
                                foreach (var item in outp)
                                {
                                    file.WriteLine(item);
                                }
                            }
                        }
                        

                    }
                }

            }
        }

        private void загрузитиДаніПроЗаводToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            { // щоб не забути закрити файл
                openFileDialog.InitialDirectory = "C:\\Users\\lucaa\\source\\repos\\2lab_C_sharp — копия\\2lab_C_sharp\bin\\Debug\\FactoryData\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    try
                    {
                        using (var file = new StreamReader(filePath))
                        {

                            string name = file.ReadLine();
                            string NOfW = file.ReadLine();
                            string NOfM = file.ReadLine();
                            string NOfE = file.ReadLine();
                            string SOfE = file.ReadLine();
                            string SOfM = file.ReadLine();
                            string IOfM = file.ReadLine();
                            string IOfE = file.ReadLine();
                            name = name.Split(':')[1];
                            NOfW = NOfW.Split(':')[1];
                            NOfM = NOfM.Split(':')[1];
                            NOfE = NOfE.Split(':')[1];
                            SOfE = SOfE.Split(':')[1];
                            SOfM = SOfM.Split(':')[1];
                            IOfM = IOfM.Split(':')[1];
                            IOfE = IOfE.Split(':')[1];
                            name = name.Trim();
                            NOfW = NOfW.Trim();
                            NOfM = NOfM.Trim();
                            NOfE = NOfE.Trim();
                            SOfE = SOfE.Trim();
                            SOfM = SOfM.Trim();
                            IOfM = IOfM.Trim();
                            IOfE = IOfE.Trim();
                            Data.zavodi.Add(new zavod(name, int.Parse(NOfW), int.Parse(NOfM), int.Parse(NOfE), double.Parse(SOfE), double.Parse(SOfM), double.Parse(IOfM), double.Parse(IOfE)));
                            comboBox1.Items.Add(Data.zavodi[Data.zavodi.Count - 1].nameZavod);



                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Помилка при читанні з файла",
                            "Помилка введення даних",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
                

        }

        private void зберегтиДаніПроРобітниківToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C:\\Users\\lucaa\\source\\repos\\2lab_C_sharp — копия\\2lab_C_sharp\bin\\Debug\\FactoryData\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save Worker information";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var filepath = saveFileDialog1.FileName;

                if (comboBox1.SelectedIndex > -1)
                {
                    if (Data.zavodi[comboBox1.SelectedIndex].people.Count>0)
                    {
                        using (var file = File.CreateText(filepath))
                        {
                            string[] output = Data.zavodi[comboBox1.SelectedIndex].ToString().Split(',');
                            foreach (var worker in Data.zavodi[comboBox1.SelectedIndex].people)
                            {
                                if (worker.Value.GetType().ToString().Split('.')[1] == "Worker")
                                    foreach (var outPut in Data.zavodi[comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                                    file.WriteLine(outPut);
                            }
                        }

                    }
                }

            }
        }

        private void загрузитиДаніПроРобітниківToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            { // щоб не забути закрити файл
                openFileDialog.InitialDirectory = "FactoryData\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    try
                    {
                        Dictionary<string, Person> workersInput = new Dictionary<string, Person>();
                        using (var file = new StreamReader(filePath))
                        {
                            for (int i = 0; i < File.ReadAllLines(filePath).Length / 6; i++)
                            {
                                string lastName = file.ReadLine();
                                string firstName = file.ReadLine();
                                string name = file.ReadLine();
                                string individualTaxpayerNumber = file.ReadLine();
                                string NW = file.ReadLine();
                                string education = file.ReadLine();
                                firstName = firstName.Split(':')[1]; 
                                 lastName = lastName.Split(':')[1];
                                name = name.Split(':')[1];
                                NW = NW.Split(':')[1];
                                education = education.Split(':')[1];
                                individualTaxpayerNumber = individualTaxpayerNumber.Split(':')[1];
                                individualTaxpayerNumber = individualTaxpayerNumber.Trim();

                                try
                                {
                                    long temp = uint.Parse(individualTaxpayerNumber);
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
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Індивідуальний податковий номер має складатись з 10 цифр",
                                    "Помилка введення даних",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                    return;
                                }

                                foreach (var worker in Data.zavodi[comboBox1.SelectedIndex].people)
                                { // перевірка на унікальність ІПН
                                    if (individualTaxpayerNumber == worker.Key)
                                    {
                                        MessageBox.Show("Однаковий індивідуальний податковий номер",
                                        "Помилка введення даних",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                Data.zavodi[comboBox1.SelectedIndex].people.Add(individualTaxpayerNumber, new Worker(firstName.Trim(), lastName.Trim(), name.Trim(), individualTaxpayerNumber.Trim(), int.Parse(NW), education.Trim()));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка при читанні з файла",
                            "Помилка введення даних",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void зберегтиДаніПроМайстрівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C:\\Users\\lucaa\\source\\repos\\2lab_C_sharp — копия\\2lab_C_sharp\bin\\Debug\\FactoryData\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save Master information";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var filepath = saveFileDialog1.FileName;

                if (comboBox1.SelectedIndex > -1)
                {
                    if (Data.zavodi[comboBox1.SelectedIndex].people.Count > 0)
                    {
                        using (var file = File.CreateText(filepath))
                        {
                            foreach (var worker in Data.zavodi[comboBox1.SelectedIndex].people)
                            {
                                if (worker.Value.GetType().ToString().Split('.')[1]=="Master")
                                foreach (var outPut in Data.zavodi[comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                                    file.WriteLine(outPut);
                            }
                        }

                    }
                }

            }
        }

        private void загрузитиДаніПроМайстрівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            { 
                openFileDialog.InitialDirectory = "FactoryData\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    try
                    {
                        Dictionary<string, Person> workersInput = new Dictionary<string, Person>();
                        using (var file = new StreamReader(filePath))
                        {
                            for (int i = 0; i < File.ReadAllLines(filePath).Length / 6; i++)
                            {
                                string lastName = file.ReadLine();
                                string firstName = file.ReadLine();
                                string name = file.ReadLine();
                                string individualTaxpayerNumber = file.ReadLine();
                                string NW = file.ReadLine();
                                string sert = file.ReadLine();
                                firstName = firstName.Split(':')[1];
                                lastName = lastName.Split(':')[1];
                                name = name.Split(':')[1];
                                NW = NW.Split(':')[1];
                                sert = sert.Split(':')[1];
                                individualTaxpayerNumber = individualTaxpayerNumber.Split(':')[1];
                                individualTaxpayerNumber = individualTaxpayerNumber.Trim();

                                try
                                {
                                    long temp = uint.Parse(individualTaxpayerNumber);
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
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Індивідуальний податковий номер має складатись з 10 цифр",
                                    "Помилка введення даних",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                    return;
                                }

                                foreach (var worker in Data.zavodi[comboBox1.SelectedIndex].people)
                                { // перевірка на унікальність ІПН
                                    if (individualTaxpayerNumber == worker.Key)
                                    {
                                        MessageBox.Show("Однаковий індивідуальний податковий номер",
                                        "Помилка введення даних",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                Data.zavodi[comboBox1.SelectedIndex].people.Add(individualTaxpayerNumber, new Master(firstName.Trim(), lastName.Trim(), name.Trim(), individualTaxpayerNumber.Trim(), int.Parse(NW), int.Parse(sert.Trim())));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка при читанні з файла",
                            "Помилка введення даних",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
