using CatRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatRestApi.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCatPage : ContentPage
    {
        public AddCatPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Cat cat = new Cat(Guid.NewGuid().ToString(), qw.Text, qwq.Text, qwqw.IsChecked);
            await App.TodoManager.SaveItemAsync(cat, true);
            await Navigation.PopAsync();
        }
    }
}