using MaterialDesignThemes.Wpf;
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

namespace PCRepair_Soft_application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = classes.AppConnect.context.Employees.FirstOrDefault(
                    x => x.login == TextBoxLogin.Text
                    && x.password == TextBoxPass.Password);

                if (userObj == null)
                {   
                   
                    
                    TextBoxLogin.Foreground = Brushes.Red;
                    TextBoxLogin.Text = string.Empty; // Очистим содержимое текстового поля
                    HintAssist.SetHint(TextBoxLogin, "Неверный логин");
                    
               
                    TextBoxPass.Foreground = Brushes.Red;
                    TextBoxPass.Password = string.Empty; // Очистим содержимое текстового поля
                    HintAssist.SetHint(TextBoxPass, "Неверный пароль");
                   
                    MessageBox.Show("Введите корректные данные", "Ошибка авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {                  
                    Window1 window1 = new Window1();
                    window1.Show();
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "\nКритическая ошибка" + "приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
