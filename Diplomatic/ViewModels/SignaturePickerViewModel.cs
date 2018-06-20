using System;
using Xamarin.Forms;

namespace Diplomatic.ViewModels
{
    public class SignaturePickerViewModel
    {
        // List of signature items to be displayed.
        public ImageCell[] SignatureItems { get; set; }
        
        public SignaturePickerViewModel()
        {
            
            SignatureItems = new ImageCell[]
            {
                // Creating a few signatures for testing purposes
                new ImageCell()
                {
                    ImageSource = "johnhancock.png",
                    Text = "John Hancock",
                    Detail = ""

                },
                new ImageCell()
                {
                    ImageSource = "kurtvonnegut.png",
                    Text = "Kurt Vonnegut",
                    Detail = "Balling signature holder"
                }
            };
        }
       
    }
}
