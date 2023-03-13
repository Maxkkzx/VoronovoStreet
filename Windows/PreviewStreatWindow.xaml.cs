using Microsoft.Maps.MapControl.WPF;
using VoronovoStreet.StreetModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VoronovoStreet.Windows
{
    /// <summary>
    /// Логика взаимодействия для PreviewStreatWindow.xaml
    /// </summary>
    public partial class PreviewStreatWindow : Window
    {
        public ObservableCollection<StreetModel> StreetsList { get; set; } = new ObservableCollection<StreetModel>();
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        private StreetModel _selectedStreet;
        public StreetModel SelectedStreet
        { 
            get { return _selectedStreet; }
            set 
            { 
                _selectedStreet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStreet)));
            }
        }

        public PreviewStreatWindow()
        {
            InitializeComponent();
            DataContext = this;
            FillStreatList();
            ICollectionView view = CollectionViewSource.GetDefaultView(StreetsList);
            view.Filter = (item) => (item as StreetModel).Name.ToLower().StartsWith(textBoxFilter.Text.ToLower());
        }

        private void FillStreatList() 
        {
            StreetsList.Add(new StreetModel { Name = "агр. Бенякони", Coordinates = new Location(54.250420, 25.356511), Images = GetImageItemsByName("Fedotovo"), Information = GetPathToInfoByName("fedotovo"), SoundInfo = GetPathToSoundInfoByName("benya") });
            StreetsList.Add(new StreetModel { Name = "д. Гайтюнишки", Coordinates = new Location(54.263883, 25.454886), Images = GetImageItemsByName("Savica"), Information = GetPathToInfoByName("Savica"), SoundInfo = GetPathToSoundInfoByName("gaitun") });
            StreetsList.Add(new StreetModel { Name = "агр. Больтеники", Coordinates = new Location(54.239912, 25.302188), Images = GetImageItemsByName("Shaposh"), Information = GetPathToInfoByName("Shaposh"), SoundInfo = GetPathToSoundInfoByName("bolt") });
            StreetsList.Add(new StreetModel { Name = "д. Трокели", Coordinates = new Location(54.038253, 25.410358), Images = GetImageItemsByName("Karaseva"), Information = GetPathToInfoByName("Karaseva"), SoundInfo = GetPathToSoundInfoByName("troc") });
            StreetsList.Add(new StreetModel { Name = "д. Нача", Coordinates = new Location(54.072042, 24.839191), Images = GetImageItemsByName("Rakas"), Information = GetPathToInfoByName("Rakas"), SoundInfo = GetPathToSoundInfoByName("nacca") });
            StreetsList.Add(new StreetModel { Name = "г.п. Радунь", Coordinates = new Location(54.052911, 24.997634), Images = GetImageItemsByName("Ilyena"), Information = GetPathToInfoByName("Ilyena"), SoundInfo = GetPathToInfoByName("radun")});
            StreetsList.Add(new StreetModel { Name = "д. Пелеса", Coordinates = new Location(53.950800, 24.980507), Images = GetImageItemsByName("Kirov"), Information = GetPathToInfoByName("Kirov"), SoundInfo = GetPathToSoundInfoByName("pely") });
            StreetsList.Add(new StreetModel { Name = "г.п. Вороново", Coordinates = new Location(54.149923, 25.316446), Images = GetImageItemsByName("Gorkogo"), Information = GetPathToInfoByName("Gorkogo"), SoundInfo = GetPathToSoundInfoByName("voronovo") });
            StreetsList.Add(new StreetModel { Name = "д. Оссова", Coordinates = new Location(54.078722, 25.216448), Images = GetImageItemsByName("Yanis"), Information = GetPathToInfoByName("Yanis"), SoundInfo = GetPathToSoundInfoByName("ossova") });
            StreetsList.Add(new StreetModel { Name = "ул. Советская", Coordinates = new Location(54.150982, 25.318160), Images = GetImageItemsByName("Korza"), Information = GetPathToInfoByName("Korza"), SoundInfo = GetPathToSoundInfoByName("sovet") });
            StreetsList.Add(new StreetModel { Name = "ул. Октябрьская", Coordinates = new Location(54.152782, 25.318570), Images = GetImageItemsByName("Kulik"), Information = GetPathToInfoByName("Kulik"), SoundInfo = GetPathToSoundInfoByName("oktab") });
            StreetsList.Add(new StreetModel { Name = "ул. Семашко", Coordinates = new Location(54.153343, 25.318876), Images = GetImageItemsByName("ZoiKos"), Information = GetPathToInfoByName("ZoiKos"), SoundInfo = GetPathToSoundInfoByName("oktab") });
            StreetsList.Add(new StreetModel { Name = "ул. Литовчика", Coordinates = new Location(54.151214, 25.314159), Images = GetImageItemsByName("Mick"), Information = GetPathToInfoByName("Mick"), SoundInfo = GetPathToSoundInfoByName("oktab") });
        }

        private string GetPathToInfoByName(string fileName) 
        {
            return @"InfoAbautStreats/TextInfo/" + fileName + ".rtf";
        }

        private string GetPathToSoundInfoByName(string fileName)
        {
            return @"InfoAbautStreats/SoundInfo/" + fileName + ".wav";
        }

        private ObservableCollection<string> GetImageItemsByName(string name) 
        {
            ObservableCollection<string> images = new ObservableCollection<string>();
            string folder = @"InfoAbautStreats/Images/" + name;
            foreach (var pathToPhoto in Directory.GetFiles(folder))
            {
                images.Add(@"/bin/Debug/net6.0-windows/" + pathToPhoto);
            }

            return images;
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SendStretToPreviewByName(SelectedStreet.Name);
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(StreetsList).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendStretToPreviewByName((sender as Button).Tag.ToString());
        }

        private void SendStretToPreviewByName(string name) 
        {
            StreetModel foundByName = StreetsList.First(item => item.Name == name);
            new PreviewStreatInformationWindow(foundByName).ShowDialog();
        }
    }
}
