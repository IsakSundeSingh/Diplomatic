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

        public void ShowTemplate(object sender, System.EventArgs e)
        {
            theImage.Source = "";
            Template template = ((TextFieldViewModel)BindingContext).SelectedTemplate;
            IEnumerable<byte> imageData =
                new ResourceLoader()
                .LoadBinary("Images." + template.ResourcePath);
            byte[] img = ((PNGDiploma)new PNGGenerator().Generate(template, imageData.ToArray())).imageData;
            theImage.Source = ImageSource.FromStream(() => new MemoryStream(img));
        }
    }
}
