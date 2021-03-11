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

namespace Exemple
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ChangeClockStyle();
            ChangePrevisionsStyle();
            BindText();
            BingButtonTextBox();
            SetClock();
        }

        private void SetClock()
        {
            txbHorloge.Text = DateTime.Now.ToString();
        }

        private void ChangeClockStyle()
        {
            txbHorloge.Background = Brushes.BlueViolet;
            txbHorloge.Foreground = Brushes.Gold;
        }

        private void ChangePrevisionsStyle()
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.CadetBlue, 0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Gray, 0.5));
            myBrush.GradientStops.Add(new GradientStop(Colors.Plum, 1));

            stpPrevisions.Background = myBrush;
        }

            // Liaison de deux contrôles de l'IU
        private void BindText()
        {
            //Binding liaison = new Binding("Text");
            //liaison.Source = txtValue;
            //lblValue.SetBinding(Label.ContentProperty, liaison);

            Binding binding = new Binding("Text")
            {
                Source = txtValue
            };
            lblValue.SetBinding(Label.ContentProperty, binding);
        }

            //Liaison du bouton btnAccept et le TextBox txtTextBtn
        private void BingButtonTextBox()
        {
            Binding binding = new Binding("Content")
            {
                Source = btnAccept
            };
            txtTextBtn.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
