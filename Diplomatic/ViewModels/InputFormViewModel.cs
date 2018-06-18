using System;
using System.Collections.Generic;
using System.Text;

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
                    Image = "johnhancock.png",
                    Celeb = "John Hancock"

                },
                new ListItem()
                {
                    Image = "Icon.png",
                    Celeb = "Kurt Vonnegut"
                }
            };
        }
        

    }

    public class ListItem
    {
        public string Image { get; set; }
        public string Celeb { get; set; }

    }
}
