using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace VegStore.ViewModels
{
    [QueryProperty(nameof(Vegetable), nameof(Vegetable))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel= cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;

        }

        private void OnCartCleared(object? _, EventArgs e) => Vegetable.CartQuantity = 0;
        private void OnCartItemRemoved(object? _, Vegetable p) => OnCartItemChanged(p, 0);
        private void OnCartItemUpdated(object? _, Vegetable p) => OnCartItemChanged(p, p.CartQuantity);

        private void OnCartItemChanged(Vegetable p, int quantity)
        {
            if (p.Name == Vegetable.Name)
            { 
                Vegetable.CartQuantity = quantity;
            }
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

        public void Dispose()
        {

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }
    }
}
