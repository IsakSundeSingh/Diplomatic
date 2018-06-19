using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Diplomatic
{
    public class InputFormViewModel
    {
        public string Label { get; set; } = "Delete bin and restart.";
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime MaxDate { get; set; } = DateTime.UtcNow;
        //To be gotten from field name
        public string NameLabel { get; set; } = "Name";

        public ListItem[] ListItems { get; set; }

        public InputFormViewModel()
        {
            ListItems = new ListItem[]
            {
                new ListItem()
                {
                    Imgsrc = "johnhancock.png",
                    Name = "John Hancock",
                    Detail = ""

                },
                new ListItem()
                {
                    Imgsrc = "kurtvonnegut.png",
                    Name = "Kurt Vonnegut",
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
