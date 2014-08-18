using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Controls
{
    class ImageConversion
    {
        // bitmapImage is the Image (The photo which you need to convert)

        // Code to convert Image to Byte
        // Assign Image to Bitmap and pass through the function
        string str = BitmapToByte(bitmapImage); //Store Bytes in string str

        // Code to convert Image to Stream
        // Assign Image to Bitmap and pass through the function
        Stream str = ImageToStream(bitmapImage); // Store Image Stream in Stream "str"

        private string BitmapToByte(Image bitmapImage)
        {
            Stream photoStream = ImageToStream(bitmapImage);
            BitmapImage bimg = new BitmapImage();
            bimg.SetSource(photoStream);

            byte[] byteArray = null;
            using (MemoryStream ms = new MemoryStream())
            {
                WriteableBitmap wbitmp = new WriteableBitmap(bimg);
                wbitmp.SaveJpeg(ms, wbitmp.PixelWidth, wbitmp.PixelHeight, 0, 100);
                byteArray = ms.ToArray(); // Get the byte array if you want your result to be in bytes
            }
            string str = Convert.ToBase64String(byteArray);
            return str;
        }

        private Stream ImageToStream(Image bitmapImage)
        {
            WriteableBitmap wb = new WriteableBitmap(400, 400);
            wb.Render(bitmapImage, new TranslateTransform { X = 400, Y = 400 });
            wb.Invalidate();
            Stream myStream = new MemoryStream();
            wb.SaveJpeg(myStream, 400, 400, 0, 70);
            return myStream;
        }
    }
}
