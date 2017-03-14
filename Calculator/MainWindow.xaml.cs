using System;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long currentNumber = 0;
        int zeroNumber = 0; // number of zeros at the end
        bool isDecimal = false;
        long divider = 1;
 
        // x is appended to currentNumber
        void AppendNumber(long x)
        {
            if(currentNumber<100000000000000 && currentNumber > -100000000000000 && divider< 100000000000000)
            {
                if(x == 0 && isDecimal)
                {
                    zeroNumber++;
                }
                else
                {
                    zeroNumber = 0;
                }

                if (currentNumber>=0)
                {
                    currentNumber = currentNumber * 10 + x;
                }
                else
                {
                    currentNumber = currentNumber * 10 - x;
                }

                if(isDecimal)
                {
                    divider *= 10;
                }
            }
        }

        // Display currentNumber in TextBlock
        void ShowNumber()
        {
            String number = ((Double)currentNumber / (Double)divider).ToString("0.###############");
            if(isDecimal && divider == 1)
            {
                TextBox_Result.Text = number + ",";
            }
            else
            {
                for (int i = 0; i < zeroNumber; i++)
                {
                    if(i==0 && !number.Contains(","))
                    {
                        number = number + ",";
                    }
                    number = number + "0";
                }
                TextBox_Result.Text = number;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            ShowNumber();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(1);
            ShowNumber();
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(2);
            ShowNumber();
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(3);
            ShowNumber();
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(4);
            ShowNumber();
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(5);
            ShowNumber();
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(6);
            ShowNumber();
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(7);
            ShowNumber();
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(8);
            ShowNumber();
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(9);
            ShowNumber();
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(0);
            ShowNumber();
        }

        private void Button_Comma_Click(object sender, RoutedEventArgs e)
        {
            if(isDecimal == false)
            {
                isDecimal = true;
                ShowNumber();
            }
        }

        private void Button_SignChange_Click(object sender, RoutedEventArgs e)
        {
            currentNumber *= -1;
            ShowNumber();
        }
    }
}
