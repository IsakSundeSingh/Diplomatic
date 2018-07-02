using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Diplomatic.ViewModels;
using Diplomatic.Core;
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
            var next = new Signatures();

            next.BindingContext = new SignaturePickerViewModel(((TextFieldViewModel)BindingContext).SelectedTemplate);
            // We do not need to submit any info to the page here yet
            await Navigation.PushAsync(next);
        }
    }
}
