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
    public partial class CatEditPage : ContentPage
    {
        public Cat cat;
        public CatEditPage(Cat cat)
        {
            InitializeComponent();
            this.cat = cat;
            BindingContext = cat;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await App.TodoManager.SaveItemAsync(cat);
            await Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var todoItem = (Cat)BindingContext;
            await App.TodoManager.DeleteTodoAsync(todoItem);
            await Navigation.PopAsync();
        }
    }
}