/* Menu.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
	/// <summary>
	/// Menu class.
	/// </summary>
	public static class Menu
	{
		/// <summary>
		/// Private list made for simplifying later code.
		/// </summary>
		private static Size[] _sizes = { Size.Small, Size.Medium, Size.Large };

		/// <summary>
		/// Private list made for simplifying later code.
		/// </summary>
		private static Crust[] _crusts = { Crust.Thin, Crust.Original, Crust.DeepDish };

		/// <summary>
		/// Private list made for simplifying later code.
		/// </summary>
		private static SodaFlavor[] _sodaFlavors = { SodaFlavor.Coke, SodaFlavor.Sprite, SodaFlavor.DrPepper, SodaFlavor.RootBeer, SodaFlavor.DietCoke };

		/// <summary>
		/// Private list made for simplifying later code.
		/// </summary>
		private static WingSauce[] _sauces = { WingSauce.Mild, WingSauce.Medium, WingSauce.Hot, WingSauce.HoneyBBQ };

		/// <summary>
		/// List of all possible pizzas.
		/// </summary>
		public static IEnumerable<IMenuItem> Pizzas
		{
			get
			{
				List<IMenuItem> result = new List<IMenuItem>();
				//Pizza
				for (int s = 0; s < 3; s++)
				{
					for (int c = 0; c < 3; c++)
					{
						Pizza p = new Pizza();
						p.PizzaSize = _sizes[s];
						p.PizzaCrust = _crusts[c];
						result.Add(p);
					}
				}
				//HawaiianPizza
				for (int s = 0; s < 3; s++)
				{
					for (int c = 0; c < 3; c++)
					{
						HawaiianPizza p = new HawaiianPizza();
						p.PizzaSize = _sizes[s];
						p.PizzaCrust = _crusts[c];
						result.Add(p);
					}
				}
				//MeatsPizza
				for (int s = 0; s < 3; s++)
				{
					for (int c = 0; c < 3; c++)
					{
						MeatsPizza p = new MeatsPizza();
						p.PizzaSize = _sizes[s];
						p.PizzaCrust = _crusts[c];
						result.Add(p);
					}
				}
				//SupremePizza
				for (int s = 0; s < 3; s++)
				{
					for (int c = 0; c < 3; c++)
					{
						SupremePizza p = new SupremePizza();
						p.PizzaSize = _sizes[s];
						p.PizzaCrust = _crusts[c];
						result.Add(p);
					}
				}
				//VeggiePizza
				for (int s = 0; s < 3; s++)
				{
					for (int c = 0; c < 3; c++)
					{
						VeggiePizza p = new VeggiePizza();
						p.PizzaSize = _sizes[s];
						p.PizzaCrust = _crusts[c];
						result.Add(p);
					}
				}
				return result;
			}
		}

		/// <summary>
		/// List of all possible sides.
		/// </summary>
		public static IEnumerable<IMenuItem> Sides
		{
			get
			{
				List<IMenuItem> result = new List<IMenuItem>();

				//Breadsticks
				for (int c = 0; c < 2; c++)
				{
					Breadsticks b = new Breadsticks();
					b.Cheese = (c == 1);
					result.Add(b);
				}
				//CinnamonSticks
				for (int f = 0; f < 2; f++)
				{
					CinnamonSticks c = new CinnamonSticks();
					c.Frosting = (f == 1);
					result.Add(c);
				}
				//GarlicKnots
				result.Add(new GarlicKnots());
				//Wings
				for (int b = 0; b < 2; b++)
				{
					for (int s = 0; s < 4; s++)
					{
						Wings w = new Wings();
						w.BoneIn = (b == 1);
						w.Sauce = _sauces[s];
						result.Add(w);
					}
				}

				return result;
			}
		}

		/// <summary>
		/// List of all possible drinks.
		/// </summary>
		public static IEnumerable<IMenuItem> Drinks
		{
			get
			{
				List<IMenuItem> result = new List<IMenuItem>();
				//IcedTea
				for (int s = 0; s < 3; s++)
				{
					IcedTea i = new IcedTea();
					i.DrinkSize = _sizes[s];
					result.Add(i);
				}
				//Soda
				for (int s = 0; s < 3; s++)
				{
					for (int f = 0; f < 5; f++)
					{
						Soda d = new Soda();
						d.DrinkSize = _sizes[s];
						d.DrinkType = _sodaFlavors[f];
						result.Add(d);
					}
				}

				return result;
			}
		}

		/// <summary>
		/// List of all items on the menu.
		/// </summary>
		public static IEnumerable<IMenuItem> FullMenu
		{
			get
			{
				List<IMenuItem> result = new List<IMenuItem>();
				foreach (IMenuItem p in Pizzas)
				{
					result.Add(p);
				}
				foreach (IMenuItem s in Sides)
				{
					result.Add(s);
				}
				foreach (IMenuItem d in Drinks)
				{
					result.Add(d);
				}
				return result;
			}
		}

        /// <summary>
        /// Searches the menu.
        /// </summary>
        /// <param name="terms">The search terms as entered into the form.</param>
        /// <param name="database">The database being searched.</param>
        /// <returns>The searched list.</returns>
        public static IEnumerable<IMenuItem> Search(string terms, IEnumerable<IMenuItem> database)
		{
			if (terms == null) return database;

			List<string> separateTerms = new List<string>(terms.Split(" "));
			List<IMenuItem> result = new List<IMenuItem>(database);

            foreach (string term in separateTerms)
			{
				result = new List<IMenuItem>(from m in result where (m.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase) || m.SpecialInstructions.Any(a => a.Contains(term, StringComparison.CurrentCultureIgnoreCase))) select m);
            }
            return result;
        }

        /// <summary>
		/// Filters the seach by price.
		/// </summary>
		/// <param name="database">The database being filtered.</param>
		/// <param name="min">The minimum value permitted.</param>
		/// <param name="max">The maximum value permitted</param>
		/// <returns>The filtered list.</returns>
        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> database, decimal? min, decimal? max)
        {
            if (min == null && max == null)
            {
                return database;
            }
            if (min == null)
            {
                return from m in database where m.Price <= max orderby m.Price descending select m;
            }
            if (max == null)
            {
                return from m in database where m.Price >= min orderby m.Price descending select m;
            }

            return from m in database where m.Price >= min && m.Price <= max orderby m.Price descending select m;
        }

        /// <summary>
		/// Filters the seach by calories.
		/// </summary>
		/// <param name="database">The database being filtered.</param>
		/// <param name="min">The minimum value permitted.</param>
		/// <param name="max">The maximum value permitted</param>
		/// <returns>The filtered list.</returns>
        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> database, uint? min, uint? max)
        {
            if (min == null && max == null)
            {
                return database;
            }
            if (min == null)
            {
                return from m in database where m.CaloriesPerEach <= max orderby m.CaloriesPerEach ascending select m;
            }
            if (max == null)
            {
                return from m in database where m.CaloriesPerEach >= min orderby m.CaloriesPerEach ascending select m;
            }
            return from m in database where m.CaloriesPerEach >= min && m.CaloriesPerEach <= max orderby m.CaloriesPerEach ascending select m;
        }
    }
}
