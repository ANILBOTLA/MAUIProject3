namespace MauiApp2.Views;
using MauiApp2.Models;
public partial class History : ContentPage
{

    public static List<string> Exp { get; private set; }

    public History()
    {
        InitializeComponent();
    }

    public void OnCounterClicked1(object sender, EventArgs e)
    {
        int X = Exp.Count();
        if (X > 0)
        {
            for (int i = 0; i < X; i++)
            {
                //Console.WriteLine(Exp[i]);
                if (i == 0)
                {
                    CounterBtn1.Text = $"{i + 1}). {Exp[i]}";
                    //TodoModel.ReferenceEquals(Exp[i], Exp[i - 1]);
                    SemanticScreenReader.Announce(CounterBtn1.Text);
                }
                if (i == 1)
                {
                    CounterBtn2.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn2.Text);
                }
                if (i == 2)
                {
                    CounterBtn3.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn3.Text);
                }
                if (i == 3)
                {
                    CounterBtn4.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn4.Text);
                }

                if (i == 4)
                {
                    CounterBtn5.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn5.Text);
                }

                if (i == 5)
                {
                    CounterBtn6.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn6.Text);
                }

                if (i == 6)
                {
                    CounterBtn7.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn7.Text);
                }

                if (i == 7)
                {
                    CounterBtn8.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn8.Text);
                }

                if (i == 8)
                {
                    CounterBtn9.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn9.Text);
                }

                if (i == 9)
                {
                    CounterBtn10.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn10.Text);
                }
                if (i == 10)
                {
                    CounterBtn11.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn11.Text);
                }
                if (i == 11)
                {
                    CounterBtn12.Text = $"{i + 1}). {Exp[i]}";
                    SemanticScreenReader.Announce(CounterBtn12.Text);
                }

            }
        }

    }
    internal static void printHistory(List<string> expressions)
    {
        Exp = expressions;
        Console.WriteLine(Exp);
    }

}