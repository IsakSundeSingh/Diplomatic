using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplomatic.Views
{
    using Interfaces;
    using ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        public Result()
        {
            InitializeComponent();
        }
        public async void SaveButtonClicked(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                string Filename = ((ResultViewModel)BindingContext).Filename;
                byte[] imageBytes = await webClient.DownloadDataTaskAsync(((ResultViewModel)BindingContext).ImageUri);
                DependencyService.Get<IPicture>().SavePictureToDisk(Filename, imageBytes);

                await DisplayAlert("Save diploma", "Your diploma has been saved!", "OK");
            }
        }
    }
}
