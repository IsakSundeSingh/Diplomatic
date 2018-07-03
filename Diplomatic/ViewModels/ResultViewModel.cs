using System;
using System.Linq;
using Diplomatic.Utils;


namespace Diplomatic.ViewModels
{
    public class ResultViewModel
    {
        public Uri ImageUri { get; }
        public ResultViewModel(Uri imageuri) => ImageUri = imageuri;
    }
}
