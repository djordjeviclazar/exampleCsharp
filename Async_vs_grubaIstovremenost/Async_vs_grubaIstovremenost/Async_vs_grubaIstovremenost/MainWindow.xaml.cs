using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
using System.Windows.Threading;

namespace Async_vs_grubaIstovremenost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Control c;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();

            c = new Button() { Height = 30, Width = 20, Name = "MainThread", Background = Brushes.Green};
            Grid.SetColumn(c, 0);
            Grid.SetRow(c, 0);
            Grid.SetColumnSpan(c, 2);
            grid.Children.Add(c);

            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Width - c.Width > c.Margin.Left) // ovo je bolje da element bude na Canvas; Canvas.GetLeft(c)...
            {
                Thickness t = c.Margin;
                t.Left += 30;
                c.Margin = t;
            }
            else
            {
                Thickness t = c.Margin;
                t.Left = 0;
                c.Margin = t;
            }
        }

        private void Async_Click(object sender, RoutedEventArgs e)
        {
            GoAsync();
        }

        private void Brutal_Click(object sender, RoutedEventArgs e)
        {
            Brutal.IsEnabled = false;
            Task.Run(() => Go());
        }
        private async void GoAsync()
        {
            Async.IsEnabled = false;

            for (int i = 0; i < 5; i++)
            {
                   TextResult.Text += await GetPrimesCountAsync(i * 1_000_000 + 2, 1_000_000) + "primes between" + 
                   (i * 1_000_000) + "and" + (1_000_000 * (i + 1) - 1) + Environment.NewLine;
            }

            Async.IsEnabled = true;
        }

        private void Go()
        {
            for (int i = 0; i < 5; i++)
            {
                int result = GetPrimesCount(i * 1_000_000 + 2, 1_000_000);
                Dispatcher.BeginInvoke(new Action(() =>
                        TextResult.Text += result + "primes between" + (i * 1_000_000) + "and" + (1_000_000 * (i + 1) - 1) +
                        Environment.NewLine));
            }
            Dispatcher.BeginInvoke(new Action(() => { Brutal.IsEnabled = false; }));
        }

        private int GetPrimesCount(int start, int count)
        {
            return ParallelEnumerable.Range(start, count).Count(n =>
                                                          Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        }

        private Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count).Count(n =>
                                                          Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                                                          .All(i => n % i > 0)));
        }


    }
}
