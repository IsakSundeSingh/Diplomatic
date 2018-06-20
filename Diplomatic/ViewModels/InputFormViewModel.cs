using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Diplomatic
{
    public class InputFormViewModel
    {
        // Form entries are placed within these attributes
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime MaxDate { get; set; } = DateTime.UtcNow;

        // To be gotten from field name
        public string NameLabel { get; set; } = "Name";

        //List of signature items to be displayed.
        public ImageCell[] SignatureItems { get; set; }

        public InputFormViewModel()
        {
            SignatureItems = new ImageCell[]
            {
                //Creating a few signatures for testing purposes
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

    public class ListItem
    {
        public string Imgsrc { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        

    }
}
