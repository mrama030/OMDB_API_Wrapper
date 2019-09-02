namespace OMDB_API_Wrapper.Utils
{
    public class ImageDownload
    {
        public bool DownloadSuccessful { get; private set; }
        public byte[] Data { get; private set; }
        public string FileName { get; private set; }

        public ImageDownload(bool success, byte[] data, string fileName)
        {
            DownloadSuccessful = success;

            if (success)
            {
                Data = data;
                FileName = fileName;
            }
        }
    }
}
