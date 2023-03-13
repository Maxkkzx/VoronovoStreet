namespace VoronovoStreet.StreetModels
{
    public class ImageItem
    {
        public string PathToImage { get; set; }

        public ImageItem(string path)
        {
            PathToImage = path;
        }
    }
}
