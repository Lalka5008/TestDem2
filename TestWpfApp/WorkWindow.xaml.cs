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
        public WorkWindow(string Role = "", string Fullname = "", string Secondname = "", string Lastname = "")
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            DataContext = this;
            NameBox.Text = $"{Role}, {Fullname} {Secondname} {Lastname}";
            RefreshProduct();
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
                foreach (var p in product)
                {
                    Products.Add(p);

                }
            }
        }
    }
}
