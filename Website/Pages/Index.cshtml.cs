using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaParlor.Data;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The menu items that are displayed.
        /// </summary>
        public IEnumerable<IMenuItem> MenuItems { get; set; }

        /// <summary>
        /// The pizza items that are displayed.
        /// </summary>
        public IEnumerable<IMenuItem> PizzaItems { get; set; }

        /// <summary>
        /// The side items that are displayed.
        /// </summary>
        public IEnumerable<IMenuItem> SideItems { get; set; }

        /// <summary>
        /// The drink items that are displayed.
        /// </summary>
        public IEnumerable<IMenuItem> DrinkItems { get; set; }

        /// <summary>
        /// The search prompt.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        /// <summary>
        /// The minimum price.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// The maximum price.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// The minimum calories.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CalMin { get; set; }

        /// <summary>
        /// The maximum calories.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CalMax { get; set; }

        public void OnGet()
        {
            MenuItems = Menu.Search(SearchTerms, Menu.FullMenu);
            PizzaItems = Menu.Search(SearchTerms, Menu.Pizzas);
            SideItems = Menu.Search(SearchTerms, Menu.Sides);
            DrinkItems = Menu.Search(SearchTerms, Menu.Drinks);

            MenuItems = Menu.FilterByPrice(MenuItems, PriceMin, PriceMax);
            PizzaItems = Menu.FilterByPrice(PizzaItems, PriceMin, PriceMax);
            SideItems = Menu.FilterByPrice(SideItems, PriceMin, PriceMax);
            DrinkItems = Menu.FilterByPrice(DrinkItems, PriceMin, PriceMax);

            MenuItems = Menu.FilterByCalories(MenuItems, CalMin, CalMax);
            PizzaItems = Menu.FilterByCalories(PizzaItems, CalMin, CalMax);
            SideItems = Menu.FilterByCalories(SideItems, CalMin, CalMax);
            DrinkItems = Menu.FilterByCalories(DrinkItems, CalMin, CalMax);
        }
    }
}