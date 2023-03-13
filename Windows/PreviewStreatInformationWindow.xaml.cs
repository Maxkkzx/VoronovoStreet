using VoronovoStreet.StreetModels;
using System.Collections.ObjectModel;
using System.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace VoronovoStreet.Windows
{
    /// <summary>
    /// Логика взаимодействия для PreviewStreatInformationWindow.xaml
    /// </summary>
    public partial class PreviewStreatInformationWindow : Window
    {
        public ObservableCollection<string> ImagePaths { get; set; } = new ObservableCollection<string>();
        public string SoundInfoToPlay { get; set; }
        
        public PreviewStreatInformationWindow(StreetModel street)
        {
            InitializeComponent();
            StreatNameHed.Text = street.Name;
            DataContext = this;
            Title = street.Name;
            ImagePaths = street.Images;
            LoadDocx(street.Information);
            SoundInfoToPlay = street.SoundInfo;
        }

        private void LoadDocx(string path)
        {
            if (System.IO.File.Exists(path))
            {
                TextRange range;
                System.IO.FileStream fStream;
                range = new TextRange(RichTextBoxForInfo.Document.ContentStart, RichTextBoxForInfo.Document.ContentEnd);
                fStream = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Rtf);
                fStream.Close();
            }
        }

        SoundPlayer player = new SoundPlayer();
        private void gayt_Click_1(object sender, RoutedEventArgs e)
        {
            player.SoundLocation = SoundInfoToPlay;
            player.Load();
            player.PlayLooping();
        }

        private void gayst_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            player.Stop();
        }
    }
}
