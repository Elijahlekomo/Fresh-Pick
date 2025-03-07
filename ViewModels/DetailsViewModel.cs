using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegStore.ViewModels
{
    [QueryProperty(nameof(Vegetable), nameof(Vegetable))]
    public partial class DetailsViewModel : ObservableObject
    {
        public DetailsViewModel()
        {
        }

        [ObservableProperty]
        private Vegetable _vegetable;
    }
}
