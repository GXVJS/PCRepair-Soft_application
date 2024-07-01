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
using Microsoft.Win32;
using System.Data.Entity.Migrations;

namespace PCRepair_Soft_application.UserPanel
{


    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Completed_Jobs CurrentProduct { get; set; }
        public IEnumerable<Completed_Jobs> ProductTypeList { get; set; }
        public Edit(Completed_Jobs EditProduct)
        {
            
            InitializeComponent();
            DataContext = this;
            CurrentProduct = EditProduct;

            using (var context = new PCRepairEntities5())
            {
                ProductTypeList = context.Completed_Jobs.ToList();
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PCRepairEntities5())
            {
                try
                {
                    Completed_Jobs product = null;
                    if (CurrentProduct.id != 0)
                    {
                        product= context.Completed_Jobs.Find(CurrentProduct.id);
                        
                    }
                    else
                        product = new Completed_Jobs();
                    if (product != null)
                    {
                        product.name_job = CurrentProduct.name_job;
                        product.completion_date = CurrentProduct.completion_date;
                        product.Employees.patronymic = CurrentProduct.Employees.patronymic;
                        product.Employees.surname = CurrentProduct.Employees.surname;
                        product.Employees.name = CurrentProduct.Employees.name;
                        product.Jobs.salary= CurrentProduct.Jobs.salary;
                        product.Employees.reward_percentage = CurrentProduct.Employees.reward_percentage;

                        product.Employees.photo = CurrentProduct.Employees.photo;
                        if (product.id == 0)
                        {
                            context.Completed_Jobs.Add(product);
                        }
                        else
                            context.Completed_Jobs.AddOrUpdate(product);
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

        private void del_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new PCRepairEntities5())
            {
                try
                {
                    var saleCount = context.Completed_Jobs.Where(ps => ps.id == CurrentProduct.id).Count();
                    var product = context.Completed_Jobs.Find(CurrentProduct.id);
                    context.Completed_Jobs.Remove(product);
                    if (context.SaveChanges() > 0)
                        DialogResult = true;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        MessageBox.Show(ex.InnerException.Message);
                    else
                        MessageBox.Show(ex.Message);
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
                CurrentProduct.Employees.photo = dlg.FileName.Substring(Environment.CurrentDirectory.Length + 1);
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
