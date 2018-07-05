using System;

namespace Diplomatic.ViewModels
{
    public class ResultViewModel
    {
        public Uri ImageUri { get; }
        public string Filename { get; set; } 
        public ResultViewModel(Uri imageuri, string filename)
        {
            ImageUri = imageuri;
            Filename = filename;
        }
    }
}
