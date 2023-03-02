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
using System.Data.SqlClient;

namespace _119_Novikov.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public PageManager()
        {
            InitializeComponent();

			grid.ItemsSource = null;
			using (var db = new Entities2())
			{
				var data = from d in db.Employee select d;
				grid.ItemsSource = data.ToList();
			}
		}

		private void Button_Worker(object sender, RoutedEventArgs e)
		{
			grid.ItemsSource = null;
			using (var db = new Entities2())
			{
				var data = from d in db.Employee where d.Role == "Рабочий" select new { d.ID, d.FIO };
				grid.ItemsSource = data.ToList();
			}
		}

		private void Button_Buch(object sender, RoutedEventArgs e)
		{
			grid.ItemsSource = null;
			using (var db = new Entities2())
			{
				var data = from d in db.Employee where d.Role == "Бухгалтер" select new { d.ID, d.FIO };
				grid.ItemsSource = data.ToList();
			}
		}

		private void Button_Agent(object sender, RoutedEventArgs e)
		{
			grid.ItemsSource = null;
			using (var db = new Entities2())
			{
				var data = from d in db.Agent select new { d.IDa, d.FIOa, d.CompanyName };
				grid.ItemsSource = data.ToList();
			}
		}

		private void Button_Zakaz(object sender, RoutedEventArgs e)
		{
			NavigationService?.Navigate(new PageWordCreate());
		}

		private void Button_Doc(object sender, RoutedEventArgs e)
		{
			NavigationService?.Navigate(new PageWordExecute());
		}

		private void Button_Order(object sender, RoutedEventArgs e)
		{
			NavigationService?.Navigate(new PageOrder());
		}
	}
}
