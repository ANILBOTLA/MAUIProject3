namespace MauiApp2.Views;
using System;
using System.Linq.Expressions;

public partial class Main12 : ContentPage
{


    List<string> Expressions = new List<string>();
    public Main12()
    {
        InitializeComponent();
        OnClear(this, null);
    }
    public Main12(Microsoft.Maui.Graphics.Color clr)
    {
        InitializeComponent();
        OnClear(this, null);
        this.grid_name.BackgroundColor = clr;

    }
    string currentEntry = "";
    int currentState = 1;
    string mathOperator;
    double firstNumber, secondNumber;
    string decimalFormat = "N0";
    bool expression = false;
    string eval = "";

    Stack<double> values = new Stack<double>();
    Stack<Char> ops = new Stack<char>();


    void OnSelectNumber(object sender, EventArgs e)
    {

        Button button = (Button)sender;
        string pressed = button.Text;

        currentEntry += pressed;
        this.eval += pressed;

        if ((this.resultText.Text == "0" && pressed == "0")
            || (this.currentEntry.Length <= 1 && pressed != "0")
            || currentState < 0)
        {
            this.resultText.Text = "";
            if (currentState < 0)
                currentState *= -1;
        }

        if (pressed == "." && decimalFormat != "N2")
        {
            decimalFormat = "N2";
        }

        if (this.expression)
        {
            this.resultText.Text += this.eval;
        }
        else
        {
            this.resultText.Text += pressed;
        }
        this.values.Push(int.Parse(pressed));
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        LockNumberValue(resultText.Text);

        currentState = -2;
        Button button = (Button)sender;
        string pressed = button.Text;
        mathOperator = pressed;

        this.eval += pressed;
        if (pressed == "(")
        {
            this.ops.Push(char.Parse(pressed));
            expression = true;
        }
        else if (pressed == ")")
        {
            while (this.ops.Peek() != '(')
            {
                this.values.Push(Calculator.Calculate(this.values.Pop(), this.values.Pop(), (this.ops.Pop()).ToString()));
            }
            this.ops.Pop();
        }
        else if (pressed == "+" || pressed == "-" || pressed == "×" || pressed == "/")
        {

            while (this.ops.Count > 0 && hasPrecedence(char.Parse(pressed), this.ops.Peek()))
            {
                this.values.Push(Calculator.Calculate(this.values.Pop(), this.values.Pop(), (this.ops.Pop()).ToString()));
            }
            this.ops.Push(char.Parse(pressed));
        }

        this.resultText.Text = this.eval;


    }

    public static bool hasPrecedence(char op1, char op2)
    {
        if (op2 == '(' || op2 == ')')
        {
            return false;
        }
        if ((op1 == '*' || op1 == '/') &&
            (op2 == '+' || op2 == '-'))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

            this.currentEntry = string.Empty;
        }
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        decimalFormat = "N0";
        this.resultText.Text = "0";
        this.currentEntry = string.Empty;
        this.eval = "";
        this.expression = false;
        this.CurrentCalculation.Text = "";
    }


    void OnSqrt(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            mathOperator = "sqrt";
            currentState = 2;

        }
    }

    void OnModulo(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            mathOperator = "%";
            currentState = 2;
        }
    }


    public void OnCalculate(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            if (secondNumber == 0)
                LockNumberValue(resultText.Text);
            double result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);
            this.CurrentCalculation.Text = $"{firstNumber} {mathOperator} {secondNumber}";
            this.resultText.Text = result.ToTrimmedString(decimalFormat);
            Expressions.Add(CurrentCalculation.Text + "= " + resultText.Text);
            History.printHistory(Expressions);
            //History.OnCounterClicked1(sender,e);
            firstNumber = result;
            secondNumber = 0;
            currentState = -1;
            currentEntry = string.Empty;
        }
        else if (expression)
        {
            this.CurrentCalculation.Text = $"{this.eval}";
            this.resultText.Text = this.values.Pop().ToString();
        }
    }


    void OnNegative(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            secondNumber = -1;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

    void OnPercentage(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
            secondNumber = 0.01;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }

}
