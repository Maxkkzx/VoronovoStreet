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
using System.Windows.Shapes;
using VoronovoStreet;

namespace Voronovo
{
    /// <summary>
    /// Логика взаимодействия для Privv.xaml
    /// </summary>
    public partial class Privv : Window
    {
        public Privv()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
            new MainWindow().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mediaElement1.Play();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
        }

        private void mediaElement1_MediaEnded(object sender, RoutedEventArgs e)
        {
            new MainWindow().ShowDialog();
        }
    }
}
