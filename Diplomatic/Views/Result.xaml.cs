using System;
using System.Net;
using Diplomatic.Interfaces;
using Diplomatic.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplomatic.Views
{
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
                byte[] imageBytes = await webClient.DownloadDataTaskAsync(((ResultViewModel)BindingContext).ImageUri);
                DependencyService.Get<IPicture>().SavePictureToDisk("Navn", imageBytes);
                await DisplayAlert("Image save", "Your diploma has been saved!", "Ok");

            }
        }
    }
}