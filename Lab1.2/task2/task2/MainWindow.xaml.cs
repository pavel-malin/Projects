using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace task2
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> items;

        public MainWindow()
        {
            InitializeComponent();

            // Создаем пустой список строк
            items = new ObservableCollection<string>();

            // Привязываем список к элементу ListBox
            listBox.ItemsSource = items;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;

            // Добавляем текст в список
            items.Add(text);

            // Очищаем текстовое поле
            textBox.Clear();
        }
    }
}
