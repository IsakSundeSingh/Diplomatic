using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplomatic.Extensions.Markup
{
    using Diplomatic.Utils;

    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            var loader = new ResourceLoader();
            ImageSource image = loader.LoadImage(Source);
            
            return image;
        }
    }
}
