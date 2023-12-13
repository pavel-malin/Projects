using System;
using System.Collections.Generic;
using System.Windows;

namespace task4
{
    public partial class MainWindow : Window
    {
        private List<int> years;
        private Dictionary<string, int> months;
        private List<int> days;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            years = new List<int>();
            for (int year = 1900; year <= 2100; year++)
            {
                years.Add(year);
            }

            months = new Dictionary<string, int>
            {
                { "Январь", 1 },
                { "Февраль", 2 },
                { "Март", 3 },
                { "Апрель", 4 },
                { "Май", 5 },
                { "Июнь", 6 },
                { "Июль", 7 },
                { "Август", 8 },
                { "Сентябрь", 9 },
                { "Октябрь", 10 },
                { "Ноябрь", 11 },
                { "Декабрь", 12 }
            };

            days = new List<int>();
            // Начально заполняем дни для января
            UpdateDays(31);

            // Привязываем данные к выпадающим спискам
            YearComboBox.ItemsSource = years;
            MonthComboBox.ItemsSource = months.Keys;
            DayComboBox.ItemsSource = days;
        }

        private void UpdateDays(int daysCount)
        {
            days.Clear();
            for (int day = 1; day <= daysCount; day++)
            {
                days.Add(day);
            }
        }

        private void YearComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // После выбора года, разблокируем выбор месяца
            MonthComboBox.IsEnabled = true;
        }

        private void MonthComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // После выбора месяца и года, разблокируем выбор дня
            DayComboBox.IsEnabled = true;

            string selectedMonthName = (string)MonthComboBox.SelectedItem;
            int selectedMonth = months[selectedMonthName];
            int selectedYear = (int)YearComboBox.SelectedItem;
            int daysCount = DateTime.DaysInMonth(selectedYear, selectedMonth);

            // Обновляем список дней для выбранного месяца и года
            UpdateDays(daysCount);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedYear = (int)YearComboBox.SelectedItem;
            string selectedMonthName = (string)MonthComboBox.SelectedItem;
            int selectedMonth = months[selectedMonthName]; 
            int selectedDay = (int)DayComboBox.SelectedItem;

            DateTime selectedDate = new DateTime(selectedYear, selectedMonth, selectedDay);
            TimeSpan timeSpan = DateTime.Now - selectedDate;

            int calculatedYears = timeSpan.Days / 365; 
            int calculatedMonths = timeSpan.Days % 365 / 30; 
            int calculatedDays = timeSpan.Days % 365 % 30;

            string message = $"Прошло {calculatedYears} год, {calculatedMonths} месяцев и {calculatedDays} дней с выбранной даты до текущего момента.";

            MessageBox.Show(message, "Результат");
        }
    }
}
