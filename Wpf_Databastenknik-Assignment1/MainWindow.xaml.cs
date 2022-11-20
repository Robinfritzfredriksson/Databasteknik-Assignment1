using Microsoft.EntityFrameworkCore;
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
using Wpf_Databastenknik_Assignment1.Models;
using Wpf_Databastenknik_Assignment1.Models.Entities;
using Wpf_Databastenknik_Assignment1.Services;

namespace Wpf_Databastenknik_Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summar
    public partial class MainWindow : Window
    {
        private OrderModel orderModel = new OrderModel();
        private readonly CustomerService _customerService;
        private readonly CustomerModel _customerModel;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;

        public MainWindow(CustomerService customerService, ProductService productService, OrderService orderService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            PopulateCustomers().ConfigureAwait(false);
            PopulateProducts().ConfigureAwait(false);
            _orderService = orderService;
        }


        public async Task PopulateCustomers()
        {
            var Collection = new ObservableCollection<KeyValuePair<string, int>>();
            foreach (var customer in await _customerService.GetAll())
                Collection.Add(new KeyValuePair<string, int>(customer.Name, customer.Id));

            foreach (var c in Collection)
            {
                cb_Customers.Items.Add(c);
            }

            var p_Collection = new ObservableCollection<KeyValuePair<string, Guid>>(); //HÄR ÄR DET FEL, MEN VAD?
            foreach (var product in await _productService.GetAll())
                p_Collection.Add(new KeyValuePair<string, Guid>(product.Name, product.Id));

            foreach(var p in p_Collection)
            {
                cb_Products.Items.Add(p);
            }
        }

        public async Task PopulateProducts()
        {
 
        }


        private async void btn_Add_ProductToList_Click(object sender, RoutedEventArgs e)
        {
            var selected_product = (KeyValuePair<string, Guid>)cb_Products.SelectedItem;
            var product = await _productService.Get(selected_product.Value);
            orderModel.Products.Add(product);
        }

        private async void btn_Save_Order_Click(object sender, RoutedEventArgs e)
        {
            await _orderService.Create(orderModel);
        }
    }
}
