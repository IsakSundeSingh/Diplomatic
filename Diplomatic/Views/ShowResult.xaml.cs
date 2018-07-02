using System.Collections.Generic;
using System.IO;
using System.Linq;
using Diplomatic.Core;
using Diplomatic.Utils;
using Diplomatic.ViewModels;
using Xamarin.Forms;

namespace Diplomatic.Views
{
    public partial class ShowResult : ContentPage
    {
        public ShowResult()
        {
            InitializeComponent();
        }

        public void ShowTemplate()
        {
            theImage.Source = "";
            Template template = ((TextFieldViewModel)BindingContext).SelectedTemplate;
            IEnumerable<byte> imageData = new ResourceLoader().LoadBinary("Images." + template.ResourcePath);
            Stream gen = new PNGGenerator().Generate(template, imageData.ToArray()).GetResult();
            
            theImage.Source = new ResourceLoader().LoadImage("employee.png");
        }
    }
}
