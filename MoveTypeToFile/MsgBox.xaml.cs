using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using OlegShilo.VSX;

namespace OlegShilo.MoveTypeToFile
{
	// Token: 0x02000006 RID: 6
	public partial class MsgBox : Window
	{
		// Token: 0x06000016 RID: 22 RVA: 0x000025C1 File Offset: 0x000007C1
		public MsgBox()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000025CF File Offset: 0x000007CF
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000025D7 File Offset: 0x000007D7
		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				base.Close();
				return;
			}
			if (e.Key == Key.Return)
			{
				base.Close();
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000025FC File Offset: 0x000007FC
		private void Window_Closing(object sender, CancelEventArgs e)
		{
			if (this.doNotShowNextTime.IsChecked.GetValueOrDefault())
			{
				Config config = Config.Load();
				config.ShowFormattingWarning = false;
				config.Save();
			}
		}
	}
}
