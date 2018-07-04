using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplomatic.Views
{
    using Models;
    using ViewModels;

    public partial class Signatures : ContentPage
    {
        public Signatures()
        {
            InitializeComponent();
        }

        async void NextPage(object sender, SelectedItemChangedEventArgs e)
        {
            var template = ((SignaturePickerViewModel)BindingContext).SelectedTemplate;
            template.Signature = (Signature)e.SelectedItem;
            string Filename = template.Name + "_";
            var queryParams = new List<string> { };
            foreach (var field in template.Fields)
            {
                Filename += field.Name + "_" + field.Value +"_";
                queryParams.Add($"{field.Name.ToLower()}={field.Value}");
            }
            queryParams.Add($"signature={template.Signature.Id}");
            var query = string.Join("&", queryParams.ToArray());
            string final = "https://qri7p78aml.execute-api.eu-west-2.amazonaws.com/dev/" + template.Name.ToLower() + "?" + query;
            var endpoint = new Uri(Uri.EscapeUriString(final));
            var next = new Result
            {
                BindingContext = new ResultViewModel(endpoint, Filename)
            };
            await Navigation.PushAsync(next);
        }
    }
}
