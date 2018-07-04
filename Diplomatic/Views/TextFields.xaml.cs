using System;
using Xamarin.Forms;
namespace Diplomatic.Views
{
    using ViewModels;
    using Models;
    using System.Collections.Generic;

    public partial class TextFields : ContentPage
    {
        public TextFields()
        {
            InitializeComponent();
        }

        private async void NextPage(object sender, EventArgs e)
        {
            Template selectedTemplate = ((TextFieldViewModel)BindingContext).SelectedTemplate;

            if (selectedTemplate.HasSignature)
            {
                var next = new Signatures
                {
                    BindingContext = new SignaturePickerViewModel(selectedTemplate)
                };
                await Navigation.PushAsync(next);
            }
            else
            {
                var template = ((TextFieldViewModel)BindingContext).SelectedTemplate;
                var queryParams = new List<string> { };
                foreach (var field in template.Fields)
                {
                    queryParams.Add($"{field.Name.ToLower()}={field.Value}");
                }
                var query = string.Join("&", queryParams.ToArray());
                string final = "https://qri7p78aml.execute-api.eu-west-2.amazonaws.com/dev/" + template.Name.ToLower() + "?" + query;
                var endpoint = new Uri(Uri.EscapeUriString(final));
                var next = new Result
                {
                    BindingContext = new ResultViewModel(endpoint)
                };
                await Navigation.PushAsync(next);
            }
        }
    }
}
