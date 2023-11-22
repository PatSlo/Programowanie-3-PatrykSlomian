using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Lista2_Battleship
{

    public partial class MainWindow : Window
    {
        int click = 0;
        public MainWindow()
        {
            InitializeComponent();
            Start();
            int[] tab = new int[100];
            int[] tab2 = new int[100];
            GameModel gra = new GameModel(tab, tab2);
            plnPersonForm.DataContext = gra;
            OpponentWindow okno = new OpponentWindow();
            okno.DataContext = gra;
            okno.Show();
        }

        public void Start()
        {
            int tag1 = 0;
            int tag2 = 0;

            for (char litera = 'A'; litera <= 'J'; litera++)
            {
                for (int liczba = 1; liczba <= 10; liczba++)
                {
                    Button btn = new Button();
                    btn.Content = litera.ToString() + liczba.ToString();
                    btn.Tag = tag1;
                    Binding binding = new Binding($"PersonIdOne[" + (tag1) + "]");
                    binding.Mode = BindingMode.TwoWay;
                    binding.Converter = new YesNoToBooleanConverter();

                    btn.SetBinding(Button.BackgroundProperty, binding);
                    btn.Name = litera.ToString() + liczba.ToString();
                    btn.Click += Button_Click;

                    Grid.SetRow(btn, liczba - 1);
                    Grid.SetColumn(btn, litera - 'A');

                    plnPersonForm.Children.Add(btn);
                    tag1++;
                }
            }

            for (char litera = 'A'; litera <= 'J'; litera++)
            {
                for (int liczba2 = 1; liczba2 <= 10; liczba2++)
                {
                    Button btn = new Button();
                    btn.Content = litera.ToString() + liczba2.ToString();
                    btn.Tag = tag2;

                    Binding binding = new Binding($"PersonIdTwo[" + (tag2) + "]");
                    binding.Mode = BindingMode.TwoWay;
                    binding.Converter = new YesNoToBooleanConverter2();
                    btn.SetBinding(Button.BackgroundProperty, binding);

                    btn.Name = litera.ToString() + liczba2.ToString();
                    btn.Click += Button_Click_shot;

                    Grid.SetRow(btn, liczba2 + 11);
                    Grid.SetColumn(btn, litera - 'A');

                    plnPersonForm.Children.Add(btn);
                    tag2++;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (click <=12)
            { 
            Button btn = (Button)sender;
            if (((GameModel)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0)
                ((GameModel)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]++;
            else if (((GameModel)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((GameModel)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())]--;
                click++;
            }
        }


        private void Button_Click_shot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((GameModel)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((GameModel)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((GameModel)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] += 2;
        }
    }

    public class YesNoToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Black);
                case 0:
                    return new SolidColorBrush(Colors.Transparent);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Colors)
            {
                //if ((Colors).value == Colors.Red)
                //   return 4;
                //else
                //    return 0;
            }
           
                return 0;
        }
    }

    public class YesNoToBooleanConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case 3:
                    return new SolidColorBrush(Colors.Red);
                case 2:
                    return new SolidColorBrush(Colors.Yellow);
                case 1:
                    return new SolidColorBrush(Colors.Transparent);
                case 0:
                    return new SolidColorBrush(Colors.Transparent);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Colors)
            {
                //if ((Colors)value == Colors.Red)
                //    return 4;
                // else
                //   return 0;
            }
            return 0;
        }
    }
}