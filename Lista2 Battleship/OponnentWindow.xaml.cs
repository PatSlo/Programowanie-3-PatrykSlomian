using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;
using System.Windows.Data;

namespace Lista2_Battleship
{
    public partial class OpponentWindow : Window
    {
        public OpponentWindow()
        {
            InitializeComponent();
            Start();
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

                    Binding binding = new Binding($"PersonIdTwo[" + (tag1) + "]");
                    binding.Mode = BindingMode.TwoWay;
                    binding.Converter = new YesNoToBooleanConverter();
                    btn.SetBinding(Button.BackgroundProperty, binding);

                    btn.Name = litera.ToString() + liczba.ToString(); 
                    btn.Click += Btn_Click;

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

                    Binding binding = new Binding($"PersonIdOne[" + (tag2) + "]");
                    binding.Mode = BindingMode.TwoWay;
                    binding.Converter = new YesNoToBooleanConverter2();
                    btn.SetBinding(Button.BackgroundProperty, binding);

                    btn.Name = litera.ToString() + liczba2.ToString();
                    btn.Click += Button_Click_shot;

                    Grid.SetRow(btn, liczba2 + 11); // Indeksy w siatce są od 0 do 9
                    Grid.SetColumn(btn, litera - 'A'); // Indeksy w siatce są od 0 do 9

                    plnPersonForm.Children.Add(btn);
                    tag2++;
                }
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                Button button = (Button)sender;
                if (((GameModel)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 0)
                    ((GameModel)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]++;
                else if (((GameModel)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())] == 1)
                    ((GameModel)plnPersonForm.DataContext).PersonIdTwo[Convert.ToInt32(btn.Tag.ToString())]--;
            }
        }

        private void Button_Click_shot(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (((GameModel)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 0 || ((GameModel)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] == 1)
                ((GameModel)plnPersonForm.DataContext).PersonIdOne[Convert.ToInt32(btn.Tag.ToString())] += 2;
        }
    }
}
