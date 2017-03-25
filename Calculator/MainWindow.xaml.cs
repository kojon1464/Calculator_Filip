using System;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Operation { none, plus, minus, times, divide, root};
        Operation currentOperation;
        bool isPerformingOperation = false; // true if operation haven't been performed
        bool changedNumber = false; // true if during operation number has been changed

        double memorizedNumber;
        bool displayedMemorizedNumber = false;

        long currentNumber = 0;
        int zeroNumber = 0; // number of zeros at the end
        bool isDecimal = false;
        long divider = 1;


        void Clear()
        {
            currentNumber = 0;
            zeroNumber = 0;
            divider = 1;
            isDecimal = false;
            memorizedNumber = 0;
            changedNumber = false;
            isPerformingOperation = false;
            currentOperation = Operation.none;
            TextBox_Result.Text = "0";
            displayedMemorizedNumber = false;
        }

        void ClearCurrentNumber()
        {
            //cleaning current number
            currentNumber = 0;
            zeroNumber = 0;
            isDecimal = false;
            divider = 1;
        }

        void DeleteLastNumber()
        {
            if(displayedMemorizedNumber)
            {
                string temp = memorizedNumber.ToString();
                temp = temp.Remove(temp.Length - 1);
                memorizedNumber = Convert.ToDouble(temp);
                TextBox_Result.Text = temp;
            }
            else
            {
                if (divider > 1)
                {
                    divider /= 10;
                }
                else if (isDecimal)
                {
                    isDecimal = false;
                    goto Jump;
                }
                currentNumber = (currentNumber - currentNumber % 10) / 10;
            Jump:
                ShowNumber();
            } 
        }

        void PerformOperation()
        {
            switch (currentOperation)
            {
                case Operation.plus:
                    memorizedNumber = memorizedNumber + ((Double)currentNumber / (Double)divider);
                    TextBox_Result.Text = memorizedNumber.ToString();
                    ClearCurrentNumber();
                    break;
                case Operation.minus:
                    memorizedNumber = memorizedNumber - ((Double)currentNumber / (Double)divider);
                    TextBox_Result.Text = memorizedNumber.ToString();
                    ClearCurrentNumber();
                    break;
                case Operation.times:
                    memorizedNumber = memorizedNumber * ((Double)currentNumber / (Double)divider);
                    TextBox_Result.Text = memorizedNumber.ToString();
                    ClearCurrentNumber();
                    break;
                case Operation.divide:
                    memorizedNumber = memorizedNumber / ((Double)currentNumber / (Double)divider);
                    TextBox_Result.Text = memorizedNumber.ToString();
                    ClearCurrentNumber();
                    break;
                case Operation.root:
                    memorizedNumber = Math.Sqrt(memorizedNumber);
                    TextBox_Result.Text = memorizedNumber.ToString();
                    break;
                default:
                    break;
            }
            currentOperation = Operation.none;
            displayedMemorizedNumber = true;
            isPerformingOperation = false;
            changedNumber = false;
        }

        void MemorizeNumber()
        {
            if (changedNumber)
            {
                if (isPerformingOperation)
                {
                    PerformOperation();
                }
                else
                {
                    memorizedNumber = (Double)currentNumber / (Double)divider;
                    ClearCurrentNumber();
                }
            }
            isPerformingOperation = true;
            changedNumber = false;
            if (currentOperation == Operation.root)
            {
                PerformOperation();

            }
        }
        
        // x is appended to currentNumber
        void AppendNumber(long x)
        {
            changedNumber = true;
            if (currentNumber<100000000000000 && currentNumber > -100000000000000 && divider< 100000000000000)
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
            displayedMemorizedNumber = false;
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

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            MemorizeNumber();
            currentOperation = Operation.plus;
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            MemorizeNumber();
            currentOperation = Operation.minus;
        }

        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            MemorizeNumber();
            currentOperation = Operation.divide;
        }

        private void Button_Times_Click(object sender, RoutedEventArgs e)
        {
            MemorizeNumber();
            currentOperation = Operation.times;
        }

        private void Button_Equals_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation();
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Button_Root_Click(object sender, RoutedEventArgs e)
        {
            currentOperation = Operation.root;
            MemorizeNumber();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            DeleteLastNumber();
        }
    }
}
