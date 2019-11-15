
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Lab3_Klempach_Var9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Values valueSet;
        ObservableCollection<string> results;
        public MainWindow()
        {
            InitializeComponent();
            valueSet = new Values();
            grid.DataContext = valueSet;

            results = new ObservableCollection<string>();
            lResult.DataContext = results;
        }

        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            this.valueSet.getResults(results);
        }
        private void checkStopBox()
        {
            BindingExpression bindingStop = txtBox_Xstop.GetBindingExpression(TextBox.TextProperty);
            bindingStop.UpdateSource();
        }

        private void checkBothBoxes()
        {
            BindingExpression bindingStart = txtBox_XStart.GetBindingExpression(TextBox.TextProperty);
            bindingStart.UpdateSource();
            this.checkStopBox();
        }
        private void txtBox_Xstop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                this.checkStopBox();
            }
        }

        private void txtBox_Xstop_LostFocus(object sender, RoutedEventArgs e)
        {
            this.checkStopBox();
        }

        private void txtBox_XStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                this.checkBothBoxes();
            }
        }

        private void txtBox_XStart_LostFocus(object sender, RoutedEventArgs e)
        {
            this.checkBothBoxes();
        }
    }
}
