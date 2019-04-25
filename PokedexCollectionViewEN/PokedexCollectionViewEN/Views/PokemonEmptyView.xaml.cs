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
    public partial class PokemonEmptyView : ContentPage
    {
        PokemonViewModel vm;

        public PokemonEmptyView()
        {
            InitializeComponent();

            vm = new PokemonViewModel();
            BindingContext = vm;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await vm.LoadPokedex();
        }
    }
}