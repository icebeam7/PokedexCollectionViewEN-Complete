using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PokedexCollectionViewEN.ViewModels;
using PokedexCollectionViewEN.Models;

namespace PokedexCollectionViewEN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonSelectionView : ContentPage
    {
        PokemonViewModel vm;

        public PokemonSelectionView()
        {
            InitializeComponent();

            vm = new PokemonViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadPokedex();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pokemon = e.CurrentSelection.First() as Pokemon;

            var page = new PokemonPopUpPage(pokemon);
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(page);
        }
    }
}