using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using RandomNum.Class;

namespace RandomNum
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        public string[] date;
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            date = Decryption.Dec();
            if (date.Length == 1)
            {
                MessageBox.Show("Ошибка");
                Application.Current.Shutdown();
            }
        }

        private void BGeneration_Click(object sender, RoutedEventArgs e)
        {
            if (i == 9)
            {
                MessageBox.Show("Уже было выведено 10 знач");
                textGen.Text = "";
                return;
            }
            anim();
            i++;

        }

        async void anim()
        {
            BGeneration.IsEnabled = false;
            int[] value = new int[10];
            for (int i = 0; i < 10; i++)
            {
                value[i] = rnd.Next(1,11);
            }
            for (int i = 0; i < 10; i++)
            {
                textGen.Text = value[i].ToString();
                await Task.Delay(125);
            }
            textGen.Text = date[i];
            BGeneration.IsEnabled = true;

        }

    }
}
