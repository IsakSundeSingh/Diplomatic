using System;
using Android.Content;
using Android.Net;
using Diplomatic.Droid.Classes;
using Diplomatic.Interfaces;
using Java.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Picture_Droid))]

namespace Diplomatic.Droid.Classes
{
    public class Picture_Droid : IPicture
    {
        public void SavePictureToDisk(string filename, byte[] imageArray)
        {
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.Path;

            string FilePath = System.IO.Path.Combine(pictures, filename+".png");
            try
            {
                // Write file to the android disk
                System.IO.File.WriteAllBytes(FilePath, imageArray);
                // Now it needs to be added to image gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new File(FilePath)));
                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
            }
            catch(System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
        }
    }
}
