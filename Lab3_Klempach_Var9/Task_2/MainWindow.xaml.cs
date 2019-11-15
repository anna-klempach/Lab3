using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Task_2
{
    public partial class MainWindow : Window
    {
        Entry entry;
        BinaryFormatter formatter;
        ObservableCollection<Entry> results;
        public MainWindow()
        {
            InitializeComponent();
            entry = new Entry();
            grid.DataContext = entry;
            formatter = new BinaryFormatter();
            results = new ObservableCollection<Entry>();
            lResult.ItemsSource = results;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (this.entry.isFilled())
            {
                using (FileStream fstream = new FileStream("entries.txt", FileMode.Append))
                {

                    formatter.Serialize(fstream, this.entry);
                }
                MessageBox.Show("Информация записана в файл.");
                this.entry.Clear();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            
        }

        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            using (FileStream fstream = new FileStream("entries.txt", FileMode.OpenOrCreate))
            {
                int k = 1;
                while (fstream.Position != fstream.Length)
                {
                    Entry entry = (Entry)formatter.Deserialize(fstream);
                    entry.index = k;
                    results.Add(entry);
                    k += 1;
                }
            }
        }
    }
}
