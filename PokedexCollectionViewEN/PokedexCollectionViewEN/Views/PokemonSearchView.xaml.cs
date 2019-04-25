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
    public partial class PokemonSearchView : ContentPage
    {
        PokemonViewModel vm;

        public PokemonSearchView()
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
            vm.SearchPokemon(pokemon);
        }
    }
}