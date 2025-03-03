using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegStore.Models;

namespace VegStore.Service
{
    public class VegetableService
    {
        private readonly static IEnumerable<Vegetable> _Vegetables = new List<Vegetable>
        {
            new Vegetable
            {
                Name = "Tomato",
                Image = "tomato",
                Price = 5.00,
            },
            new Vegetable
            {
                Name = "Bell Pepper",
                Image = "bell_pepper",
                Price = 9.00,
            },
            new Vegetable
            {
                Name = "Broccoli",
                Image = "broccoli",
                Price = 12.00,
            },
            new Vegetable
            {
                Name = "Carrot",
                Image = "carrot",
                Price = 7.00,
            },
            new Vegetable
            {
                Name = "Corn",
                Image = "corn",
                Price = 15.00,
            },
            new Vegetable
            {
                Name = "Lettuce",
                Image = "salad",
                Price = 11.00,
            },
            new Vegetable
            {
                Name = "Red Chill",
                Image = "red_chili_pepper",
                Price = 5.00,
            },
            new Vegetable
            {
                Name = "Pumpkin",
                Image = "pumpkin",
                Price = 50.00,
            }
        };

        public IEnumerable<Vegetable> GetAllVegetables() => _Vegetables;

        public IEnumerable<Vegetable> GetPopularVegetables(int count = 6) => _Vegetables
            .OrderBy(p => Guid.NewGuid()).Take(count);

        public IEnumerable<Vegetable> SearchVegetables(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _Vegetables
            : _Vegetables.Where(p => p.Name.Contains(searchTerm,
                StringComparison.OrdinalIgnoreCase));
    }
}
