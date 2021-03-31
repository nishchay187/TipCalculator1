using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //This will initialize input textboxes and output labels.
            textBox1.Text = "$0.00";
            textBox2.Text = "0%";
            textBox3.Text = "0";
            label5.Text = "$0.00";
            label6.Text = "$0.00";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //This will check the input in textbox1 (Bill) that it has only digits
            if (!char.IsNumber(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //This will check the input in textbox3 (Number Of Persons) that it has only digits
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //This will check the input in textbox1 (Bill) that it has only digits and decimal only or not.
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox2.Text;
            //This will remove the percentage(%) symbol from the string so that it can be converted in integer.
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '%')
                {
                    a = a.Replace("%", "");
                }
            }
            int b = Int16.Parse(a);
            //This will decrease the tip % by 1 if the value of tip % is greater than 0.
            if (b > 0)
            {
                b = b - 1;
            }
            textBox2.Text = b.ToString() + "%";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox2.Text;
            //This will remove the percentage(%) symbol from the string so that it can be converted in integer.
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '%')
                {
                    a = a.Replace("%", "");
                }
            }
            int b = Int16.Parse(a);
            //This will increase the tip % by 1 if the value of tip % is less than 99.
            if (b < 99)
            {
            b = b + 1;
            }
            textBox2.Text = b.ToString() + "%";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int a = Int16.Parse(textBox3.Text);
            //This will decrease the number of persons by 1 if the value of number of persons is greater than 0.
            if (a > 0)
            {
                a = a - 1;
            }
            textBox3.Text = a.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = Int16.Parse(textBox3.Text);
            //This will increase the value of number of persons by 1.
            a += 1;
            textBox3.Text = a.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            //This will remove the dollar($) symbol from the string so that it can be converted in double.
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '$')
                {
                    a = a.Replace("$", "");
                }
            }
            double bill = Convert.ToDouble(a);
            a = textBox2.Text;
            //This will remove the percentage(%) symbol from the string so that it can be converted in integer.
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '%')
                {
                    a = a.Replace("%", "");
                }
            }
            int tip = Int16.Parse(a);
            int numberOfPersons = Int16.Parse(textBox3.Text);

            //This will calcuate and display the desired output.

            double totalTip = (bill * tip) / 100;
            double TipPerPerson = totalTip / numberOfPersons;
            double BillPerPerson = (bill / numberOfPersons) + TipPerPerson;
            label5.Text = TipPerPerson.ToString("C");
            label6.Text = BillPerPerson.ToString("C");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            //This will add dollar($) symbol at the beginning of the bill amount.
            a = "$" + a;
            textBox1.Text = a;
        }
    }
}
