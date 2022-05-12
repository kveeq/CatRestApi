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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Cat cat = new Cat(qw.Text, qwq.Text, qwqw.IsChecked);
            App.TodoManager.SaveItemAsync(cat, true);
        }
    }
}