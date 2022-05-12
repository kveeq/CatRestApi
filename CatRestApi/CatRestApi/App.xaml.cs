using CatRestApi.Services;
using CatRestApi.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatRestApi
{
    public partial class App : Application
    {
        public static TodoManager TodoManager { get; set; }

        public App()
        {
            InitializeComponent(); 
            TodoManager = new TodoManager(new RestService());
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
