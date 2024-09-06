using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;

namespace OlegShilo.MoveTypeToFile
{
	// Token: 0x02000007 RID: 7
	public partial class ProgressDialog : Window
	{
		// Token: 0x0600001C RID: 28 RVA: 0x000026EF File Offset: 0x000008EF
		public ProgressDialog()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000026FD File Offset: 0x000008FD
		public static void DoEvents()
		{
			Application.Current.Dispatcher.Invoke(DispatcherPriority.Render, new Action(delegate
			{
			}));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002730 File Offset: 0x00000930
		public void OnProgress(int currentStep, int totalSteps, string stepDescription)
		{
			try
			{
				base.Dispatcher.Invoke(delegate
				{
					this.progress.Minimum = 0.0;
					this.progress.Maximum = (double)totalSteps;
					this.progress.Value = (double)currentStep;
					this.currentFile.Text = stepDescription;
				});
			}
			catch
			{
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000278C File Offset: 0x0000098C
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			this.progress.Minimum = 0.0;
			this.progress.Maximum = 10.0;
			this.progress.Value = 5.0;
			base.Height = 80.0;
			this.currentFile.Text = "Preparing...";
			Task.Run(delegate
			{
				Action run = this.Run;
				if (run == null)
				{
					return;
				}
				run();
			});
		}

		// Token: 0x0400000C RID: 12
		public Action Run;
	}
}
