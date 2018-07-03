using System;
using Diplomatic.ViewModels;
using Xamarin.Forms;
namespace Diplomatic.Views
{
    public partial class TextFields : ContentPage
    {
        public TextFields()
        {
            InitializeComponent();
        }

        private async void NextPage(object sender, EventArgs e)
        {
            var next = new Signatures
            {
                BindingContext = new SignaturePickerViewModel(((TextFieldViewModel)BindingContext).SelectedTemplate)
            };
            await Navigation.PushAsync(next);
        }
    }
}
