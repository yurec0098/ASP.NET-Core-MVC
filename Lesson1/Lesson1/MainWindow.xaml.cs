using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Lesson1_1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;

			new Thread(() => RunFibonachi(100, textBox)) { IsBackground = true }.Start();
		}

		private void RunFibonachi(int length, TextBox tb)
		{
			var fibonachiText = string.Empty;
			tb.Dispatcher.Invoke(() => tb.Text = string.Empty);

			for (int i = -100; i < length; i++)
			{
				if (string.IsNullOrEmpty(fibonachiText))
					fibonachiText += FibonacciIteration(i);
				else
					fibonachiText += $", {FibonacciIteration(i)}";

				tb.Dispatcher.Invoke(() => tb.Text = fibonachiText);
				
				Thread.Sleep(500);
			}
		}

		private decimal FibonacciIteration(int n)
		{
			if (n == 0)
				return 0;

			bool isNegative = false;
			if (n < 0)
			{
				n = -n;
				isNegative = true;
			}

			decimal result = 1;
			decimal f0 = 0;
			decimal f1 = 1;
			for (int i = 2; i <= n; i++)
			{
				result = f0 + f1;

				f0 = f1;
				f1 = result;
			}

			if (isNegative)
				return n % 2 == 0 ? -result : result;
			else
				return result;
		}
	}
}
