using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TestWpfApp.Data;
using TestWpfApp.Model;

namespace TestWpfApp
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        private List<Product> allProducts; 
        public WorkWindow(string Role = "", string Fullname = "", string Secondname = "", string Lastname = "")
        {
            Products = new ObservableCollection<Product>();
            InitializeComponent();
            DataContext = this;
            RefreshProduct();
            NameBox.Text = $"{Role}, {Fullname} {Secondname} {Lastname}";
        }
        public void RefreshProduct()
        {
            Products.Clear();
            using (var context = new LeonDataBaseContext())
            {
                var product = context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Importer)
                    .Include(p => p.Name)
                    .Include(p => p.OrderInfos)
                    .Include(p => p.Producer)
                    .Include(p => p.Unit)
                    .ToList();
                allProducts = product.ToList();
                foreach (var p in product)
                {
                    Products.Add(p);

                }
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                string search = SearchBox.Text.Trim();
                Products.Clear();

                var filtered = search == "" ? allProducts : allProducts.Where(p => p.Name.Title.Contains(search));
                foreach (var p in filtered)
                {
                    Products.Add(p);
                }
            }
            catch 
            {
            }

        }
    }
}
