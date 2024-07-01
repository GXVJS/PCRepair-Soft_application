using PCRepair_Soft_application.app;
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
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;

namespace PCRepair_Soft_application.UserPanel
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private PCRepairEntities5 _context;
        private Admin _window;
        public Completed_Jobs CurrentProduct1 { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Add(PCRepairEntities5 context, Admin admin)
        {
            InitializeComponent();
            this._context = context;
            this._window = admin;
            JobsName.ItemsSource = _context.Jobs.ToList();
            FIO.ItemsSource = _context.Employees.ToList();
            
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            _context.Completed_Jobs.Add(new Completed_Jobs()
            {
                name_job = TxtName.Text,
                completion_date = Convert.ToDateTime(TxtStar.Text),
                Jobs = JobsName.SelectedItem as Jobs,
                Employees = FIO.SelectedItem as Employees,
                
            });

            _context.SaveChanges();
            _window.RefreshHotels();
            this.Close();
        }

        //private void ChangeName_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog dlg1 = new OpenFileDialog();
        //    dlg1.Filter = "Файлы изображений: (*.png, *.jpg)| *.png;*.jpg";
        //    dlg1.InitialDirectory = Environment.CurrentDirectory;

        //    if (dlg1.ShowDialog() == true)
        //    {
        //        if (CurrentProduct1 != null)
        //        {
        //            CurrentProduct1.Employees.photo = dlg1.FileName.Substring(Environment.CurrentDirectory.Length + 1);
        //            Invalidate();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Пользователь не выбрал файл.");
        //        }
        //    }
        
        //}
        //private void Invalidate(string ComponentName = "ProductList")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(ComponentName));
        //}
    }
}
