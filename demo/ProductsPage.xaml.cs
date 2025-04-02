using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : UserControl
    {
        private demo1entites _context = new demo1entites();
        public ObservableCollection<Products> products {  get; set; }
        public ProductsPage()
        {
            InitializeComponent();
            products = new ObservableCollection<Products>();
            this.DataContext = this;
            LoadProducts();
           
        }

        private void LoadProducts()
        {
            
            try
            {
               
                products.Clear();
                foreach (var item in _context.Products.ToList())
                {
                    item.CalculatedCost = Calc(item.ProductId);
                    
                    products.Add(item);
                    
                }
                ProductsItemsControl.ItemsSource = products;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выводе данных:, {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private int Calc(int id)
        {
            decimal count = 0;
            foreach (var item in _context.ProductMaterials)
            {
                if (id == item.ProductId)
                    count = count + Convert.ToDecimal(item.RequiredQuantity) * Convert.ToDecimal(item.Materials.PricePerUnit);
            }
            return(int) count;
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var products = button.DataContext as Products;
                if (products != null)
                {
                    var mainwindow = Application.Current.MainWindow as MainWindow;
                    if (mainwindow != null)
                    {
                        mainwindow.MainFrame.Navigate(new EditProductPage(products));
                    }
                }
            }
        }
    }
}
