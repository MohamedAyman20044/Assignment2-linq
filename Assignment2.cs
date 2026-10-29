using static LINQ.DataSources.Source;

namespace LINQ
{
	public static class Assignment02
	{
		public static void Run()
		{
			Console.WriteLine("\n\n===== Assignment 02 =====");

			// Q1
			Console.WriteLine("\nQ1");
			var seafood = ProductList.Where(p => p.Category == "Seafood");
			foreach (var p in seafood)
			    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// Q2
			Console.WriteLine("\nQ2");
			var productNames = ProductList.Select(p => p.ProductName).ToList();
			foreach (var name in productNames)
			    Console.WriteLine(name);

			// Q3
			Console.WriteLine("\nQ3");
			var sortedByPrice = ProductList.OrderBy(p => p.UnitPrice);
			foreach (var p in sortedByPrice)
			    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// Q4
			Console.WriteLine("\nQ4");
			var between10And30 = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
			foreach (var p in between10And30)
			    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");

			// Q5
			Console.WriteLine("\nQ5");
			var condimentsInStock = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
			foreach (var p in condimentsInStock)
			    Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

			// Q6
			Console.WriteLine("\nQ6");
			var summary = ProductList.Select(p => new
			{
			    Name = p.ProductName,
			    Price = p.UnitPrice,
			    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
			});
			foreach (var item in summary)
			    Console.WriteLine($"{item.Name} | {item.Price} | {item.StockStatus}");

			// Q7
			Console.WriteLine("\nQ7");
			var numbered = ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
			foreach (var line in numbered)
			    Console.WriteLine(line);

			// Q8
			Console.WriteLine("\nQ8");
			var sortedProducts = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
			foreach (var p in sortedProducts)
			    Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice}");

			// Q9
			Console.WriteLine("\nQ9");
			var beverages = ProductList
			    .Where(p => p.Category == "Beverages")
			    .OrderByDescending(p => p.UnitsInStock);
			foreach (var p in beverages)
			    Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");

			// Q10
			Console.WriteLine("\nQ10");
			var recentOrders = from c in CustomerList
			                   from o in c.Orders
			                   where o.OrderDate.Year >= 1997
			                   select new { c.CustomerID, o.OrderDate };
			foreach (var o in recentOrders)
			    Console.WriteLine($"{o.CustomerID} - {o.OrderDate:yyyy-MM-dd}");

			// Q11
			Console.WriteLine("\nQ11");
			var withPosition = ProductList.Select((p, i) => new { Position = i + 1, p.ProductName });
			foreach (var item in withPosition)
			    Console.WriteLine($"{item.Position} - {item.ProductName}");

			// Q12
			Console.WriteLine("\nQ12");
			string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
			var sortedWords = Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
			foreach (var w in sortedWords)
			    Console.WriteLine(w);

			// Q13
			Console.WriteLine("\nQ13");
			var secondLetterI = Arr
			    .Where(w => w.Length > 1 && char.ToLower(w[1]) == 'i')
			    .Reverse()
			    .ToList();
			foreach (var w in secondLetterI)
			    Console.WriteLine(w);
		}
	}
}
