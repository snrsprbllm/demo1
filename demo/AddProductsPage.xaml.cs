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
    /// Логика взаимодействия для AddProductsPage.xaml
    /// </summary>
    public partial class AddProductsPage : UserControl
    {
        private demo1entites _context = new demo1entites();
        public AddProductsPage()
        {
            InitializeComponent();
            LoadProductsTypes();
            LoadMaterialsTypes();
        }

        private void LoadMaterialsTypes()
        {
            var MaterialsTypes = _context.MaterialTypes.ToList();
            MaterialComboBox.ItemsSource = MaterialsTypes;
            MaterialComboBox.DisplayMemberPath = "MaterialType";
            MaterialComboBox.SelectedValuePath = "MaterialTypeId";
            MaterialComboBox.SelectedIndex = 0;
        }

        private void LoadProductsTypes()
        {
            var ProductsTypes = _context.ProductTypes.ToList();
            TypeComboBox.ItemsSource = ProductsTypes;
            TypeComboBox.DisplayMemberPath = "ProductType";
            TypeComboBox.SelectedValuePath = "ProductTypeId";
            TypeComboBox.SelectedIndex = 0;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var maxId = _context.Products.Max(p => p.ProductId)+1;
            var newProduct = new Products
            {
                ProductId = maxId,
                ProductTypeId = (int)TypeComboBox.SelectedValue,
                ProductName = ProductNameTextBox.Text,
                ArticleNumber = ArticleTextBox.Text,
                MinCostForPartner = decimal.Parse(MinCostTextBox.Text),
                RollWidth = decimal.Parse(RollWidthTextBox.Text),
                CalculatedCost = 0
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            MessageBox.Show("Партнер успешно добавлен!");
            
        }
    }
}
