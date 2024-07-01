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

namespace PCRepair_Soft_application.UserPanel
{
    /// <summary>
    /// Логика взаимодействия для SpisokUslug.xaml
    /// </summary>
    public partial class SpisokUslug : Window
    {
        public SpisokUslug()
        {
            InitializeComponent();
            DGUslug.ItemsSource = classes.AppConnect.context.Jobs.ToList();
        }
    }
}
