using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegStore.Models
{
    public partial class Vegetable : ObservableObject
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;

        public double Price { get; set; }

        [ObservableProperty,
         NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => CartQuantity * Price;

       public Vegetable Clone() => MemberwiseClone() as Vegetable;

    }
}
