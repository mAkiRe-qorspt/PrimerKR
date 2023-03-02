using System;
using System.Collections.Generic;
using System.IO;
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
using Word = Microsoft.Office.Interop.Word;

namespace _119_Novikov.Pages
{
	/// <summary>
	/// Логика взаимодействия для PageWordCreate.xaml
	/// </summary>
	public partial class PageWordCreate : Page
	{
		public PageWordCreate()
		{
			InitializeComponent();
		}

		private readonly string File = Directory.GetCurrentDirectory() + @"\zakaz.docx";

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var manager = TextBoxManager.Text;
			var number = TextBoxNumber.Text;
			var receiver = TextBoxReceiver.Text;
			var date = DateTime.Now.ToString("dd.MM.yy HH:mm");

			var wordApp = new Word.Application();
			wordApp.Visible = false;

			var wordDocument = wordApp.Documents.Open(File);
			ReplaceWord("{Manager}", manager, wordDocument);
			ReplaceWord("{Number}", number, wordDocument);
			ReplaceWord("{Receiver}", receiver, wordDocument);
			ReplaceWord("{Date}", date, wordDocument);

			wordDocument.SaveAs(Directory.GetCurrentDirectory() + @"\zakaz1.docx");
			wordApp.Visible = true;
		}

		private void ReplaceWord(string toReplace, string text, Word.Document wordDocument)
		{
			var range = wordDocument.Content;
			range.Find.ClearFormatting();
			range.Find.Execute(FindText: toReplace, ReplaceWith: text);
		}
	}
}
