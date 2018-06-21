using System;
using Xamarin.Forms;

namespace Diplomatic.Views
{
    public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();
        }

        async void NextPage (object sender, EventArgs e)
        {
            var next = new Templates();
            // We do not need to submit any info to the page here yet
            await Navigation.PushAsync(next);
        }

        void OnShow ( object sender, EventArgs e)
        {
            InfoLabel.IsVisible = !InfoLabel.IsVisible;
        }

    }
}
