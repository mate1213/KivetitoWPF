using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace KivetitoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Dalok_Click(object sender, RoutedEventArgs e)
        {
            TabControl_KezeloFelulet.SelectedIndex = 0;

            Brush temp = Brushes.Red;
            BorderSetter(Btn_Dalok, 3, temp);
            BorderSetterDefault(Btn_Igek);
            BorderSetterDefault(Btn_Kepek);
            BorderSetterDefault(Btn_Videok);
        }

        private void Btn_Igek_Click(object sender, RoutedEventArgs e)
        {
            TabControl_KezeloFelulet.SelectedIndex = 1;

            Brush temp = Brushes.Red;
            BorderSetterDefault(Btn_Dalok);
            BorderSetter(Btn_Igek, 3, temp);
            BorderSetterDefault(Btn_Kepek);
            BorderSetterDefault(Btn_Videok);
        }

        private void Btn_Kepek_Click(object sender, RoutedEventArgs e)
        {
            TabControl_KezeloFelulet.SelectedIndex = 2;

            Brush temp = Brushes.Red;
            BorderSetterDefault(Btn_Dalok);
            BorderSetterDefault(Btn_Igek);
            BorderSetter(Btn_Kepek, 3, temp);
            BorderSetterDefault(Btn_Videok);
        }

        private void Btn_Videok_Click(object sender, RoutedEventArgs e)
        {
            TabControl_KezeloFelulet.SelectedIndex = 3;

            Brush temp = Brushes.Red;
            BorderSetterDefault(Btn_Dalok);
            BorderSetterDefault(Btn_Igek);
            BorderSetterDefault(Btn_Kepek);
            BorderSetter(Btn_Videok, 3, temp);
        }

        private void Tb_Verstol_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Tb_Verstol_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int inttemp;
            bool booltemp = int.TryParse(tb.Text, out inttemp);
            if (inttemp > 250)
            {
                MessageBox.Show("Nagyobb szám nem elfogadott! Max:250", "Hiba!");
                tb.Text = "";
            }
        }

        private void Tb_Keres_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.Foreground = Brushes.Black;
        }

        private void BorderSetterDefault(Button btn)
        {
            try
            {
                btn.ClearValue(BorderBrushProperty);
                btn.BorderThickness = new Thickness(1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Hiba");
            }
        }

        private void BorderSetter(Button btn, int bordertickness, Brush brushes)
        {
            try
            {
                btn.BorderBrush = (dynamic)brushes;
                btn.BorderThickness = new Thickness(bordertickness);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Hiba");
            }
        }
    }
}
