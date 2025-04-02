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

namespace demo
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

        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainTitle.Text = "Наш декор";
            MainFrame.Content = null;
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void GoToProducts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
            MainTitle.Text = "Список продуктов";
        }

        private void AddProducts_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddProductsPage());
            MainTitle.Text = "Добавление продуктов";
        }

        private void GoToMaterials_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MaterialsPage());
            MainTitle.Text = "Список материалов";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
