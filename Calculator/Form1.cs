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
        enum ButtonType { NUMBER, OPERATION, OTHER };

        // Used to track the current number being entered (i.e. between operations/equals.)
        private double currentNumber = 0;

        // Used to track the running total of the expression (displayed after pressing operator or equals.)
        private double runningTotal = 0;

        // Used to track the last operation pressed to properly calculate the running expression.
        private Operation currentOperation = Operation.ADD;

        // Used to keep track of if the decimal button has been pressed.
        private bool decimalOn = false;

        // Divide the number pressed by this variable to turn it into the proper decimal value.
        private double decimalDivider = 10.0; // *= 10 after each use.

        // Used to ensure correct behavior for user input after equals has been pressed.
        private bool equalsJustPressed = false; // set this to false everytime it's used in logic

        // Used to track the running expression for display.
        private ArrayList expressionTracker;

        private Button lastButtonPressed;

        // Used to check for dividing by zero.
        char lastDigitPressed;

        char lastButtonPressedText = 'z';

        public Form1()
        {
            InitializeComponent();
            display.SelectionAlignment = HorizontalAlignment.Right;
            expressionTracker = new ArrayList();
        }

        // Converts the argument's text to a character and uses its ASCII key to 
        // determine if it's a number
        private bool isNumberButton(Button button) 
        {
            char t = button.Text.ElementAt(0);
            if (t <= 57 && t >= 48) return true;
            else return false;
        }
         
        // This purpose of this method is to abstract some important steps necessary to take each
        // time a button is pressed. The sender is then passed off to the appropriate event handler.
        private void button_Click(object sender, EventArgs e) 
        {
            lastButtonPressed = (Button) sender;

            // If the sender is a number button
            if (isNumberButton((Button) sender))
            {
                // Convert the string to a character
                lastDigitPressed = lastButtonPressed.Text.ElementAt(0);

                // If equals is pressed then another number is pressed, the user is trying to start
                // a new expression, so we need to clear the running total.
                if (equalsJustPressed)
                {
                    runningTotal = 0;
                    equalsJustPressed = false;
                }

                // Number buttons
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
            else
            {

                // Operator buttons

                // An operator button being pressed signifies a new term being added, so the 
                // decimal-related variables should be reset to default.
                decimalReset();

                // Test if the user has pressed two operators in a row. If they have, switch to the
                // else statement which sets currentOperator to the most recent operator selected
                if (lastButtonPressedText != '+' && lastButtonPressedText != '-'
                    && lastButtonPressedText != '*' && lastButtonPressedText != '/')
                {
                    // first check to see if the user has tried to divide by 0
                    if (lastDigitPressed.Equals('0') && currentOperation == Operation.DIVIDE)
                    {
                        display.Text = "Cannot divide by zero.";
                        // set equalsJustPressed to true to simulate C being pressed
                        equalsJustPressed = true;
                        // set the operation to ADD so that performCurrentOperation doesn't switch to the 
                        // DIVIDE case the next time the user clicks an operation.
                        currentOperation = Operation.ADD;
                    }
                    else
                    {
                        if (sender == addButton) addButton_Click(sender, e);
                        if (sender == subtractButton) subtractButton_Click(sender, e);
                        if (sender == multiplyButton) multiplyButton_Click(sender, e);
                        if (sender == divideButton) divideButton_Click(sender, e);
                    }
                }             
            }
            lastButtonPressedText = lastButtonPressed.Text.ElementAt(0);
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            // No matter what, reset decimal logic.
            decimalReset();

            // Same logic as in button_Click: check for division by zero.
            if (lastDigitPressed.Equals('0') && currentOperation == Operation.DIVIDE)
            {
                display.Text = "Cannot divide by zero.";
                // set equalsJustPressed to true to simulate C being pressed
                equalsJustPressed = true;
                // set the operation to ADD so that performCurrentOperation doesn't switch to the 
                // DIVIDE case the next time the user clicks an operation.
                currentOperation = Operation.ADD;
            }
            else
            {
                performCurrentOperation();
                equalsJustPressed = true;
                currentOperation = Operation.ADD;
                display.Text = Convert.ToString(runningTotal);
                display.SelectionAlignment = HorizontalAlignment.Right;
            }
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

        private void decimalButton_Click(object sender, EventArgs e)
        {
            decimalOn = true;
            //currentNumber = 0;
            //display.Text = "TOO HARD";
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
            decimalReset();
            currentNumber = 0;
            runningTotal = 0;
            expressionTracker.Clear();
            currentOperation = Operation.ADD;
            display.Text = Convert.ToString(currentNumber);
            display.SelectionAlignment = HorizontalAlignment.Right;
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
            if (decimalOn)
            {
                currentNumber += (1.0 / decimalDivider);
                decimalDivider *= 10.0;
            }
            else
            {
                currentNumber *= 10;
                currentNumber += 1;
            }
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

        // Encapsulates the reset of decimalOn and decimalPlaces into one line. This adds safety 
        // because both variables should be reset any time one should be reset. Calling this function
        // ensures that this is also the case, and also reduces the lines of code and is more semantic.
        private void decimalReset() 
        {
            decimalOn = false;
            decimalDivider = 10.0;
        }

        public static void Form1_KeyDown(object sender, KeyEventArgs e) 
        {
            ((Form1)sender).display.Text = "keypressed";
            ((Form1)sender).button2.Text = "ke";
        }
    }
}
