using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lista2
{
    public partial class MainWindow : Window
    {
        private bool _playerX = true;
        private Button[,] _buttons;

        public MainWindow()
        {
            InitializeComponent();

            _buttons = new Button[3, 3] {{Button0, Button1, Button2},
                                     {Button3, Button4, Button5},
                                     {Button6, Button7, Button8}};
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.Content != null) return;

            button.Content = _playerX ? "X" : "O";
            _playerX = !_playerX;

            if (CheckForWinner())
            {
                MessageBox.Show((_playerX ? "O" : "X") + " wygrywa!");
                ResetBoard();
            }
        }

        private bool CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_buttons[i, 0].Content != null && _buttons[i, 0].Content == _buttons[i, 1].Content && _buttons[i, 1].Content == _buttons[i, 2].Content)
                    return true;

                if (_buttons[0, i].Content != null && _buttons[0, i].Content == _buttons[1, i].Content && _buttons[1, i].Content == _buttons[2, i].Content)
                    return true;
            }

            if (_buttons[0, 0].Content != null && _buttons[0, 0].Content == _buttons[1, 1].Content && _buttons[1, 1].Content == _buttons[2, 2].Content)
                return true;

            if (_buttons[0, 2].Content != null && _buttons[0, 2].Content == _buttons[1, 1].Content && _buttons[1, 1].Content == _buttons[2, 0].Content)
                return true;

            return false;
        }


        private void ResetBoard()
        {
            foreach (Button button in _buttons)
            {
                button.Content = null;
            }
        }
    }
}
