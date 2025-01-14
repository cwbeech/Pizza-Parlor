﻿/* MenuUnitTests.cs
 * Author: Calvin Beechner
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.DataTests
{
    /// <summary>
    /// Menu Unit Tests.
    /// </summary>
    public class MenuUnitTests
    {
        #region Private arrays.
        /// <summary>
		/// Private list made for simplifying later code.
		/// </summary>
		private Size[] _sizes = { Size.Small, Size.Medium, Size.Large };

        /// <summary>
        /// Private list made for simplifying later code.
        /// </summary>
        private Crust[] _crusts = { Crust.Thin, Crust.Original, Crust.DeepDish };

        /// <summary>
        /// Private list made for simplifying later code.
        /// </summary>
        private SodaFlavor[] _sodaFlavors = { SodaFlavor.Coke, SodaFlavor.Sprite, SodaFlavor.DrPepper, SodaFlavor.RootBeer, SodaFlavor.DietCoke };

        /// <summary>
        /// Private list made for simplifying later code.
        /// </summary>
        private WingSauce[] _sauces = { WingSauce.Mild, WingSauce.Medium, WingSauce.Hot, WingSauce.HoneyBBQ };

        /// <summary>
        /// Private array made for simlifying later code.
        /// </summary>
        private Pizza[] _pizzas = { new Pizza(), new HawaiianPizza(), new MeatsPizza(), new SupremePizza(), new VeggiePizza() };

        #endregion

        /// <summary>
        /// Tests that the number of pizzas equals 45;
        /// </summary>
        [Fact]
        public void CountPizzasEquals45()
        {
            Assert.Equal(45, Menu.Pizzas.Count());
        }

        /// <summary>
        /// Tests that the number of sides equals 13;
        /// </summary>
        [Fact]
        public void CountSidesEquals13()
        {
            Assert.Equal(13, Menu.Sides.Count());
        }
        /// <summary>
        /// Tests that the number of drinks equals 18;
        /// </summary>
        [Fact]
        public void CountDrinksEquals18()
        {
            Assert.Equal(18, Menu.Drinks.Count());
        }
        /// <summary>
        /// Tests that the number of menu items equals 76;
        /// </summary>
        [Fact]
        public void CountFullMenuEquals76()
        {
            Assert.Equal(76, Menu.FullMenu.Count());
        }

        /// <summary>
        /// Tests that the pizzas list has each unique combination.
        /// </summary>
        [Fact]
        public void PizzasHasUniqueCombinations()
        {
            //Pizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is Pizza && (item as Pizza).PizzaSize == _sizes[s] && (item as Pizza).PizzaCrust == _crusts[c]);
                }
            }
            //HawaiianPizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is HawaiianPizza && (item as HawaiianPizza).PizzaSize == _sizes[s] && (item as HawaiianPizza).PizzaCrust == _crusts[c]);
                }
            }
            //MeatsPizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is MeatsPizza && (item as MeatsPizza).PizzaSize == _sizes[s] && (item as MeatsPizza).PizzaCrust == _crusts[c]);
                }
            }
            //SupremePizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is SupremePizza && (item as SupremePizza).PizzaSize == _sizes[s] && (item as SupremePizza).PizzaCrust == _crusts[c]);
                }
            }
            //VeggiePizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is VeggiePizza && (item as VeggiePizza).PizzaSize == _sizes[s] && (item as VeggiePizza).PizzaCrust == _crusts[c]);
                }
            }
        }


        /// <summary>
        /// Tests that the sides list has each unique combination.
        /// </summary>
        [Fact]
        public void SidesHasUniqueCombinations()
        {
            //Breadsticks
            Assert.Contains(Menu.Sides, item => item is Breadsticks && (item as Breadsticks).Cheese == false);
            Assert.Contains(Menu.Sides, item => item is Breadsticks && (item as Breadsticks).Cheese == false);
            //CinnamonSticks
            Assert.Contains(Menu.Sides, item => item is CinnamonSticks && (item as CinnamonSticks).Frosting == false);
            Assert.Contains(Menu.Sides, item => item is CinnamonSticks && (item as CinnamonSticks).Frosting == false);
            //GarlicKnots
            Assert.Contains(Menu.Sides, item => item is GarlicKnots);
            //Wings
            for (int s = 0; s < 4; s++)
            {
                for (int bonein = 0; bonein < 2; bonein++)
                {
                    Assert.Contains(Menu.Sides, item => item is Wings && (item as Wings).Sauce == _sauces[s] && (item as Wings).BoneIn == (1 == bonein));
                }
            }
        }

        /// <summary>
        /// Tests that the drinks list has each unique combination.
        /// </summary>
        [Fact]
        public void DrinksHasUniqueCombinations()
        {
            //Soda
            for (int s = 0; s < 3; s++)
            {
                for (int d = 0; d < 5; d++)
                {
                    Assert.Contains(Menu.Drinks, item => item is Soda && (item as Soda).DrinkSize == _sizes[s] && (item as Soda).DrinkType == _sodaFlavors[d]);
                }
            }
            //IcedTea
            for (int s = 0; s < 3; s++)
            {
                Assert.Contains(Menu.Drinks, item => item is IcedTea && (item as IcedTea).DrinkSize == _sizes[s]);
            }
        }

        /// <summary>
        /// Tests that the full menu list has each unique combination.
        /// </summary>
        [Fact]
        public void FullMenuHasUniqueCombinations()
        {
            //Pizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is Pizza && (item as Pizza).PizzaSize == _sizes[s] && (item as Pizza).PizzaCrust == _crusts[c]);
                }
            }
            //HawaiianPizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is HawaiianPizza && (item as HawaiianPizza).PizzaSize == _sizes[s] && (item as HawaiianPizza).PizzaCrust == _crusts[c]);
                }
            }
            //MeatsPizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is MeatsPizza && (item as MeatsPizza).PizzaSize == _sizes[s] && (item as MeatsPizza).PizzaCrust == _crusts[c]);
                }
            }
            //SupremePizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is SupremePizza && (item as SupremePizza).PizzaSize == _sizes[s] && (item as SupremePizza).PizzaCrust == _crusts[c]);
                }
            }
            //VeggiePizza
            for (int s = 0; s < 3; s++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Assert.Contains(Menu.Pizzas, item => item is VeggiePizza && (item as VeggiePizza).PizzaSize == _sizes[s] && (item as VeggiePizza).PizzaCrust == _crusts[c]);
                }
            }
            //Breadsticks
            Assert.Contains(Menu.Sides, item => item is Breadsticks && (item as Breadsticks).Cheese == false);
            Assert.Contains(Menu.Sides, item => item is Breadsticks && (item as Breadsticks).Cheese == false);
            //CinnamonSticks
            Assert.Contains(Menu.Sides, item => item is CinnamonSticks && (item as CinnamonSticks).Frosting == false);
            Assert.Contains(Menu.Sides, item => item is CinnamonSticks && (item as CinnamonSticks).Frosting == false);
            //GarlicKnots
            Assert.Contains(Menu.Sides, item => item is GarlicKnots);
            //Wings
            for (int s = 0; s < 4; s++)
            {
                for (int bonein = 0; bonein < 2; bonein++)
                {
                    Assert.Contains(Menu.Sides, item => item is Wings && (item as Wings).Sauce == _sauces[s] && (item as Wings).BoneIn == (1 == bonein));
                }
            }
            //Soda
            for (int s = 0; s < 3; s++)
            {
                for (int d = 0; d < 5; d++)
                {
                    Assert.Contains(Menu.Drinks, item => item is Soda && (item as Soda).DrinkSize == _sizes[s] && (item as Soda).DrinkType == _sodaFlavors[d]);
                }
            }
            //IcedTea
            for (int s = 0; s < 3; s++)
            {
                Assert.Contains(Menu.Drinks, item => item is IcedTea && (item as IcedTea).DrinkSize == _sizes[s]);
            }
        }

        /// <summary>
        /// Tests that the search functions as expected.
        /// </summary>
        [Fact]
        public void SearchRefinesCorrectly()
        {
            //Null
            IEnumerable<IMenuItem> experiment = Menu.FullMenu;
            List<IMenuItem> expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                expected.Add(i);
            }
            experiment = Menu.Search(null, experiment);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //single term name
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.Name.Contains("Pizzas", StringComparison.CurrentCultureIgnoreCase)) expected.Add(i);
            }
            experiment = Menu.Search("Pizzas", experiment);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //single term specialInstructions
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.SpecialInstructions.Contains("Small", StringComparer.CurrentCultureIgnoreCase)) expected.Add(i);
            }
            experiment = Menu.Search("Small", experiment);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //multiple
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.SpecialInstructions.Contains("Small", StringComparer.CurrentCultureIgnoreCase) && i.Name.Contains("Pizza", StringComparison.CurrentCultureIgnoreCase)) expected.Add(i);
            }
            experiment = Menu.Search("Small Pizza", experiment);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //different capitalization
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.Name.Contains("pizzas", StringComparison.CurrentCultureIgnoreCase)) expected.Add(i);
            }
            experiment = Menu.Search("pizzas", experiment);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.SpecialInstructions.Contains("small", StringComparer.CurrentCultureIgnoreCase)) expected.Add(i);
            }
            experiment = Menu.Search("small", experiment);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.SpecialInstructions.Contains("small", StringComparer.CurrentCultureIgnoreCase) && i.Name.Contains("pizza", StringComparison.CurrentCultureIgnoreCase)) expected.Add(i);
            }
            experiment = Menu.Search("small pizza", experiment);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
        }

        /// <summary>
        /// Tests that the price filter functions as expected.
        /// </summary>
        [Fact]
        public void FilterPriceRefinesCorrectly()
        {
            //Null values
            IEnumerable<IMenuItem> experiment = Menu.FullMenu;
            List<IMenuItem> expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                expected.Add(i);
            }
            experiment = Menu.FilterByPrice(experiment, null, null);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //max
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.Price < 7) expected.Add(i);
            }
            experiment = Menu.FilterByPrice(experiment, null, 7);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //min
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.Price > 5) expected.Add(i);
            }
            experiment = Menu.FilterByPrice(experiment, 5, null);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //both min and max
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.Price > 5 && i.Price < 17) expected.Add(i);
            }
            experiment = Menu.FilterByPrice(experiment, 5, 17);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //unexpected min and max
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.Price < 5 && i.Price > 17) expected.Add(i);
            }
            experiment = Menu.FilterByPrice(experiment, 17, 5);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
        }

        /// <summary>
        /// Tests that the calories filter functions as expected.
        /// </summary>
        [Fact]
        public void FilterCaloriesRefinesCorrectly()
        {
            //Null values
            IEnumerable<IMenuItem> experiment = Menu.FullMenu;
            List<IMenuItem> expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                expected.Add(i);
            }
            experiment = Menu.FilterByCalories(experiment, null, null);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //max
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.CaloriesPerEach < 7) expected.Add(i);
            }
            experiment = Menu.FilterByCalories(experiment, null, 100);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //min
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.CaloriesPerEach > 50) expected.Add(i);
            }
            experiment = Menu.FilterByCalories(experiment, 50, null);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //both min and max
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.CaloriesPerEach > 50 && i.CaloriesPerEach < 100) expected.Add(i);
            }
            experiment = Menu.FilterByCalories(experiment, 50, 100);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
            //unexpected min and max
            experiment = Menu.FullMenu;
            expected = new List<IMenuItem>();
            foreach (IMenuItem i in experiment)
            {
                if (i.CaloriesPerEach < 50 && i.CaloriesPerEach > 100) expected.Add(i);
            }
            experiment = Menu.FilterByCalories(experiment, 100, 50);
            foreach (IMenuItem i in expected)
            {
                Assert.Contains(i, experiment);
            }
            foreach (IMenuItem i in experiment)
            {
                Assert.Contains(i, expected);
            }
        }
    }
}
