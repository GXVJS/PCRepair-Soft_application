using Microsoft.Win32;
using PCRepair_Soft_application.app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Data.Entity.Migrations;
using System.Xml.Linq;

namespace PCRepair_Soft_application.UserPanel
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Employees CurrentProduct { get; set; }

        public AddUser(Employees EditEmployes)
        {
            InitializeComponent();
            DataContext = this;
            CurrentProduct = EditEmployes;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PCRepairEntities5())
            {
                try
                {
                    Employees product = null;
                    if (CurrentProduct.id != 0)
                    {
                        product = context.Employees.Find(CurrentProduct.id);

                    }
                    else
                        product = new Employees();
                    if (product != null)
                    {
                        
                        product.patronymic = CurrentProduct.patronymic;
                        product.surname = CurrentProduct.surname;
                        product.name = CurrentProduct.name;
                        product.email = CurrentProduct.email;
                        product.login = CurrentProduct.login;
                        product.password = CurrentProduct.password;

                        product.reward_percentage = CurrentProduct.reward_percentage;

                        product.photo = CurrentProduct.photo;
                        if (product.id == 0)
                        {
                            context.Employees.Add(product);
                        }
                        else
                            context.Employees.AddOrUpdate(product);
                        if (context.SaveChanges() > 0)
                        {
                            DialogResult = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        MessageBox.Show(ex.InnerException.Message);
                    else MessageBox.Show(ex.Message);
                }
            }
        }
        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Файлы изображений: (*.png, *.jpg)|*.png;*.jpg";

            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == true)
            {
                CurrentProduct.photo = dlg.FileName.Substring(Environment.CurrentDirectory.Length + 1);
                Invalidate();
            }
        }
        private void Invalidate(string ComponentName = "ProductList")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(ComponentName));
        }
    }
}
