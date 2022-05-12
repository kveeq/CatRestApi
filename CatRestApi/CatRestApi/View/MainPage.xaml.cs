using CatRestApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CatRestApi.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            catsLstView.ItemsSource = await App.TodoManager.GetTodoItemModels();
        }

        private async void catsLstView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new CatEditPage( (Cat)e.SelectedItem) );
        }

        private async void AddNavigatePageBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCatPage());
        }
    }
}
