// See https://aka.ms/new-console-template for more information
using Prj.Net6.ConsoleApp2;

//Console.WriteLine("Hello, World!");

//
var numbers = new List<int>() { 10, 4, 8, 10 };
var fruits = new List<string>() { "Banana", "Apple", "Orange" };
var stock = new List<Stock>()
    {
        new Stock{Sku = "001", ModelName = "iphone11", Category = "iPhone 11", Qty = 5555 },
        new Stock{Sku = "002", ModelName = "iphone11 pro", Category = "iPhone 11", Qty = 44 },
        new Stock{Sku = "003", ModelName = "iphone11 pro max", Category = "iPhone 11", Qty = 100 },
        new Stock{Sku = "004", ModelName = "iphone12", Category = "iPhone 12", Qty = 55 },
        new Stock{Sku = "005", ModelName = "iphone12 pro", Category = "iPhone 12", Qty = 44 },
        new Stock{Sku = "006", ModelName = "iphone12 pro max", Category = "iPhone 12", Qty = 10 },
    };

var sale = new List<Sales>()
    {
        new Sales{ Sku  = "001", SaleRecord = 400 },
        new Sales{ Sku  = "004", SaleRecord = 600}
    };

    var averageNumber = numbers.Average(); //ouput 8
    var averageLength = fruits.Average(s => s.Length); //output 5.666666666666667
                                                       //​
    var averageCategories = (from c in stock
                             group c by c.Category into d
                             select (Category: d.Key, AverageStock: d.Average(s => s.Qty))); //ouput iPhone 11:1899.6666666666667, iPhone 12: 36.333333333333336

    foreach (var item in averageCategories)
    {
        Console.WriteLine($"{item.Category} {item.AverageStock}");
    }


    var count = numbers.Count(); //ouput 4
    var minNumber = numbers.Max(); //ouput 10
    var shortestWordFruit = fruits.Max(s => s.Length); //output 6
    var uniqueCount = numbers.Distinct().Count(); //ouput 3
    var oddNumber = numbers.Count(s => s % 2 == 1);// ouput 0

    var categoriesCount = (from c in stock
                           group c by c.Category into d
                           select (Category: d.Key, TotalStock: d.Count())); //output iPhone 11: 3; iPhone 12: 3

    foreach (var item2 in categoriesCount)
    {
        Console.WriteLine($"{item2.Category} {item2.TotalStock}");
    }


    var crossJoin = (from c in stock
                     join d in sale on c.Sku equals d.Sku into ps
                     from p in ps
                     select (ModelName: c.ModelName, SaleRecord: p.SaleRecord)); //it also select items that match both lists.

    foreach (var item3 in crossJoin)
    {
        Console.WriteLine($"{item3.ModelName} {item3.SaleRecord}");
    }

    //Linq left join
    var salesRecord = (from c in stock
                       join d in sale on c.Sku equals d.Sku into ps
                       from d in ps.DefaultIfEmpty()
                       select new
                       {
                           ModelName = c.ModelName,
                           salesrecord = d == null ? "No Sales" : d.SaleRecord.ToString()
                       });

    // Max
    var categories = (from c in stock
                      group c by c.Category into d
                      select (Category: d.Key, ExpensiveStock: d.Max(s => s.Qty))); //ouput iPhone 11:5555, iPhone 12: 55


    // Order By
    var ascOrder = stock.OrderBy(o => o.ModelName).ToList();
    var ascOrder1 = (from c in stock orderby c.ModelName select c).ToList();

    var descOrder = stock.OrderByDescending(o => o.ModelName).ToList();
    var descOrder1 = (from c in stock orderby c.ModelName descending select c).ToList();

    // Sum
    var categories_sum = (from c in stock
                  group c by c.Category into d
                  select (Category: d.Key, TotalStock: d.Sum(s => s.Qty))); //output iPhone 11: 5699 and iPhone 12: 109

    // Where
    var iphone11 = stock.Where(w => w.ModelName == "iphone11").FirstOrDefault();



// 
Console.ReadLine();


//
ToArrayEx1();

//
Console.ReadLine();


//
QueryHighScores(1, 85);


//Enum to List
var enumtolist = Enum.GetValues(typeof(GradeLevel))
                .Cast<GradeLevel>()
                .Select(v => v.ToString())
                .ToList();






//
Console.ReadLine();

//---------------------------------------------------------
//
static void QueryHighScores(int exam, int score)
{
    List<Student> students = new List<Student>{
        new Student { FirstName ="Terry", LastName ="Adams", ID = 120, Year = GradeLevel.SecondYear, ExamScores = new() { 99, 82, 81, 79 }},
        new Student { FirstName ="Fadi", LastName ="Fakhouri", ID = 116, Year = GradeLevel.ThirdYear, ExamScores = new() { 99, 86, 90, 94 }},
        new Student { FirstName ="Hanying", LastName ="Feng", ID = 117, Year = GradeLevel.FirstYear, ExamScores = new() { 93, 92, 80, 87 }},

    };

    var highScores = from student in students
                        where student.ExamScores[exam] > score
                        select new
                        {
                            Name = student.FirstName,
                            Score = student.ExamScores[exam]
                        };

    foreach (var item in highScores)
    {
        Console.WriteLine($"{item.Name,-15} {item.Score}");
    }
}

//
static void ToArrayEx1()
{
    List<Package> packages = new List<Package>{ 
        new Package { Company = "Coho Vineyard", Weight = 25.2 },
        new Package { Company = "Lucerne Publishing", Weight = 18.7 },
        new Package { Company = "Wingtip Toys", Weight = 6.0 },
        new Package { Company = "Adventure Works", Weight = 33.8 } 
    };

    string[] companies = packages.Select(pkg => pkg.Company).ToArray();

    foreach (string company in companies)
    {
        Console.WriteLine(company);
    }
}

