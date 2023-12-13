using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace task5
{
    public partial class MainWindow : Window
    {
        private string fileContent;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                fileContent = File.ReadAllText(filename);
                fileContentTextBox.Text = fileContent;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine(fileContent);
                }
            }
        }
    }
}
