using System;
using System.Linq;
using System.Collections.Generic;
using ReferencingNamespaceLib;

namespace ExtensionMethods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestIsPalindrome();
            TestConvertToHex();
            TestConvertToHex2();
            TestIDataSource();
            TestIDataSourceGender();
            //TestExtension();
            TestTemplate();
        }

        private static void TestIsPalindrome()
        {
            var list = new List<string>()
            {
                "room",
                "level",
                "heat",
                "burn",
                "madam",
                "machine",
                "radar",
                "brain",
            };

            list.ForEach(s => Console.WriteLine($"{s} = {s.IsPalindrome()}"));
        }

        private static void TestConvertToHex()
        {
            int i = 0;
            string data = "Function in C#";
            byte[] moreData = data.ConvertToHex();

            foreach (char c in moreData)
                Console.WriteLine($"{c} = 0x{moreData[i]} ({moreData[i++]})");
        }

        private static void TestConvertToHex2()
        {
            int i = 0;
            string data = "Function in C#";
            byte[] moreData = data.ConvertToHex2();

            foreach (char c in moreData)
                Console.WriteLine($"{c} = 0x{moreData[i]} ({moreData[i++]})");
        }

        private static void TestIDataSource()
        {
            new JusticeLeagueMembers()
            .GetItems()
            .ToList()
            .ForEach(cm => Console.WriteLine($"Name: {cm.Name}\tGender: {cm.Gender}"));
        }

        private static void TestIDataSourceGender()
        {
            new JusticeLeagueMembers()
            .GetItemsByGender("Female")
            .ToList()
            .ForEach(f => Console.WriteLine($"Name: {f.Name}\tGender: {f.Gender}"));
        }

        private static void TestExtension()
        {
            new JusticeLeagueMembers()
            .GetItems()
            .GetItemsByGenderEnum("Male")
            .ToList()
            .ForEach(i => Console.WriteLine($"Name: {i.Name}\tGender: {i.Gender}"));

        }
        private static void TestTemplate()
        {
            new List<IDataSource>
            {
                new JusticeLeagueMembers(),
                new AvengersMembers()
            }
            .GetItemsByGenderTemplate("Female")
            .ToList()
            .ForEach(i => Console.WriteLine($"Name: {i.Name}\tGender: {i.Gender}"));
        }
    }
}

public static class StringExtensionMethods
{
    public static bool IsPalindrome(this string pStr)
    {
        return pStr.Reverse().Equals(pStr);
    }

    public static string Reverse(this string pString)
    {
        var array = pString.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}

public class DataItem
{
    public DataItem(string pName, string pGender)
    {
        Name = pName;
        Gender = pGender;
    }
    public string Name { get; set; }
    public string Gender { get; set; }
}

public interface IDataSource
{
    IEnumerable<DataItem> GetItems();
}

public class JusticeLeagueMembers : IDataSource
{
    List<DataItem> DataItems = new List<DataItem>
        {
            new DataItem("Barry Allen", "Male"),
            new DataItem("Bruce Wayne", "Male"),
            new DataItem("Diana Prince", "Female"),
            new DataItem("Clark Kent", "Male"),
            new DataItem("Sue Dinby ", "Female"),
            new DataItem("Zatanna Zatara", "Female")
        };

    public IEnumerable<DataItem> GetItems()
    {
        foreach (var item in DataItems)
        {
            yield return item;
        }
    }
}

public class AvengersMembers : IDataSource
{

    List<DataItem> DataItems = new List<DataItem>
    {
        new DataItem("Tony Stark", "Male"),
        new DataItem("Janet van Dyne", "Female"),
        new DataItem("Thor Odinson", "Male"),
        new DataItem("Natasha Romanoff", "Female"),
        new DataItem("Patsy Walker", "Female"),
        new DataItem("T'Challa", "Male")
    };

    public IEnumerable<DataItem> GetItems()
    {
        foreach (var item in DataItems)
        {
            yield return item;
        }
    }
}

public static class IDataSourceExtension
{
    public static IEnumerable<DataItem> GetItemsByGender(
        this IDataSource pSrc,
        string pGender
    ) => pSrc.GetItems().Where(i => i.Gender.Equals(pGender));
}

public static class ICollectionExtension
{

    public static IEnumerable<DataItem> GetItemsByGenderEnum(this IEnumerable<DataItem> pSrc, 
        string pGender)
    {
        var items = new List<DataItem>();
        pSrc.ToList().ForEach(s =>
        {
            var dataSource = s as IDataSource;
            if (s != null)
                items.AddRange(dataSource.GetItemsByGender(pGender));
        });

        return items;
    }

    public static IEnumerable<DataItem> GetItemsByGenderTemplate(
        this IEnumerable<IDataSource> pSrc, 
        string pGender)
    {
        return pSrc.SelectMany(x => x.GetItemsByGender(pGender));
    }
}
#region Override System Namespace
namespace System
{
    public static class ExtensionMethodsClass
    {
        public static byte[] ConvertToHex2(this string pStr)
        {
            int i = 0;
            byte[] hexArray = new byte[pStr.Length];

            foreach (char c in pStr)
                hexArray[i++] = Convert.ToByte(c);

            return hexArray;

        }
    }
}
#endregion