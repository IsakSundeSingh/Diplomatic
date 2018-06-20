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
                    ImageSource = "donaldtrump.png",
                    Text = "Donald Trump",
                    Detail = "President"

                },
                new ImageCell()
                {
                    ImageSource = "gavinbelson.png",
                    Text = "Gavin Belson",
                    Detail = "Visionary behind 'The box 3'"
                },
                new ImageCell()
                {
                    ImageSource = "waltdisney.png",
                    Text = "Walt Disney",
                    Detail = "Interesting"
                }
            };
        }
       
    }
}
