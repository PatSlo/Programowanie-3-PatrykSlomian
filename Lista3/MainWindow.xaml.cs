using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Lista3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> listOfGames = new List<Game>();
        string path = "C://Users//malym//source//repos//Programowanie 3 PatSlo//Lista3//test.xml";
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(path))
            {
                listOfGames = Serialization.DeserializeToObject<List<Game>>(path);
                dataGridGame.ItemsSource = listOfGames;
            }
            else
            {
                listOfGames.Add(new Game("Tomb Raider", "PC", "10,68zł"));
                listOfGames.Add(new Game("Marvel's Spider-Man Remastered", "PS4", "189,99zł"));
                listOfGames.Add(new Game("Gotham Knights", "PC", "65,67zł"));
                dataGridGame.ItemsSource = listOfGames;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serialization.SerializeToXml<List<Game>>(listOfGames, path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
            {
                Window1 okno = new Window1();
                Game game = new Game();
                okno.DataContext = game;
                okno.ShowDialog();
                if (okno.IsOkPressed)
                {
                    listOfGames.Add(game);
                    dataGridGame.Items.Refresh();
                }
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                if (dataGridGame.SelectedItem != null)
                {
                    Window1 okno = new Window1();
                    Game game = new Game((Game)dataGridGame.SelectedItem);
                    okno.DataContext = game;
                    okno.ShowDialog();
                    if (okno.IsOkPressed)
                    {
                        int index = listOfGames.IndexOf((Game)dataGridGame.SelectedItem);
                        listOfGames[index] = game;
                        dataGridGame.Items.Refresh();
                    }
                }
            }
        }
    }

