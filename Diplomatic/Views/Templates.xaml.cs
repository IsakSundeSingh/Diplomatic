using System;
using System.Collections.Generic;
using Diplomatic.Core;
using Diplomatic.ViewModels;
using Xamarin.Forms;

namespace Diplomatic.Views
{
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
            var next = new TextFields();
            next.BindingContext = new TextFieldViewModel((Template)e.SelectedItem);

            await Navigation.PushAsync(next);
        }
    }
}
