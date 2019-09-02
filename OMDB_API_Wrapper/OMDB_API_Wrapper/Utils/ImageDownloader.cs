using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OMDB_API_Wrapper.Utils
{
    public static class ImageDownloader
    {
        public static async Task<ImageDownload> DownloadImage(HttpClient client, string imageUri)
        {
            try
            {
                Uri uri;

                if (Uri.TryCreate(imageUri, UriKind.Absolute, out uri) == false)
                {
                    return new ImageDownload(false, null, null);
                }

                string uriPath = uri.LocalPath;

                if (string.IsNullOrWhiteSpace(Path.GetExtension(uriPath)))
                {
                    return new ImageDownload(false, null, null);
                }

                var httpResponse = await client.GetAsync(uri);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string fileName = Path.GetFileName(uriPath);
                    byte[] data = await httpResponse.Content.ReadAsByteArrayAsync();

                    return new ImageDownload(true, data, fileName);
                }
            }
            catch
            {
                return new ImageDownload(false, null, null);
            }

            return new ImageDownload(false, null, null);
        }
    }
}
