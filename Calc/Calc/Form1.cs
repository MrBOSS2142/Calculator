using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Calculator : Form
    {
        int result = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        bool flag = false;
        int memory = 0;
        public Calculator()
        {
            InitializeComponent();
        }
         
        private void button_last_remove(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (textBox1.Text.Length == 0)
                textBox1.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                operationPerformed = button.Text;
                result = int.Parse(textBox1.Text);
                CurrentOperation.Text = result + " " + operationPerformed;
                isOperationPerformed = true;
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentOperation.Text = "";
                switch (operationPerformed)
                {
                    case "+":
                        textBox1.Text = (result + int.Parse(textBox1.Text)).ToString();
                        break;
                    case "-":
                        textBox1.Text = (result - int.Parse(textBox1.Text)).ToString();
                        break;
                    case "*":
                        textBox1.Text = (result * int.Parse(textBox1.Text)).ToString();
                        break;
                    case "/":
                        textBox1.Text = (result / int.Parse(textBox1.Text)).ToString();
                        break;
                    case "^":
                        textBox1.Text = (Math.Pow(result, int.Parse(textBox1.Text))).ToString();
                        break;
                    default:
                        break;
                }
                flag = true;
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private void buttonMplus(object sender, EventArgs e)
        {
            if (memory == 0)
                memory=int.Parse(textBox1.Text);
            else
            textBox1.Text = (int.Parse(textBox1.Text) + memory).ToString();
        }

        private void buttonMminus(object sender, EventArgs e)
        {
            if (memory != 0)
                textBox1.Text = (memory - int.Parse(textBox1.Text)).ToString();
        }

        private void buttonMout(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
        }

        private void buttonMclear(object sender, EventArgs e)
        {
            memory = 0;
        }



        private void button_click(object sender, EventArgs e)
        {
            if (isOperationPerformed || (textBox1.Text == "0"))
                textBox1.Clear();
            if (flag == true)
                textBox1.Clear();
            isOperationPerformed = false;
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
            flag = false;
        }

        private void button_clear(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "0";
            result = 0;
            CurrentOperation.Text = "";
        }
    }
}
