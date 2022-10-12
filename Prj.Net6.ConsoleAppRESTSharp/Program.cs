// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;

//
//string userName = "user";
//string password = "pass";

var url = "https://reqres.in/api/users?page=2";
var client = new RestClient(url);

//
//client.Authenticator = new HttpBasicAuthenticator(userName, password);

var request = new RestRequest(url, Method.Get);
RestResponse response = await client.ExecuteAsync(request);

if (response.IsSuccessful)
{
    //Logic for handling unsuccessful response

    var Output = response.Content;
    //var objList = JsonSerializer.Deserialize<ObjList>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    //var objDetails = JsonSerializer.Deserialize<ObjDetails>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    Console.WriteLine(Output.ToString());
}

Console.WriteLine("--------------------------------------");
Console.ReadKey();

//
var url2 = "https://reqres.in/api/users";

var request2 = new RestRequest(url2, Method.Post);
request2.AddHeader("Content-Type", "application/json");
var body = new
{
    name = "Ajay Kumar",
    job = "Developer"
};
var bodyy = JsonConvert.SerializeObject(body);
request2.AddBody(bodyy, "application/json");
RestResponse response2 = await client.ExecuteAsync(request);

if(response.IsSuccessful)
{
    //Logic for handling unsuccessful response

    var output2 = response.Content;
    Console.WriteLine(output2.ToString());
    
}

Console.ReadKey();

//