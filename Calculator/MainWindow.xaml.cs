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
        long currentNumber;
 
        // x is appended to currentNumber
        void AppendNumber(long x)
        {
            if(currentNumber<1000000000000000 && currentNumber > -1000000000000000)
            {
                currentNumber = currentNumber * 10 + x;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(1);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(2);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(3);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(4);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(5);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(6);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(7);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(8);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(9);
            TextBox_Result.Text = currentNumber.ToString();
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            AppendNumber(0);
            TextBox_Result.Text = currentNumber.ToString();
        }
    }
}
