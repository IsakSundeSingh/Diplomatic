using Xamarin.Forms;

namespace Diplomatic.Views
{
    using Models;
    using ViewModels;

    public partial class Templates : ContentPage
    {
        public Templates()
        {
            InitializeComponent();
                
        }

        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            var next = new TextFields
            {
                BindingContext = new TextFieldViewModel((Template)e.SelectedItem)
            };

            await Navigation.PushAsync(next);
        }
    }
}
