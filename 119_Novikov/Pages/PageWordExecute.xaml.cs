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
	/// Логика взаимодействия для PageWordExecute.xaml
	/// </summary>
	public partial class PageWordExecute : Page
	{
		public PageWordExecute()
		{
			InitializeComponent();
		}

		private readonly string File = Directory.GetCurrentDirectory() + @"\Vydacha.docx";

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var org = TextBoxOrgName.Text;
			var manager = TextBoxManager.Text;
			var number = TextBoxNumber.Text;
			var receiver = TextBoxReceiver.Text;
			var date = DateTime.Now.ToString("dd.MM.yy HH:mm");
			var agent = TextBoxAgent.Text;

			var wordApp = new Word.Application();
			wordApp.Visible = false;

			var wordDocument = wordApp.Documents.Open(File); 
			ReplaceWord("{OrgName}", org, wordDocument);
			ReplaceWord("{Manager}", manager, wordDocument);
			ReplaceWord("{Number}", number, wordDocument);
			ReplaceWord("{Receiver}", receiver, wordDocument);
			ReplaceWord("{Date}", date, wordDocument);
			ReplaceWord("{Agent}", agent, wordDocument);

			wordDocument.SaveAs(Directory.GetCurrentDirectory() + @"\Vydacha1.docx");
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
