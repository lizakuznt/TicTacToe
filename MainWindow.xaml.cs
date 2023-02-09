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

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private Brush Green;
        public string xtoc = "X";
        public bool isTurnPlayer1 { get; set; }
        public int Counter { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            Start();

        }

        public void Start()
        {
            Counter = 0;

            btn1.Content = string.Empty;
            btn2.Content = string.Empty;
            btn3.Content = string.Empty;
            btn4.Content = string.Empty;
            btn5.Content = string.Empty;
            btn6.Content = string.Empty;
            btn7.Content = string.Empty;
            btn8.Content = string.Empty;
            btn9.Content = string.Empty;

            btn1.Background = Brushes.White;
            btn2.Background = Brushes.White;
            btn3.Background = Brushes.White;
            btn4.Background = Brushes.White;
            btn5.Background = Brushes.White;
            btn6.Background = Brushes.White;
            btn7.Background = Brushes.White;
            btn8.Background = Brushes.White;
            btn9.Background = Brushes.White;


        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            isTurnPlayer1 ^= true;

            var button = sender as Button;

            button.Content = isTurnPlayer1 ? "X" : "O";

            Counter++;
            if (Counter > 9)
            {
                Robot();
                if (Message())
                {
                    Start();
                }
            }

            if (Winner())
            {
                Start();
                Robot();
            }
        }

        private void Robot()
        {
            Button[] buttons = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            Random r = new Random();
            int tic;
            do
            {
                tic = r.Next(0, 9);
            } while (!(buttons[tic].Content == "" || buttons[tic].Content == null));
            if (xtoc == "X")
            {
                buttons[tic].Content = "O";
            }
            else
            {
                buttons[tic].Content = "X";
            }
            buttons[tic].IsEnabled = false;
            if (Winner())
            {
                return;
            }
        }
        private bool Winner()
        {
            if (btn1.Content != string.Empty && btn1.Content == btn2.Content && btn2.Content == btn3.Content)
            {
                btn1.Background = Brushes.Green;
                btn2.Background = Brushes.Green;
                btn3.Background = Brushes.Green;
                MessageBox.Show(btn1.Content + " winner");
                return true;
            }
            if (btn4.Content != string.Empty && btn4.Content == btn5.Content && btn5.Content == btn6.Content)
            {
                btn4.Background = Brushes.Green;
                btn5.Background = Brushes.Green;
                btn6.Background = Brushes.Green;
                MessageBox.Show(btn4.Content + " winner");
                return true;
            }
            if (btn7.Content != string.Empty && btn7.Content == btn8.Content && btn8.Content == btn9.Content)
            {
                btn7.Background = Brushes.Green;
                btn8.Background = Brushes.Green;
                btn9.Background = Brushes.Green;
                MessageBox.Show(btn7.Content + " winner");
                return true;
            }
            if (btn1.Content != string.Empty && btn1.Content == btn4.Content && btn4.Content == btn7.Content)
            {
                btn1.Background = Brushes.Green;
                btn4.Background = Brushes.Green;
                btn7.Background = Brushes.Green;
                MessageBox.Show(btn1.Content + " winner");
                return true;
            }
            if (btn2.Content != string.Empty && btn2.Content == btn5.Content && btn5.Content == btn8.Content)
            {
                btn2.Background = Brushes.Green;
                btn5.Background = Brushes.Green;
                btn8.Background = Brushes.Green;
                MessageBox.Show(btn2.Content + " winner");
                return true;
            }
            if (btn3.Content != string.Empty && btn3.Content == btn6.Content && btn6.Content == btn9.Content)
            {
                btn3.Background = Brushes.Green;
                btn6.Background = Brushes.Green;
                btn9.Background = Brushes.Green;
                MessageBox.Show(btn3.Content + " winner");
                return true;
            }
            if (btn1.Content != string.Empty && btn1.Content == btn5.Content && btn5.Content == btn9.Content)
            {
                btn1.Background = Brushes.Green;
                btn5.Background = Brushes.Green;
                btn9.Background = Brushes.Green;
                MessageBox.Show("winner");
                return true;
            }
            if (btn3.Content != string.Empty && btn3.Content == btn5.Content && btn5.Content == btn7.Content)
            {
                btn3.Background = Brushes.Green;
                btn5.Background = Brushes.Green;
                btn7.Background = Brushes.Green;
                MessageBox.Show(btn3.Content + " winner");
                return true;
            }
            return false;
        }
        private bool Message()
        {
            MessageBox.Show("Вы проиграли");
            return true;
        }

    }
}