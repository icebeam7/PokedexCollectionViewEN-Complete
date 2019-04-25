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
    public partial class Pokemon2CollectionViews : ContentPage
    {
        PokemonViewModel vm;

        public Pokemon2CollectionViews()
        {
            InitializeComponent();

            vm = new PokemonViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await vm.LoadIceDarkPokedex();

            await Task.Delay(5000);

            var articuno = vm.IcePokemonList.Where(x => x.name.english == "Articuno").FirstOrDefault();
            collectionViewIce.ScrollTo(articuno, position: ScrollToPosition.Center, animate: false);
        }

    }
}