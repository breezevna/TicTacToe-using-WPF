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

namespace tictactoe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLogic gameLogic;

        private bool IsGameEnded;

        private string winner;
        public MainWindow()
        {
            InitializeComponent();

            gameLogic = new GameLogic(TextBlock11.Text, TextBlock12.Text, TextBlock13.Text,
                                      TextBlock21.Text, TextBlock22.Text, TextBlock23.Text,
                                      TextBlock31.Text, TextBlock32.Text, TextBlock33.Text);
        }


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsGameEnded = false;
            TextBlock textBlock = (TextBlock)sender;
            Border border = (Border)textBlock.Parent;

            if (gameLogic.NextPlayer() == "X")
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8EF13C"));
                textBlock.Text = "X";
                textBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8EF13C"));
                Player1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8EF13C"));
                Player2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCCCCC"));
            }
            else
            {
                border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2400"));
                textBlock.Text = "O";
                textBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2400"));
                Player2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2400"));
                Player1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCCCCC"));
            }
            gameLogic.UpdateValues(TextBlock11.Text, TextBlock12.Text, TextBlock13.Text,
                                      TextBlock21.Text, TextBlock22.Text, TextBlock23.Text,
                                      TextBlock31.Text, TextBlock32.Text, TextBlock33.Text);

            winner = gameLogic.CheckWinners();

            if (winner == "X") 
            { 
                Win.Text = "Won: Player 1";
                IsGameEnded = true;
            }
            if (winner == "O")
            {
                Win.Text = "Won: Player 2";
                IsGameEnded = true;
            }

            int count = 0;
            for(int i = 1; i <= 3; i++)
            {
                for(int j = 1; j <= 3; j++)
                {
                    string textBlockName = $"TextBlock{i}{j}";
                    TextBlock textNameFinder = (TextBlock)grid.FindName(textBlockName);
                     if(textNameFinder.Text != "")
                     {
                        count++;
                     }
                }
            }

            if(count == 9 && Win.Text  == "Won:")
            {
                Win.Text = "Draw!";
            }
            if(IsGameEnded == true)
            {
                TextBlock11.IsEnabled = false;
                TextBlock12.IsEnabled = false;
                TextBlock13.IsEnabled = false;
                TextBlock21.IsEnabled = false;
                TextBlock22.IsEnabled = false;
                TextBlock23.IsEnabled = false;
                TextBlock31.IsEnabled = false;
                TextBlock32.IsEnabled = false;
                TextBlock33.IsEnabled = false;
            }
        }

        private void btnRestar_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 1; i <= 3; i++)
            {
                for(int j = 1; j <= 3; j++)
                {
                    string textBlockName = $"TextBlock{i}{j}";
                    string borderName = $"Border{i}{j}";

                    Border border = (Border)grid.FindName(borderName);
                    TextBlock testBlock = (TextBlock)grid.FindName(textBlockName);
                    testBlock.IsEnabled = true;
                    testBlock.Text = "";
                    border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCCCCC"));
                }
            }
            Win.Text = "Won:";
            Player1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCCCCC"));
            Player2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CCCCCC"));

        }
    }
}
