using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegStore.Models
{
    public partial class VegStore : ObservableObject
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public double Price { get; set; }

        [ObservableProperty,
         NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => _cartQuantity * Price;

       public VegStore Clone() => MemberwiseClone() as VegStore;

    }
}
