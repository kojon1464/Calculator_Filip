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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long currentNumber = 0;
        bool isDecimal = false;
        long divider = 1;
 
        // x is appended to currentNumber
        void AppendNumber(long x)
        {
            if(currentNumber<100000000000000 && currentNumber > -100000000000000)
            {
                currentNumber = currentNumber * 10 + x;
                if(isDecimal)
                {
                    divider *= 10;
                }
            }
        }

        // Display currentNumber in TextBlock
        void ShowNumber()
        {
            Double number = (Double)currentNumber / (Double)divider;
            if(isDecimal && divider == 1)
            {
                TextBox_Result.Text = number.ToString() + ",";
            }
            else
            {
                TextBox_Result.Text = number.ToString();
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
                divider = 1;
                ShowNumber();
            }
        }
    }
}
