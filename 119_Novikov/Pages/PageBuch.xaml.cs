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

namespace _119_Novikov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBuch.xaml
    /// </summary>
    public partial class PageBuch : Page
    {
        public PageBuch()
        {
            InitializeComponent();

            grid.ItemsSource = null;
            using (var db = new Entities2())
            {
                var data =
                    from e in db.Employee
                    from o in db.Order
                    from p in db.Product
                    where e.ID == o.EmployeeID
                    where o.ProductID == p.IDp
                    select new { e.FIO, e.Role, o.ID, o.AgentID, o.Quantity, p.Name, o.Date};
                grid.ItemsSource = data.ToList();
            }
        }

        private void TextBoxBuch_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHintBuch.Visibility = Visibility.Visible;
            if (TextBoxBuch.Text.Length > 0)
            {
                txtHintBuch.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Calc(object sender, RoutedEventArgs e)
		{
            int abc = Convert.ToInt32(TextBoxBuch.Text) * 2200;
            TextBoxFin.Text = Convert.ToString(abc) + "₽";
                
		}

        private void Button_Emp(object sender, RoutedEventArgs e)
        {
            TextBoxBuch.Text = "";
            TextBoxFin.Text = "";

            grid.ItemsSource = null;
            using (var db = new Entities2())
            {
                var data =
                    from n in db.Employee
                    from o in db.Order
                    from p in db.Product
                    where n.ID == o.EmployeeID
                    where n.FIO == CmbFIO.Text
                    where o.ProductID == p.IDp
                    select new { n.FIO, n.Role, o.ID, o.AgentID, o.Quantity, p.Name, o.Date};
                grid.ItemsSource = data.ToList();
            }
        }
    }
}
