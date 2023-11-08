using System.Windows;
using System.Windows.Controls;

namespace Lista2_Calculator
{
    public partial class MainWindow : Window
    {
        double tempt = 0;
        string operation = "Plus";
        string output = "";
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;
            switch (name)
            {
                case "Button9":
                    output += "0";
                    Result.Text = output;
                    break;

                case "Button0":
                    output += "1";
                    Result.Text = output;
                    break;

                case "Button1":
                    output += "2";
                    Result.Text = output;
                    break;

                case "Button2":
                    output += "3";
                    Result.Text = output;
                    break;

                case "Button3":
                    output += "4";
                    Result.Text = output;
                    break;

                case "Button4":
                    output += "5";
                    Result.Text = output;
                    break;

                case "Button5":
                    output += "6";
                    Result.Text = output;
                    break;

                case "Button6":
                    output += "7";
                    Result.Text = output;
                    break;

                case "Button7":
                    output += "8";
                    Result.Text = output;
                    break;

                case "Button8":
                    output += "9";
                    Result.Text = output;
                    break;
            }
        }

        private void Button_Arithmetic_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            if (name == "Button12")
            {
                if (output != "")
                {
                    tempt = double.Parse(output);
                    output = "";
                    operation = "Plus";
                }
            }

            else if (name == "Button13")
            {
                if (output != "")
                {
                    tempt = double.Parse(output);
                    output = "";
                    operation = "Minus";
                }
            }

            else if (name == "Button14")
            {
                if (output != "")
                {
                    tempt = double.Parse(output);
                    output = "";
                    operation = "Mult";
                }
            }

            else if (name == "Button15")
            {
                if (output != "")
                {
                    tempt = double.Parse(output);
                    output = "";
                    operation = "Div";
                }
            }
        }

        private void Button_Equal_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "Plus":
                    double outputTemp_P = tempt + double.Parse(output);
                    output = outputTemp_P.ToString();
                    Result.Text = output;
                    break;

                case "Minus":
                    double outputTemp_M = tempt - double.Parse(output);
                    output = outputTemp_M.ToString();
                    Result.Text = output;
                    break;

                case "Mult":
                    double outputTemp_Ml = tempt * double.Parse(output);
                    output = outputTemp_Ml.ToString();
                    Result.Text = output;
                    break;

                case "Div":
                    double outputTemp_D = tempt / double.Parse(output);
                    output = outputTemp_D.ToString();
                    Result.Text = output;
                    break;
            }
        }

        private void Button_Common_Click(object sender, RoutedEventArgs e)
        {
            output = output + ",";
            Result.Text = output;
        }

        private void Button_Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(output))
            {
                output = output.Substring(0, output.Length - 1);
                Result.Text = output;
            }
        }
    }
}
