using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace _119_Novikov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        public PageProduct()
        {
            InitializeComponent();

            GridEnt();
        }

        public void GridEnt()
        {
            grid.ItemsSource = null;
            using (var db = new Entities2())
            {
                var data =
                    from p in db.Product
                    from c in db.Category
                    where c.ID == p.CategoryID
                    select new { p.IDp, p.Name, p.Price, p.Quantity, c.NameC };
                grid.ItemsSource = data.ToList();
            }
        }

        public void AddNum()
        {
            int a = Convert.ToInt32(TextBoxIDp.Text);
            int b = Convert.ToInt32(TextBoxChange.Text);

            var db = new Entities2();

            var product = db.Product
                .Where(c => c.IDp == a)
                .FirstOrDefault();
            product.Quantity += b;
            db.SaveChanges();
        }
        public void SubNum()
        {
            int a = Convert.ToInt32(TextBoxIDp.Text);
            int b = Convert.ToInt32(TextBoxChange.Text);

            var db = new Entities2();

            var product = db.Product
                .Where(c => c.IDp == a)
                .FirstOrDefault();
            product.Quantity -= b;
            db.SaveChanges();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
		{
            AddNum();

            GridEnt();
        }

        private void Button_Sub(object sender, RoutedEventArgs e)
        {
            SubNum();

            GridEnt();
        }

		private void TextBoxIDp_TextChanged(object sender, TextChangedEventArgs e)
		{
            txtHintID.Visibility = Visibility.Visible;
            if (TextBoxIDp.Text.Length > 0)
            {
                txtHintID.Visibility = Visibility.Hidden;
            }
        }

		private void TextBoxChange_TextChanged(object sender, TextChangedEventArgs e)
		{
            txtHintSum.Visibility = Visibility.Visible;
            if (TextBoxChange.Text.Length > 0)
            {
                txtHintSum.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Order(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new PageOrder());
        }
    }
}
