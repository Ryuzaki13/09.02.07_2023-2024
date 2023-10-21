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

namespace WpfApp1
{
    public class Product
    {
        public Product(string name) {
            Name = name;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return Name + " " + Price + "р.";
        }
    }
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            lbProduct.Items.Add(new Product("Яблоко"));
            lbProduct.Items.Add(new Product("Дыня"));
            lbProduct.Items.Add(new Product("Груша"));
            lbProduct.Items.Add(new Product("Мандарин"));
        }

       

        private void onChangeProduct(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null)
            {
                bRemove.IsEnabled = false;
                return;
            }

            var selectedProduct = listBox.SelectedItem as Product;
            if (selectedProduct == null)
            {
                bRemove.IsEnabled = false;
                return;
            }

            bRemove.IsEnabled = true;
        }

        private void onCreateProduct(object sender, RoutedEventArgs e)
        {
            string productName = tbProductName.Text.Trim();
            if (productName.Length == 0)
            {
                MessageBox.Show("Введите название продукта");
                return;
            }

            tbProductName.Clear();
            lbProduct.Items.Add(new Product(productName));
        }

        private void onRemoveProduct(object sender, RoutedEventArgs e)
        {
            if (lbProduct.SelectedItem == null)
            {
                MessageBox.Show("Для удаления продукта необходимо его выбрать");
                return;
            }

            lbProduct.Items.Remove(lbProduct.SelectedItem);
        }

        private void onInputProductName(object sender, TextChangedEventArgs e)
        {
            bCreate.IsEnabled = tbProductName.Text.Trim().Length > 0;
        }
    }
}
