using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Diplomatic.Views
{
    using Models;
    using ViewModels;

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
                Template template = ((TextFieldViewModel)BindingContext).SelectedTemplate;
                string Filename = template.Name + "_";
                var queryParams = new List<string> { };

                foreach (Field field in template.Fields)
                {
                    Filename += field.Name + "_" + field.Value + "_";
                    queryParams.Add($"{field.Name.ToLower()}={field.Value}");
                }

                string query = string.Join("&", queryParams.ToArray());
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
}
