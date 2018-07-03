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
            theImage.Source = ImageSource.FromUri(new System.Uri("https://qri7p78aml.execute-api.eu-west-2.amazonaws.com/dev/good%20effort?name=Dualog%20Student"));
        }
    }
}
