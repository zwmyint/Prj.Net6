// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Prj.Net6.ConsoleApp;
using System.Runtime.Serialization;

Console.WriteLine("Hello, World!");

Console.Write("Enter Radius : ");
double r = Convert.ToDouble(Console.ReadLine());
double area = GetCircleArea(r);
Console.WriteLine("Area of Circle : " + area);
Console.ReadKey();

ArrForloop();
Console.ReadKey();

ArrForeachloop();
Console.ReadKey();

//
Sumvalue class1 = new Sumvalue();
class1.Sum();
Console.ReadKey();

// ienumerable-iqueryable-icollection-dotnet
//IEnumerableLoopExample(new List<int> { 1, 2, 3, 4, 5 });
//var evenNumbers = YieldEvenNumbersExample();
//foreach (var number in evenNumbers)
//{
//    Console.WriteLine(number);
//}

//var numbers = GetNumbersFromDb();
//var evenNumbers = numbers.Where(number => number % 2 == 0)
//                         .ToList();

//foreach (var number in evenNumbers)
//{
//    Console.WriteLine(number);
//}

var numbers = new List<int> { 1, 2, 3, 5 };
ICollectionExample(numbers);
foreach (var number in numbers)
{
    Console.WriteLine(number);
}

Console.ReadKey();


//
Logger logger = new Logger();
await logger.Log("Write to log ...");

Console.ReadKey();


//
var car = new Car()
{
    Company = "Ford",
    ModelNo = "ABC123",
    WheelType = new ChromeWheel()
    {
        Material = "Rubber",
        HasChromePlating = false
    }
};

// FaultySerialization
//string serializedCar = JsonConvert.SerializeObject(car);
//Car deserializedCar = JsonConvert.DeserializeObject<Car>(serializedCar);
//Console.WriteLine(serializedCar);
//Console.WriteLine("Type of WheelType " + deserializedCar.WheelType.GetType());
//var chromeWheel = deserializedCar.WheelType as ChromeWheel;
//Console.WriteLine("HasChromePlating " + chromeWheel?.HasChromePlating);


// InsecureSerialization
//string serializedCar = JsonConvert.SerializeObject(car, new JsonSerializerSettings()
//{
//    TypeNameHandling = TypeNameHandling.All
//});

//Car deserializedCar = JsonConvert.DeserializeObject<Car>(serializedCar, new JsonSerializerSettings()
//{
//    TypeNameHandling = TypeNameHandling.Auto
//});
//Console.WriteLine(serializedCar);
//Console.WriteLine("Type of WheelType " + deserializedCar.WheelType.GetType());
//var chromeWheel = deserializedCar.WheelType as ChromeWheel;
//Console.WriteLine("HasChromePlating " + chromeWheel?.HasChromePlating);

// SecureSerialization
string serializedCar = JsonConvert.SerializeObject(car, new JsonSerializerSettings()
{
    TypeNameHandling = TypeNameHandling.All,
    SerializationBinder = new CustomSerializationBinder()
});
Car deserializedCar = JsonConvert.DeserializeObject<Car>(serializedCar, new JsonSerializerSettings()
{
    TypeNameHandling = TypeNameHandling.Auto,
    SerializationBinder = new CustomSerializationBinder()
});
Console.WriteLine(serializedCar);
Console.WriteLine("Type of WheelType " + deserializedCar.WheelType.GetType());
var chromeWheel = deserializedCar.WheelType as ChromeWheel;
Console.WriteLine("HasChromePlating " + chromeWheel?.HasChromePlating);

Console.ReadKey();


// person builder
var p = new Person
{
    FirstName = "Juldhais",
    LastName = "Hengkyawan",
    BirthDate = new DateTime(1990, 7, 3),
    Address = new Address
    {
        Line = "Jl. Dharmawangsa No. 10",
        City = "Bogor",
        Province = "Jawa Barat",
        PostCode = "16131"
    },
    Phones = new List<Phone>
    {
        new Phone
        {
            PhoneNumber = "02518334455",
            PhoneType = PhoneType.Home
        },
        new Phone
        {
            PhoneNumber = "02518334455",
            PhoneType = PhoneType.Mobile
        },
    }
};


var person = new PersonBuilder()
    .SetName("Juldhais", "Hengkyawan")
    .SetBirthDate(new DateTime(1990, 7, 3))
    .SetAddress(new Address
    {
        Line = "Jl. Dharmawangsa No. 10",
        City = "Bogor",
        Province = "Jawa Barat",
        PostCode = "16131"
    })
    .AddHomePhone("02518334455")
    .AddMobilePhone("081312345678")
    .Build();

Console.WriteLine(JsonConvert.SerializeObject(person)); //JsonSerializer.Serialize(person) //using System.Text.Json;

Console.ReadKey();


//




//////////////////////////////////////////

// Method Name --> GetCircleArea()
// Return Type ---> double
static double GetCircleArea(double radius)
{
    const float pi = 3.14F;
    double area = pi * radius * radius;
    return area;
}


static void ArrForloop()
{
    string[] array = new string[2];
    array[0] = "Java";
    array[1] = "Kotlin";

    // Use for-loop on array.
    for (int i = 0; i < array.Length; i++)
    {
        // Get element, and print index and element value.
        string element = array[i];
        Console.WriteLine("INDEX: {0}, VALUE: {1}", i, element);
    }
    Console.ReadLine();
}

static void ArrForeachloop()
{
    string[] array = new string[] { "Java", "Python", "C#", "C++", "JavaScript", "PHP" };

    foreach (string item in array)
    {
        Console.WriteLine(item);
    }
    Console.ReadLine();
}

//
//static void IEnumerableLoopExample(IEnumerable<int> numbers)
//{
//    foreach (var number in numbers)
//    {
//        if (number % 2 == 0)
//        {
//            Console.WriteLine($"{number} is even");
//        }
//    }
//}

//static IEnumerable<int> YieldEvenNumbersExample()
//{
//    for (var i = 1; i <= 5; i++)
//    {
//        if (i % 2 == 0)
//        {
//            yield return i;
//        }
//    }
//}

//static IQueryable<int> GetNumbersFromDb()
//{
//    return new[] { 1, 2, 3, 4, 5 }.AsQueryable();
//}

static void ICollectionExample(ICollection<int> numbers)
{
    numbers.Add(100);

    if (numbers.Contains(1))
    {
        numbers.Remove(1);
    }
}
//