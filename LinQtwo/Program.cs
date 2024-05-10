using System;
namespace LinQtwo;
class Program
{
    public static void Main(string[] args)
    {
        List<string> names = new List<string> {"kalai","kani","renu","abi","sanjay","brintha"};
        var sort = names.OrderBy(name=>name.Length);
        foreach(var item in sort)
        {
            System.Console.WriteLine(item);
        }
    }
}
