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
    public partial class PokemonCollectionView : ContentPage
    {
        PokemonViewModel vm;

        public PokemonCollectionView()
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



    }
}