using System;
using Xamarin.Forms;

namespace Diplomatic.Views
{
    using ViewModels;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NextPage(object sender, EventArgs e)
        {
            var next = new Templates();
            next.BindingContext = new TemplatePickerViewModel();
            await Navigation.PushAsync(next);
        }

        private void OnShow(object sender, EventArgs e)
        {
            InfoLabel.IsVisible = !InfoLabel.IsVisible;
            LinkLabel.IsVisible = !LinkLabel.IsVisible;
        }

        private void OnLink(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://github.com/Dualog-students/Diplomatic"));
        }
    }
}
