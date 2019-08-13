using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JWQuantum.Models;
using JWQuantum.Views;
using JWQuantum.ViewModels;

namespace JWQuantum.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        public void OnNotAtHome(object sender, EventArgs e)
        {
            var mi = ((MenuItem) sender);

            var answer = DisplayAlert("Not At Home", $"Are you sure you want to mark as not at home?", "Yes", "No");


            //if (answer.Result == true)
            //{
            //    DisplayAlert("Success!", $"Not at home!", "Ok");
            //}

        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);

            var answer = DisplayAlert("Delete", $"{mi.CommandParameter} delete context action", "Yes", "No");

            //if (answer)
            //{
            //    DisplayAlert("Deleted!", $"Deleted!", "Ok");
            //}
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}