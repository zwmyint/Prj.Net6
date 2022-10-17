// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using Newtonsoft.Json;
using System.Xml;
using System;

string path0 = AppDomain.CurrentDomain.BaseDirectory;
string path1 = System.Reflection.Assembly.GetExecutingAssembly().Location;
//To get the location the assembly normally resides on disk or the install directory
//string path2 = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
string path2 = System.Reflection.Assembly.GetExecutingAssembly().Location;

//once you have the path you get the directory with:
var directory = System.IO.Path.GetDirectoryName(path1);

string strSettingsFilePath = System.IO.Path.Combine(path0, "json2.json");
List<SettingData> settingdata = JsonConvert.DeserializeObject<List<SettingData>>(File.ReadAllText(strSettingsFilePath));

string strSettingsFilePath1 = System.IO.Path.Combine(path0, "json1.json");
var x = File.ReadAllText(strSettingsFilePath1);
var j = JsonConvert.DeserializeObject<SmallestDotNetThing>(x);


//
string strFilePath = System.IO.Path.Combine(path0, "json3.json");
BookRoot result = JsonConvert.DeserializeObject<BookRoot>(File.ReadAllText(strFilePath));

Console.WriteLine("There are " + result.Books.Count + " books");

foreach (var item in result.Books)
{
    Console.WriteLine("Book : {0}\t Genre : {1} \t Price : {2} \t",
                        item.Title,
                        item.Genre,
                        item.Price);
}
Console.ReadLine();

//
List<Person> source = new List<Person>();

using (StreamReader r = new StreamReader("json4.json"))
{
    string json = r.ReadToEnd();
    source = JsonConvert.DeserializeObject<List<Person>>(json);
}

List<DataReadyPerson> destination = source.Select(d => new DataReadyPerson
{
    CityOfResidence = d.City,
    fname = d.Firstname,
    lname = d.Lastname,
    DataReadPersonId = d.Id
}).ToList();

string jsonString = JsonConvert.SerializeObject(destination, Newtonsoft.Json.Formatting.Indented);

using (StreamWriter outputFile = new StreamWriter("dataReady.json"))
{
    outputFile.WriteLine(jsonString);
}
Console.ReadLine();


//


//
public class SmallestDotNetThing
{
    public string appname { get; set; }
    public List<DotNetVersion> allVersions { get; set; }
    public List<DotNetVersion> downloadableVersions { get; set; }
}

public class DotNetVersion
{
    public int major { get; set; }
    public int minor { get; set; }
    public string profile { get; set; }
    public int? servicePack { get; set; }
    public string url { get; set; }
}

//
public class SettingData
{
    public string URL { get; set; }
    public string Title { get; set; }
}


//
public class Book
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Price { get; set; }
}

public class BookRoot
{
    public List<Book> Books { set; get; }
}

//
public class Person
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string City { get; set; }
}
public class DataReadyPerson
{
    public int DataReadPersonId { get; set; }
    public string fname { get; set; }
    public string lname { get; set; }
    public string CityOfResidence { get; set; }
}

//
