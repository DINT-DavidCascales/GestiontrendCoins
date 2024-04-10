using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Controls;

namespace GestiontrendCoins
{
    internal class ConversorImagen
    {
        public static byte[] CompressImage(BitmapImage image)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.QualityLevel = 50; // Ajusta este valor para cambiar el nivel de compresión
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                return ms.ToArray();
            }
        }
        public static BitmapImage DecompressImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }


        // Este metodo hace lo mismo que el anterior pero ademas antes de descomprimirla pasa de base64 a byte[]
        public static BitmapImage Base64ToImage(string base64String)
        {
            byte[] byteBuffer = Convert.FromBase64String(base64String);

            using (MemoryStream memoryStream = new MemoryStream(byteBuffer))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
        public static string BytesToBase64(byte[] imageBytes)
        {
            return Convert.ToBase64String(imageBytes);
        }
        public BitmapImage ByteToBitmapImage(byte[] img)
        {
            using (MemoryStream memoryStream = new MemoryStream(img))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Esto carga la imagendb inmediatamente
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
                // Ahora 'bitmapImage' contiene la imagendb desde el arreglo de bytes
                return bitmapImage;
            }
        }

    }
}
