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
    /// Логика взаимодействия для PageOrder.xaml
    /// </summary>
    public partial class PageOrder : Page
    {
        public PageOrder()
        {
            InitializeComponent();

            grid.ItemsSource = null;
            using (var db = new Entities2())
            {
                var data = 
                    from o in db.Order 
                    from p in db.Product
                    where p.IDp == o.ProductID
                    select new {o.ID, o.EmployeeID, o.AgentID, p.IDp, p.Name, o.Quantity, o.Date};
                grid.ItemsSource = data.ToList();
            }
        }
    }
}
