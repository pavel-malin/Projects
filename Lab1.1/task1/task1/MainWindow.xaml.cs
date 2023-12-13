using System;
using System.Windows;
using System.Windows.Controls;

namespace task1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(NumberATextBox.Text, out double numberA) &&
                double.TryParse(NumberBTextBox.Text, out double numberB))
            {
                string operation = ((Button)sender).Content.ToString();
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = numberA + numberB;
                        break;
                    case "-":
                        result = numberA - numberB;
                        break;
                    case "*":
                        result = numberA * numberB;
                        break;
                    case "/":
                        if (numberB != 0)
                        {
                            result = numberA / numberB;
                        }
                        else
                        {
                            ResultTextBox.Text = "Ошибка: деление на ноль!";
                            return;
                        }
                        break;
                }

                ResultTextBox.Text = result.ToString();
            }
            else
            {
                ResultTextBox.Text = "Ошибка: введите числа в поля 'А' и 'Б'!";
            }
        }
    }
}
