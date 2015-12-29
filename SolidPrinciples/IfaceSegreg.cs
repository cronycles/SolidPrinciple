using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	public class IfaceSegreg : DisplayableSample, DisplayableSampleSplitted
	{
		public string Run()
		{
			var result = this.GetHeader();
			result += Environment.NewLine + Environment.NewLine + RunWrongApproach();
			result += Environment.NewLine + Environment.NewLine + RunCorrectApproach();

			return result;
		}

		public string GetHeader()
		{
			var result = "IfaceSegreg.cs";
			result += Environment.NewLine + "many client-specific interfaces are better than one general-purpose interface";
			return result;
		}

		public string RunWrongApproach()
		{
			var explanation = new StringBuilder();

			explanation.AppendLine("--- WRONG APPROACH ---");
			explanation.AppendLine("Getting all items using a common interface will introduce several properties not used in objects");

			var wrongApproach = new WrongApproach();
			List<WrongApproach.SellableItem> items = wrongApproach.GetAllProducts();

			var vegetableProducts = items.Where(x => x.MeasurementUnit == "Kg").ToList();
			var ageragePriceOfVegetables = vegetableProducts.Average((v) => v.Price);
			explanation.AppendLine("In this approach there are:");
			explanation.AppendLine($"\t{vegetableProducts.Count} vegetables products with an average price of {ageragePriceOfVegetables}€/Kg");

			var tvProducts = items.Where(x => x.Name.ToLower().Contains("tv")).ToList();
			var differentResolutions = tvProducts.Select(tv => tv.Resolution).Distinct().Count();
			explanation.AppendLine($"\t{tvProducts.Count} TVs of {differentResolutions} different resolutions");

			var schollItems = items.Where(x => "Clothing4Youth,WealthyLife,LearningSolutions".ToLower().Contains(x.ProviderName.ToLower())).ToList();
			var shoesItems = schollItems.Where(i => i.MeasurementUnit == "pair").Count();
			explanation.AppendLine($"\t{schollItems.Count} school items, and {shoesItems} of them are shoes");

			string vegetableProperties = vegetableProducts.First().GetType().GetProperties().Select(p => p.Name).Aggregate((name, nextName) => $"{name}, {nextName}");
			explanation.AppendLine("Vegetable visible properties: " + vegetableProperties);

			return explanation.ToString();
		}

		public string RunCorrectApproach()
		{
			var explanation = new StringBuilder();

			explanation.AppendLine("--- CORRECT APPROACH ---");
			explanation.AppendLine("Getting all items using a specific interfaces will allow to use objects with the needed properties");

			var wrongApproach = new CorrectApproach();
			List<CorrectApproach.SellableItem> items = wrongApproach.GetAllProducts();

			var vegetableProducts = items.Where(x => x.MeasurementUnit == "Kg").ToList();
			var ageragePriceOfVegetables = vegetableProducts.Average((v) => v.Price);
			explanation.AppendLine("In this approach there are:");
			explanation.AppendLine($"\t{vegetableProducts.Count} vegetables products with an average price of {ageragePriceOfVegetables}€/Kg");

			var tvProducts = items.Where(x => x.Name.ToLower().Contains("tv")).Select(x => (CorrectApproach.PixelMeasureable)x).ToList();
			var differentResolutions = tvProducts.Select(tv => tv.Resolution).Distinct().Count();
			explanation.AppendLine($"\t{tvProducts.Count} TVs of {differentResolutions} different resolutions");

			var schollItems = items
				.Where(x => "Clothing4Youth,WealthyLife,LearningSolutions".ToLower().Contains(x.ProviderName.ToLower())).Select(x => (CorrectApproach.Sizable)x).ToList();
			var shoesItems = schollItems.Where(i => i.MeasurementUnit == "pair").Count();
			explanation.AppendLine($"\t{schollItems.Count} school items, and {shoesItems} of them are shoes");

			string vegetableProperties = vegetableProducts.First().GetType().GetInterface("SellableItem").GetProperties().Select(p => p.Name).Aggregate((name, nextName) => $"{name}, {nextName}");
			explanation.AppendLine("Vegetable visible properties: " + vegetableProperties);

			return explanation.ToString();
		}

		private class WrongApproach
		{
			public interface SellableItem
			{
				string Name { get; set; }
				decimal Price { get; set; }
				string MeasurementUnit { get; set; }
				string Resolution { get; set; }
				decimal WeightInKg { get; set; }
				string Brand { get; set; }
				string ProviderName { get; set; }
				string Measurements { get; set; }
			}

			public class Product : SellableItem
			{
				public string Brand { get; set; }
				public string Measurements { get; set; }
				public string MeasurementUnit { get; set; }
				public string Name { get; set; }
				public decimal Price { get; set; }
				public string ProviderName { get; set; }
				public string Resolution { get; set; }
				public decimal WeightInKg { get; set; }
			}

			public List<SellableItem> GetAllProducts()
			{
				return new List<SellableItem>
				{
					new Product { Name = "Tomato", Brand = "Maravilla", Measurements = null, Resolution = null, Price = 1.10M, MeasurementUnit  = "Kg",  ProviderName = "NYFarms", WeightInKg = 0},
					new Product { Name = "Cucumber", Brand = "Maravilla", Measurements = null, Resolution = null, Price = 0.80M, MeasurementUnit  = "Kg", ProviderName = "NYFarms", WeightInKg = 0},
					new Product { Name = "3D TV", Brand = "RealWorld", Measurements = "40\"", Resolution = "UHD", Price = 4520.00M, MeasurementUnit  = "unit", ProviderName = "EWare", WeightInKg = 25},
					new Product { Name = "LED TV", Brand = "TeraImage", Measurements = "50\"", Resolution = "Full HD", Price = 4605.00M, MeasurementUnit  = "unit", ProviderName = "EWare", WeightInKg = 23},
					new Product { Name = "Camp boots", Brand = "KidsPlace", Measurements = "19", Resolution = null, Price = 15.80M, MeasurementUnit  = "pair", ProviderName = "Clothing4Youth", WeightInKg = 0},
					new Product { Name = "Tennis shoes", Brand = "SportIng", Measurements = "38", Resolution = null, Price = 1.10M, MeasurementUnit  = "pair", ProviderName = "WealthyLife", WeightInKg = 0},
					new Product { Name = "Pencil", Brand = "DrawBlack", Measurements = null, Resolution = "0.5", Price = 0.20M, ProviderName = "LearningSolutions", WeightInKg = 0},
					new Product { Name = "Pen", Brand = "DrawBlack", Measurements = null, Resolution = "0.3", Price = 0.95M, ProviderName = "LearningSolutions", WeightInKg = 0},
				};
			}

			
		}

		private class CorrectApproach
		{
			public interface SellableItem
			{
				string Name { get; set; }
				decimal Price { get; set; }
				string MeasurementUnit { get; set; }
				string Brand { get; set; }
				string ProviderName { get; set; }
			}
			public interface PixelMeasureable : SellableItem { string Resolution { get; set; } }
			public interface Sizable : SellableItem { string Measurements { get; set; } }
			public interface UnitWeightable : SellableItem { decimal WeightInKg { get; set; } }

			public class Product : PixelMeasureable, Sizable, UnitWeightable
			{
				public string Brand { get; set; }
				public string Measurements { get; set; }
				public string MeasurementUnit { get; set; }
				public string Name { get; set; }
				public decimal Price { get; set; }
				public string ProviderName { get; set; }
				public string Resolution { get; set; }
				public decimal WeightInKg { get; set; }
			}

			public List<SellableItem> GetAllProducts()
			{
				return new List<SellableItem>
				{
					new Product { Name = "Tomato", Brand = "Maravilla", Measurements = null, Resolution = null, Price = 1.10M, MeasurementUnit  = "Kg",  ProviderName = "NYFarms", WeightInKg = 0},
					new Product { Name = "Cucumber", Brand = "Maravilla", Measurements = null, Resolution = null, Price = 0.80M, MeasurementUnit  = "Kg", ProviderName = "NYFarms", WeightInKg = 0},
					new Product { Name = "3D TV", Brand = "RealWorld", Measurements = "40\"", Resolution = "UHD", Price = 4520.00M, MeasurementUnit  = "unit", ProviderName = "EWare", WeightInKg = 25},
					new Product { Name = "LED TV", Brand = "TeraImage", Measurements = "50\"", Resolution = "Full HD", Price = 4605.00M, MeasurementUnit  = "unit", ProviderName = "EWare", WeightInKg = 23},
					new Product { Name = "Camp boots", Brand = "KidsPlace", Measurements = "19", Resolution = null, Price = 15.80M, MeasurementUnit  = "pair", ProviderName = "Clothing4Youth", WeightInKg = 0},
					new Product { Name = "Tennis shoes", Brand = "SportIng", Measurements = "38", Resolution = null, Price = 1.10M, MeasurementUnit  = "pair", ProviderName = "WealthyLife", WeightInKg = 0},
					new Product { Name = "Pencil", Brand = "DrawBlack", Measurements = null, Resolution = "0.5", Price = 0.20M, ProviderName = "LearningSolutions", WeightInKg = 0},
					new Product { Name = "Pen", Brand = "DrawBlack", Measurements = null, Resolution = "0.3", Price = 0.95M, ProviderName = "LearningSolutions", WeightInKg = 0},
				};
			}
		}
	}
}
