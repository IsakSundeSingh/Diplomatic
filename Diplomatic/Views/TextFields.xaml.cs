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
        async void NextPage(object sender, EventArgs e)
        {
            var next = new Signatures();

            next.BindingContext = new SignaturePickerViewModel(((TextFieldViewModel)BindingContext).SelectedTemplate);
            // We do not need to submit any info to the page here yet
            await Navigation.PushAsync(next);
        }
    }
}
