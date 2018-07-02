using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Diplomatic.Views
{
    public partial class TextFields : ContentPage
    {
        public TextFields()
        {
            InitializeComponent();
        }
        async void NextPage(object sender, EventArgs e)
        {
            var next = new ShowResult
            {
                BindingContext = BindingContext
            };

            await Navigation.PushAsync(next);
        }
    }
}
