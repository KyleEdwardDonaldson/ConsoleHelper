using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace KonsoleHelper.Tests
{
    public class Helpers
    {
        protected Mock<IConsole> MockConsole;
        private Random _random;

        [SetUp]
        public void SetUp()
        {
            MockConsole = new Mock<IConsole>();

            var console = typeof(Konsole).GetField("_console", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            console?.SetValue(null, MockConsole.Object);

            _random = new Random();
        }

        public int SetupLinesToPrintInOrder(string[] lines)
        {
            int callOrder = 0;

            foreach (string line in lines)
            {
                MockConsole.Setup(x => x.WriteLine(line)).Callback(() => {
                    Assert.That(line, Is.EqualTo(lines[callOrder]));
                    callOrder++;
                }).Verifiable();
            }

            return lines.Length;
        }

        public string[] GetOrAppendStrings(string[] existing, int count, bool allEmpty = false)
        {
            var listOfStrings = existing.ToList();
            for (var i = 0; i < count; i++)
            {
                listOfStrings.Add(allEmpty ? "" : GetRandomString());
            }

            return listOfStrings.ToArray();
        }

        public string[] GetOrAppendStrings(List<string> existing, int count, bool allEmpty = false)
        {
            for (var i = 0; i < count; i++)
            {
                existing.Add(allEmpty ? "" : GetRandomString());
            }

            return existing.ToArray();
        }

        public string[] GetOrAppendStrings(int count, bool allEmpty = false)
        {
            var lines = new string[count];
            for (var i = 0; i < count; i++)
            {
                lines[i] = allEmpty ? "" : GetRandomString();
            }

            return lines;
        }

        public string[] GetOrAppendStrings(string repeatedString, int count)
        {
            var lines = new string[count];
            for (var i = 0; i < count; i++)
            {
                lines[i] = repeatedString;
            }

            return lines;
        }

        public string GetRandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public int GetRandomInt(int min = 0, int max = 10000)
        {
            return _random.Next(min, max);
        }

        public object GetRandomNumberOfType(Type type)
        {
            var getRandomNumberOfTypeMethod = typeof(Helpers).GetMethod("InternalGetRandomNumberOfType");
            var methodWithType = getRandomNumberOfTypeMethod.MakeGenericMethod(typeof(T));

            return methodWithType.Invoke(new Helpers(), null); 
        }

        private T InternalGetRandomNumberOfType<T>()
        {
            var type = typeof(T);

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Int32:
                    {
                        return (T)Convert.ChangeType(_random.Next(), typeof(T));
                    }
                case TypeCode.Decimal:
                    {
                        return (T)Convert.ChangeType(_random.NextDouble(), typeof(T));
                    }
                case TypeCode.Int64:
                    {
                        return (T)Convert.ChangeType(_random.NextInt64(), typeof(T));
                    }
                case TypeCode.Single:
                    {
                        return (T)Convert.ChangeType(_random.NextSingle(), typeof(T));
                    }
                case TypeCode.Double:
                    {
                        return (T)Convert.ChangeType(_random.NextDouble(), typeof(T));
                    }
            }

            throw new ArgumentOutOfRangeException($"Type {type.Name} is not supported");
        }
    }
}
