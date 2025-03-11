using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace VegStore.ViewModels
{
    [QueryProperty(nameof(Vegetable), nameof(Vegetable))]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel= cartViewModel;
        }

        [ObservableProperty]
        private Vegetable _vegetable;

        [RelayCommand]
        private void AddToCart()
        {
            Vegetable.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Vegetable);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Vegetable.CartQuantity > 0)
            {
                Vegetable.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Vegetable);
            }

        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if (Vegetable.CartQuantity > 0)
            {
                await  Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Add item to cart", ToastDuration.Short).Show();
            }
        }
    }
}
