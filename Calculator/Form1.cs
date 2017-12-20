using System;
using System.Collections;
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
        private bool equalsJustPressed = false; // set this to false everytime it's used in logic
        private ArrayList expressionTracker; // used to track the expression for displaying

        public Form1()
        {
            InitializeComponent();
            display.SelectionAlignment = HorizontalAlignment.Right;
            expressionTracker = new ArrayList();
        }

        private void numButton_Click(object sender, EventArgs e)
        {
            if (equalsJustPressed)
            {
                runningTotal = 0;
                equalsJustPressed = false;
            }

            if (sender == button0) button0_Click(sender, e);
            if (sender == button1) button1_Click(sender, e);
            if (sender == button2) button2_Click(sender, e);
            if (sender == button3) button3_Click(sender, e);
            if (sender == button4) button4_Click(sender, e);
            if (sender == button5) button5_Click(sender, e);
            if (sender == button6) button6_Click(sender, e);
            if (sender == button7) button7_Click(sender, e);
            if (sender == button8) button8_Click(sender, e);
            if (sender == button9) button9_Click(sender, e);

        }

        private void button0_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 0;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 1;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 2;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 3;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 4;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 5;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 6;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 7;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 8;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentNumber *= 10;
            currentNumber += 9;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            performCurrentOperation();
            equalsJustPressed = true;
            currentOperation = Operation.ADD;
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
                    if (currentNumber == 0)
                    {
                        display.Text = "Cannot divide by zero. \nPress C to start over.";
                    }
                    else
                    {
                        runningTotal /= currentNumber;
                    }
                    break;
            };
            currentNumber = 0;
        }

        // Abstracts statements general to clicking any operator button
        private void operatorButton_Click(object sender, EventArgs e)
        {
            if (currentNumber == 0 && currentOperation == Operation.DIVIDE)
            {
                display.Font = new Font("Microsoft YaHei UI", 12);
                display.Text = "Cannot divide by zero. \nPress C to start over.";
            }
            else
            {
                if (sender == addButton) addButton_Click(sender, e);
                if (sender == subtractButton) subtractButton_Click(sender, e);
                if (sender == multiplyButton) multiplyButton_Click(sender, e);
                if (sender == divideButton) divideButton_Click(sender, e);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // This logic prevents the calculator from performing the previous 
            // operation twice
            if (equalsJustPressed) 
            {
                currentNumber = 0;
                currentOperation = Operation.ADD;
                equalsJustPressed = false; 
            }
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.ADD;
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            if (equalsJustPressed)
            {
                currentNumber = 0;
                currentOperation = Operation.ADD;
                equalsJustPressed = false;
            }
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.SUBTRACT;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            if (equalsJustPressed)
            {
                currentNumber = 1;
                currentOperation = Operation.MULTIPLY;
                equalsJustPressed = false;
            }
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.MULTIPLY;
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            if (equalsJustPressed)
            {
                currentNumber = 1;
                currentOperation = Operation.MULTIPLY;
                equalsJustPressed = false;
            }
            performCurrentOperation();
            display.Text = Convert.ToString(runningTotal);
            display.SelectionAlignment = HorizontalAlignment.Right;
            currentOperation = Operation.DIVIDE;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            currentNumber = 0;
            runningTotal = 0;
            expressionTracker.Clear();
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
