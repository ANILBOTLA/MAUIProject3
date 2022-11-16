namespace MauiApp2.Views;

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
                CounterBtn1.Text = Exp[i];
                SemanticScreenReader.Announce(CounterBtn1.Text);
            }
        }
        
    }
    internal static void printHistory(List<string> expressions)
    {
        Exp = expressions;
        Console.WriteLine(Exp);
    }

}