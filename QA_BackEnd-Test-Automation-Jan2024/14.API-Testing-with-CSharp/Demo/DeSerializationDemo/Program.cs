using Demo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

/*************
 * SERIALIZE *
 *************/

//create c# objects
WeatherForecast weatherForecast1 = new WeatherForecast();
weatherForecast1.DateCreated = DateTime.Now;
weatherForecast1.TemperatureC = 13;
weatherForecast1.Summary = $"Summary 1";

Console.WriteLine($">>> C# object1:");
Console.WriteLine(GetAllObjectPropertiesAsString(weatherForecast1));


WeatherForecast weatherForecast2 = new WeatherForecast();
weatherForecast2.DateCreated = DateTime.Now.AddDays(1);
weatherForecast2.TemperatureC = 15;
weatherForecast2.Summary = $"Summary 2";

Console.WriteLine($"\n>>> C# object2:");
Console.WriteLine(GetAllObjectPropertiesAsString(weatherForecast2));


//serialize the object to JSON using System.Text.Json
string weatherForcastJson1 = System.Text.Json.JsonSerializer.Serialize(weatherForecast1);

Console.WriteLine("\n>>> Serialize, using System.Text.Json");
Console.WriteLine(weatherForcastJson1);

//using System.Text.Json -> JsonSerializerOptions
string weatherForcastJson11 = System.Text.Json.JsonSerializer.Serialize(weatherForecast1, new JsonSerializerOptions { WriteIndented = true });

Console.WriteLine("\n>>> Serialize, using System.Text.Json -> formatted");
Console.WriteLine(weatherForcastJson11);

//serialize the object to JSON using Newtonsoft.Json
string weatherForcastJson2 = JsonConvert.SerializeObject(weatherForecast1);

Console.WriteLine("\n>>> Serialize, using Newtonsoft.Json");
Console.WriteLine(weatherForcastJson2);

//using Newtonsoft.Json -> Formatting.Indented

List<WeatherForecast> forecasts = new List<WeatherForecast>()
{
    weatherForecast1,
    weatherForecast2
};


string forcastsJson = JsonConvert.SerializeObject(forecasts, Formatting.Indented);

Console.WriteLine("\n>>> Serialize list of objects, using Newtonsoft.Json -> formatted");
Console.WriteLine(forcastsJson);



/***************
 * DESERIALIZE *
 ***************/

// read file "People.json" located 3 levels up from current dir, i.e. in the project's root dir
string filePath = @"..\..\..\People.json";
string jsonPeopleString = File.ReadAllText(filePath);

Console.WriteLine("\n>>> JSON file:");
Console.WriteLine(jsonPeopleString);

// deserialize using System.Text.Json
var objectPeople1 = System.Text.Json.JsonSerializer.Deserialize<List<People>>(jsonPeopleString);
Console.WriteLine("\n>>> Deserialized JSON array to list of 2 objects <System.Text.Json>:");
Console.WriteLine(GetAllObjectsInAListAsString<People>(objectPeople1));

// deserialize using Newtonsoft.Json
var objectPeople2 = JsonConvert.DeserializeObject<List<People>>(jsonPeopleString);

Console.WriteLine("\n>>> Deserialized JSON array to list of 2 objects <Newtonsoft.Json>:");
Console.WriteLine(GetAllObjectsInAListAsString<People>(objectPeople2));

// Deserialize anonymous types
var jsonString = @"{'firstName': 'Ali',
                    'lastName': 'Baba',
                    'jobTitle': 'Robber'}";

var anonObjTemplate = new
{
    FirstName = string.Empty,
    LastName = string.Empty,
    JobTitle = string.Empty
};

var objectAnonymous = JsonConvert.DeserializeAnonymousType(jsonString, anonObjTemplate);
Console.WriteLine("\n>>> Deserialized JSON to Anonymous type object <Newtonsoft.Json>:");
Console.WriteLine(GetAllObjectPropertiesAsString(objectAnonymous));


/******************************************************
 * DEMO with ATTRIBUTES -> JsonProperty(), JsonIgnore *
 ******************************************************/

//c# object to serialize
User user = new User()
{
    Username = "secretUser",
    Password = "123456",
};

//serialize - parse 'Username' to 'user' and skip password
string jsonUser = JsonConvert.SerializeObject(user);
Console.WriteLine("\n>>> serialize - parse 'Username' to 'user' and skip password and age");
Console.WriteLine("C# obj:\t" + GetAllObjectPropertiesAsString(user));
Console.WriteLine("json string:\t" + jsonUser);

//deserialize
string jsonUserString = @"{'user': 'alabala', 'password': 'pass', 'age': 5}";

User objectUser = JsonConvert.DeserializeObject<User>(jsonUserString);
Console.WriteLine("\n>>> deserialize json");
Console.WriteLine("json:\t" + jsonUserString);
Console.WriteLine("C# obj:\t" + GetAllObjectPropertiesAsString(objectUser));


/*********************
 * CONTRACT RESOLVER *
 *********************/

var person = new
{
    UserName = "secretUser",
    PassWord = "123456",
    eMail = "aaa@bbb.ccc"
};

DefaultContractResolver contractResolver = new DefaultContractResolver()
{
    NamingStrategy = new SnakeCaseNamingStrategy()
};

var jsonPersonSnakeCase = JsonConvert.SerializeObject(person, new JsonSerializerSettings()
{
    ContractResolver = contractResolver,
    Formatting = Formatting.Indented
});

Console.WriteLine("\n>>> serialize using SnakeCaseNamingStrategy()");
Console.WriteLine("C# obj: \t" + GetAllObjectPropertiesAsString(person));
Console.WriteLine("json SnakeCase, formatted:\n" + jsonPersonSnakeCase);


/****************
 * LINQ-to-JSON *
 ****************/

// create object from JSON string
string jsonProduct = @"{'type': 'Vegetable', products: ['Tomato', 'Cucumber']}";

JObject objProduct = JObject.Parse(jsonProduct);

Console.WriteLine("\n>>> create object from JSON string");
Console.WriteLine("json:\n" + jsonProduct);
Console.WriteLine("obj type:\n" + objProduct["type"]);
Console.WriteLine("obj products:\n" + objProduct["products"]);

// create object by reading it from file
var products = JObject.Parse(File.ReadAllText(@"..\..\..\Products.json"));

Console.WriteLine("productVariables: " + products["productVariables"]);

// LINQ query
var productsQuery = products["productVariables"]
    .Select(p => string.Format($"{p["type"]} ({string.Join(", ", p["products"])})"));

Console.WriteLine(">>>ProductsQuery via LINQ:");
foreach (JToken p in productsQuery)
{
    Console.WriteLine(p);
}



/******************
 * HELPER METHODS *
 ******************/
string GetAllObjectsInAListAsString<T>(List<T> list)
{
    string output = "";

    if (list == null)
    {
        return output;
    }

    foreach (T item in list)
    {
        output += GetAllObjectPropertiesAsString(item) + Environment.NewLine;
    }

    return output;
}

string GetAllObjectPropertiesAsString<T>(T obj)
{
    string output = "";
    var properties = typeof(T).GetProperties();

    foreach (var property in properties)
    {
        output += $"|{property.Name}: {property.GetValue(obj)}\t";
    }

    return output;
}