using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Diplomatic.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {

            return ConfigureApp.Android.StartApp();

        }
    }
}