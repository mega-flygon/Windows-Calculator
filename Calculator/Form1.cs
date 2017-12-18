using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        enum Operation { ADD, SUBTRACT, MULTIPLY, DIVIDE };

        private double currentNumber = 0;
        private double runningTotal = 0;
        private Operation currentOperation = Operation.ADD;
        private bool overwriteTotal = false; // set this to false everytime it's used in logic

        public Form1()
        {
            InitializeComponent();
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (overwriteTotal) {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 0;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 1;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 2;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 3;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 4;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 5;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 6;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 7;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 8;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (overwriteTotal)
            {
                runningTotal = 0;
                overwriteTotal = false;
            }
            currentNumber *= 10;
            currentNumber += 9;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            performCurrentOperation();
            overwriteTotal = true;
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        public void performCurrentOperation()
        {
            switch (currentOperation)
            {
                case Operation.ADD:
                    runningTotal += currentNumber;
                    break;
                case Operation.SUBTRACT:
                    runningTotal -= currentNumber;
                    break;
                case Operation.MULTIPLY:
                    runningTotal *= currentNumber;
                    break;
                case Operation.DIVIDE:
                    runningTotal /= currentNumber;
                    break;
            };
            currentNumber = 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (overwriteTotal) overwriteTotal = false;
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.ADD;
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            if (overwriteTotal) overwriteTotal = false;
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.SUBTRACT;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            if (overwriteTotal) overwriteTotal = false;
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.MULTIPLY;
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            if (overwriteTotal) overwriteTotal = false;
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.DIVIDE;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            currentNumber = 0;
            runningTotal = 0;
            currentOperation = Operation.ADD;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            currentNumber = 0;
            display.Text = "TOO HARD";
        }

    }
}
