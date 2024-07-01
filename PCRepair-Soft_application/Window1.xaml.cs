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
using System.Data.Entity;
using PCRepair_Soft_application.UserPanel;
using MaterialDesignThemes.Wpf;

namespace PCRepair_Soft_application
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            classes.AppFrame.frMain = FrmMain;

            FrmMain.Navigate(new UserPanel.Admin());
        }

        private void SpisokSotr_Click(object sender, RoutedEventArgs e)
        {
            SpisokSotrudnikov spisoksotrudnikov = new SpisokSotrudnikov();
            spisoksotrudnikov.ShowDialog();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SpisokOborudovania_Click(object sender, RoutedEventArgs e)
        {
            SpisokOborudovaniya spisokoborudovaniya = new SpisokOborudovaniya();
            spisokoborudovaniya.ShowDialog();
        }

        private void SpisokKlientov_Click(object sender, RoutedEventArgs e)
        {
            SpisokKlientov spisokklientov = new SpisokKlientov();
            spisokklientov.ShowDialog();
        }

        private void SpisokUslug_Click(object sender, RoutedEventArgs e)
        {
            SpisokUslug spisokuslug = new SpisokUslug();
            spisokuslug.ShowDialog();
        }
    }
}
