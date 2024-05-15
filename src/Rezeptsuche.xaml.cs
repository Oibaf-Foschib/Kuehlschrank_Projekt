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
using System.Windows.Shapes;

namespace Fabio_Leo_Kühlschrankplaner
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();

            Zutat1.SelectionChanged += ComboBox_SelectionChanged;
            Zutat2.SelectionChanged += ComboBox_SelectionChanged;
            Zutat3.SelectionChanged += ComboBox_SelectionChanged;
            Zutat4.SelectionChanged += ComboBox_SelectionChanged;
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender == Zutat1 && Zutat1.SelectedItem != null)
            {

                Zutat2.Visibility = Visibility.Visible;
            }
            else if (sender == Zutat2 && Zutat2.SelectedItem != null)
            {

                Zutat3.Visibility = Visibility.Visible;
            }
            else if (sender == Zutat3 && Zutat3.SelectedItem != null)
            {

                Zutat4.Visibility = Visibility.Visible;
            }

        }


        private void btnsuche_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}