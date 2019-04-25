using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PokedexCollectionViewEN.ViewModels;

namespace PokedexCollectionViewEN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonSearchScroll : ContentPage
    {
        PokemonViewModel vm;

        public PokemonSearchScroll()
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

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var pokemon = searchBar.Text;
            var result = vm.SearchScrollPokemon(pokemon);

            if (result != null)
            {
                collectionView.ScrollTo(result, animate: false, position: ScrollToPosition.Center);
                collectionView.SelectedItem = result;
            }
        }
    }
}