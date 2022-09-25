// See https://aka.ms/new-console-template for more information
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