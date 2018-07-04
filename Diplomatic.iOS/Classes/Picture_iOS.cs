using System;
using Diplomatic.Interfaces;
using Diplomatic.iOS.Classes;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Picture_iOS))]
namespace Diplomatic.iOS.Classes
{
    public class Picture_iOS : IPicture
    {
        public void SavePictureToDisk(string filename, byte[] imageArray)
        {
            var Img = new UIImage(NSData.FromArray(imageArray));
            Img.SaveToPhotosAlbum((image, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine(error);
                }
            });
        }
    }
}
