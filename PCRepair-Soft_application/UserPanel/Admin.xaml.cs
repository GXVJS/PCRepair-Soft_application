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
using System.Xml.Linq;
using System.Net;
using PCRepair_Soft_application.app;
using System.Runtime.Remoting.Contexts;
using PCRepair_Soft_application.classes;

namespace PCRepair_Soft_application.UserPanel
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public List<Completed_Jobs> TypeList { get; set; }
        private List<Completed_Jobs> sotrudnik = new List<Completed_Jobs>();
        private string _stype;
        private string _findName;
        public Admin()
        {
            InitializeComponent();
            this.DataContext = this;
            
            listProduct.ItemsSource = classes.AppConnect.context.Completed_Jobs.ToList();
            List<Completed_Jobs> types = new List<Completed_Jobs>();
            types.Add(new Completed_Jobs() {name_job = "Все" });
            types.AddRange(AppConnect.context.Completed_Jobs.OrderBy(h => h.id).ToList());
            cmbFiltr.ItemsSource = types;
            Refresh();
            this.sotrudnik = AppConnect.context.Completed_Jobs.ToList();
        }
        private void Refresh()
        {
            listProduct.ItemsSource = classes.AppConnect.context.Completed_Jobs.ToList();
           
        }
        public void RefreshHotels()
        {
            listProduct.ItemsSource = classes.AppConnect.context.Completed_Jobs.OrderBy( h => h.name_job).ToList();
        
        }
        private List<Completed_Jobs> salary = new List<Completed_Jobs>();
        public string[] SortList { get; set; } =
       {
            "Без сортировки",
            "Дата по убыванию",
            "Дата по возрастанию"
        };
        private int SortType = 0;
        private void cmbCena_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            salary = AppConnect.context.Completed_Jobs.ToList();
            SortType = cmbCena.SelectedIndex;
            switch (SortType)
            {
                case 1:
                    salary = salary.OrderByDescending(p => p.completion_date)
                        .ToList(); break;
                case 2:
                    salary = salary.OrderBy(p => p.completion_date)
                        .ToList(); break;
            }
            listProduct.ItemsSource = salary;

        }
        private void cmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sotrudnik = AppConnect.context.Completed_Jobs.ToList();
            Completed_Jobs hCom = cmbFiltr.SelectedItem as Completed_Jobs;
            _stype = hCom.name_job.ToString();
            sotrudnik = (from t in sotrudnik
                         where t.name_job.ToString() == _stype
                         select t).ToList();
            if (_stype == "Все")
                sotrudnik = AppConnect.context.Completed_Jobs.OrderBy(t => t.name_job.ToString()).ToList();
            listProduct.ItemsSource = sotrudnik;

        }

        private void txtPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            _findName = txtPoisk.Text;
            sotrudnik = AppConnect.context.Completed_Jobs.OrderBy(h => h.name_job).ToList();
            if (txtPoisk.Text != "")
            {
                sotrudnik = sotrudnik.OrderBy(tour => tour.name_job).Where(h => h.name_job.ToLower().Contains(_findName)).ToList();
            }
            else
            {
                sotrudnik = AppConnect.context.Completed_Jobs.ToList();
            }
            listProduct.ItemsSource = sotrudnik;
        }

        private void listProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var NewEditWindow = new UserPanel.Edit(listProduct.SelectedItem as Completed_Jobs);
            if ((bool)NewEditWindow.ShowDialog())
            {
                using (var context = new PCRepairEntities5())
                {

                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add(classes.AppConnect.context, this);
            add.ShowDialog();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var NewEdit = new UserPanel.AddUser(new Employees());
            if ((bool)NewEdit.ShowDialog())
            {
                
            }
            //AddUser adduser = new AddUser(classes.AppConnect.context, this);
            //adduser.ShowDialog();
        }
    }
}
