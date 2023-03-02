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
	/// Логика взаимодействия для RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public RegPage()
		{
			InitializeComponent();
		}

		private void TextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{

		}

		private void PasswordBoxCheck_PasswordChanged(object sender, RoutedEventArgs e)
		{

		}

		private void TextBoxFIO_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void OTMClick(object sender, RoutedEventArgs e)
		{
			TextBoxLogin.Text = "";
			PasswordBox.Password = "";
			PasswordBoxCheck.Password = "";
			TextBoxFIO.Text = "";

		}

		private void RegClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(TextBoxFIO.Text) || string.IsNullOrEmpty(PasswordBox.Password) || string.IsNullOrEmpty(PasswordBoxCheck.Password))
			{
				MessageBox.Show("Пустые поля!");
				return;
			}

			//using (var db = new Entities2())
			//{
			//	var user = db.Employee
			//		.AsNoTracking()
			//		.FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == PasswordBox.Password);
			//	if (user == null)
			//	{
			//			FIO = TextBoxFIO.Text,
			//			Login = TextBoxLogin.Text,
			//			Password = PasswordBox.Password,
			//			Role = CmbRole.Text
			//	}
			//	else { MessageBox.Show("Пользователь с такими данными уже есть!"); return; }
			//}
			
			Entities2 db = new Entities2();
			Employee userObject = new Employee
			{
				FIO = TextBoxFIO.Text,
				Login = TextBoxLogin.Text,
				Password = PasswordBox.Password,
				Role = CmbRole.Text
			};

			db.Employee.Add(userObject);
			MessageBox.Show("Пользователь успешно добавлен!");
			NavigationService?.Navigate(new AuthPage());
			db.SaveChanges();
		}
	}
}
