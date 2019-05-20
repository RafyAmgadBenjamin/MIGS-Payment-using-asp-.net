using System.Reflection;
using System;
public class Child
{
    public string Nationality { get; set; }
    public string WifeName { get; set; }
}
public class Person
{
    public Child Person1 { get; set; }
    public Child Person2 { get; set; }
}
public static class AppSetting
{
    public static Person PersonInfo
    {
        get
        {
            return new Person()
            {
                Person1 = new Child()
                {
                    Nationality = "Egypt1",
                    WifeName = "Merna1"
                },
                Person2 = new Child()
                {
                    Nationality = "Egypt2",
                    WifeName = "Merna2"
                },
            };
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {

        Child mina = new Child();
        Type type = typeof(Person);
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            AppSetting.PersonInfo.GetType().GetProperty(property.Name);
            if (AppSetting.PersonInfo.GetType().GetProperty(property.Name).GetType().GetProperty(mina.WifeName).ToString() == "WifeName")
            {
                Console.WriteLine("found");
            }

        }


    }
}