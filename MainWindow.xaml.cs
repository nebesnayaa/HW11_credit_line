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

namespace HW11_credit_line
{
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty IncomeProperty = DependencyProperty.Register(
            "Income", typeof(double), typeof(MainWindow), new PropertyMetadata(0.0));

        public double Income
        {
            get { return (double)GetValue(IncomeProperty); }
            set { SetValue(IncomeProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreditSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CreditSlider.Value = Math.Round(e.NewValue);
        }

        private void IncomeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(IncomeTextBox.Text, out double income))
            {
                CreditSlider.IsEnabled = true;
                CreditSlider.Maximum = income * 2;
            }
        }
    }
}
