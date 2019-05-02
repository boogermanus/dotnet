using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace FunctionalApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] buffer;

            var buffer = Disposable.Using(Utility.GeneratePlanetsStream,
            stream =>
            {
                var buff = new byte[stream.Length];
                stream.Read(buff, 0,(int)stream.Length);
                return buff;
            });

            var options =
            Encoding
            .UTF8
            .GetString(buffer)
            .Split(new[] { Environment.NewLine, },
            StringSplitOptions.RemoveEmptyEntries)
            .Select((s, ix) => Tuple.Create(ix, s))
            .ToDictionary(k => k.Item1, v => v.Item2);
            var orderedList = Utility.GenerateOrderedList(
            options, "thePlanets", true);
            Console.WriteLine(orderedList);
        }
    }
}

public static class Utility
{
    public static string GenerateOrderedList(
    Dictionary<int, string> options,
    string id,
    bool includeSun) =>
        new StringBuilder()
        .AppendFormattedLine("<ol id=\"{0}\">", id)
        .AppendWhen(() => includeSun, sb => sb.AppendLine("\t<li>The Sun</li>"))
        .AppendSequence(options,
        (sb, opt) => sb.AppendFormattedLine("\t<li value=\"{0}\">{1}</li>", opt.Key, opt.Value))
        .AppendLine("</ol>")
        .ToString();

    public static Stream GeneratePlanetsStream()
    {
        var planets =
        String.Join(
        Environment.NewLine,
        new[] {
            "Mercury", "Venus", "Earth",
            "Mars", "Jupiter", "Saturn",
            "Uranus", "Neptune"
        });

        var buffer = Encoding.UTF8.GetBytes(planets);
        var stream = new MemoryStream();
        stream.Write(buffer, 0, buffer.Length);
        stream.Position = 0L;
        return stream;
    }
}

public static partial class StringBuilderExtension
{
    public static StringBuilder AppendFormattedLine(
        this StringBuilder @this,
        string format,
        params object[] args) => @this.AppendFormat(format, args).AppendLine();

    public static StringBuilder AppendWhen(
        this StringBuilder @this,
        Func<bool> predicate,
        Func<StringBuilder, StringBuilder> fn
    ) => predicate() ? fn(@this) : @this;

    public static StringBuilder AppendSequence<T>(
        this StringBuilder @this,
        IEnumerable<T> sequence,
        Func<StringBuilder, T, StringBuilder> fn
    ) => sequence.Aggregate(@this, fn);
}

public static class Disposable
{
    public static TResult Using<TDisposable, TResult>
    (
        Func<TDisposable> factory,
        Func<TDisposable, TResult> fn
    ) where TDisposable : IDisposable
    {
        using(var disposable = factory())
        {
            return fn(disposable);
        }
    }
}