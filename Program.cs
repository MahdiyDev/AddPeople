using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace _3
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Enter Name: ");
      string name = Console.ReadLine();
      Console.Write("Enter Age: ");
      bool age = int.TryParse(Console.ReadLine(), out int parsedAge);
      if (age)
      {
        AddPeople(name, parsedAge);
      }
      else
      {
        Console.WriteLine("Invalid Age");
        return;
      }
    }

    static void AddPeople(string name, int age)
    {
      var dirname = Directory.GetCurrentDirectory();
      var filename = dirname + "\\input.json";
      var oldPerson = File.ReadAllText(filename);
      if (oldPerson.Length == 0)
      {
        List<Person> people = new List<Person>();
        people.Add(new Person { id = 0, name = name, age = age });
        string json = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
      }
      else
      {
        var people = JsonSerializer.Deserialize<List<Person>>(oldPerson);
        people.Add(new Person { id = people.Count, name = name, age = age });
        string json = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
      }
      Console.WriteLine("Person Added");
    }

    public class Person
    {
      public int id { get; set; }
      public string name { get; set; }
      public int age { get; set; }
    }
  }
}
