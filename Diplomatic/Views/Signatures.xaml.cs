using System;
using System.Collections.Generic;
using Diplomatic.ViewModels;
using Xamarin.Forms;

namespace Diplomatic.Views
{
    public partial class Signatures : ContentPage
    {
        public Signatures()
        {
            InitializeComponent();
        }

        async void NextPage(object sender, EventArgs e)
        {
            var template = ((SignaturePickerViewModel)BindingContext).SelectedTemplate;
            string Filename = template.TemplateName + "_";
            var queryParams = new List<string> { };
            foreach (var field in template.Fields)
            {
                Filename += field.Name + "_" + field.Value +"_";
                queryParams.Add($"{field.Name.ToLower()}={field.Value}");
            }
            var query = string.Join("&", queryParams.ToArray());
            string final = "https://qri7p78aml.execute-api.eu-west-2.amazonaws.com/dev/" + template.TemplateName.ToLower() + "?" + query;
            var endpoint = new Uri(Uri.EscapeUriString(final));
            var next = new Result
            {
                BindingContext = new ResultViewModel(endpoint, Filename)
            };
            await Navigation.PushAsync(next);
        }
    }
}
