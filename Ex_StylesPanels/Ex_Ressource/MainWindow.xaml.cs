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
using System.Diagnostics;

namespace Ex_Ressource
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lsbLignes.Items.Add(StackPanelPrincipal.FindResource("strApp1").ToString());
            lsbLignes.Items.Add(StackPanelPrincipal.FindResource("strWin2").ToString());
            lsbLignes.Items.Add(StackPanelPrincipal.FindResource("strWin3").ToString());
        }

        private void MenuItemQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void MenuItemCanvas_Click(object sender, RoutedEventArgs e)
        {
            Panneau panneau = new Panneau();
            panneau.Show();
        }

        private void MenuItemDessiner_Click(object sender, RoutedEventArgs e)
        {
            Toile toile = new Toile();
            toile.Show();
        }

        private void MenuItemDockPanel_Click(object sender, RoutedEventArgs e)
        {
            Quai quai = new Quai();
            quai.Show();
        }
    }
}
