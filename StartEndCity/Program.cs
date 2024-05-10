using System;
using System.Linq;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Claims;
namespace StartEndCity;
class Program
{
    public static void Main(string[] args)
    {
        string[] city = new string[]{"Madurai", "Andra", "Cuddalore","Velore","Mumbai"};
        

        char start = 'M';
        char end = 'i';
        var searchCity = city.Where(cities=> cities.StartsWith(start.ToString()) && cities.EndsWith(end.ToString()));
        if(searchCity.Any())
        {
            System.Console.WriteLine($"The city with starts with {start} and ends with {end} is {string.Join(",",searchCity)}");
        }
        else
        {
            System.Console.WriteLine($"No City starts with {start} and end with {end}");
        }
    }
}