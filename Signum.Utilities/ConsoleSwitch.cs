﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signum.Utilities.DataStructures;
using Signum.Utilities.Reflection;
using System.ComponentModel;

namespace Signum.Utilities
{
    public class ConsoleSwitch<K, V> : IEnumerable<KeyValuePair<string, WithDescription<V>>> where V : class
    {
        Dictionary<string, WithDescription<V>> dictionary = new Dictionary<string, WithDescription<V>>(StringComparer.InvariantCultureIgnoreCase);
        Dictionary<int, string> separators = new Dictionary<int, string>();
        string welcomeMessage;

        public ConsoleSwitch()
            : this(ConsoleMessage.SelectOneOfTheFollowingOptions.NiceToString())
        {
        }

        public ConsoleSwitch(string welcomeMessage)
        {
            this.welcomeMessage = welcomeMessage;
        }

        //Separator
        public void Add(string value)
        {
            separators.AddOrThrow(dictionary.Keys.Count, value, "Already a separator on {0}");
        }

        public void Add(K key, V value)
        {
            dictionary.AddOrThrow(key.ToString(), new WithDescription<V>(value), "Key {0} already in ConsoleSwitch");
        }

        public void Add(K key, V value, string description)
        {
            dictionary.AddOrThrow(key.ToString(), new WithDescription<V>(value, description), "Key {0} already in ConsoleSwitch");
        }

        public V Choose()
        {
            return Choose(ConsoleMessage.EnterYourSelection.NiceToString());
        }

        public V Choose(string endMessage)
        {
            var tuple = ChooseTuple(endMessage);

            if (tuple == null)
                return null;

            return tuple.Value;
        }

        public WithDescription<V> ChooseTuple()
        {
            return ChooseTuple(ConsoleMessage.EnterYourSelection.NiceToString());
        }

        public WithDescription<V> ChooseTuple(string endMessage)
        {
        retry:
            try
            {
                Console.WriteLine(welcomeMessage);
                PrintOptions();

                Console.WriteLine(endMessage);
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                    return null;

                Console.WriteLine();

                return GetValue(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto retry;
            }
        }

        private void PrintOptions()
        {
            var keys = dictionary.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];

                string value = separators.TryGetC(i);
                if (value.HasText())
                {
                    Console.WriteLine();
                    Console.WriteLine(value);
                }

                SafeConsole.WriteColor(ConsoleColor.White, " " + keys[i]);
                Console.WriteLine(" - " + dictionary[key].Description);
            }
        }

        public V[] ChooseMultiple()
        {
            return ChooseMultiple(ConsoleMessage.EnterYoutSelectionsSeparatedByComma.NiceToString());
        }


        public V[] ChooseMultiple(string endMessage)
        {
            var array = ChooseMultipleWithDescription(endMessage);

            if (array == null)
                return null;

            return array.Select(a => a.Value).ToArray();

        }

        public WithDescription<V>[] ChooseMultipleWithDescription()
        {
            return ChooseMultipleWithDescription(ConsoleMessage.EnterYoutSelectionsSeparatedByComma.NiceToString());
        }

        public WithDescription<V>[] ChooseMultipleWithDescription(string endMessage)
        {
        retry:
            try
            {
                Console.WriteLine(welcomeMessage);
                PrintOptions();

                Console.WriteLine(endMessage);
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    Console.Clear();
                    return null;
                }

                Console.WriteLine();

                return line.Split(',').SelectMany(GetValuesRange).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto retry;
            }
        }

        public IEnumerable<WithDescription<V>> GetValuesRange(string line)
        {
            if (line.Contains('-'))
            {
                int? from = line.Before('-').TryCS(s => s.HasText() ? GetIndex(s) : (int?)null);
                int? to = line.After('-').TryCS(s => s.HasText() ? GetIndex(s) : (int?)null);

                if (from == null && to == null)
                    return Enumerable.Empty<WithDescription<V>>();

                if (from == null && to.HasValue)
                    return dictionary.Keys.Take(to.Value + 1).Select(s => dictionary.GetOrThrow(s));

                if (from.HasValue && to == null)
                    return dictionary.Keys.Skip(from.Value).Select(s => dictionary.GetOrThrow(s));

                return dictionary.Keys.Skip(from.Value).Take((to.Value + 1) - from.Value).Select(s => dictionary.GetOrThrow(s));
            }
            else
            {
                return new[] { GetValue(line) };
            }
        }

        int GetIndex(string value)
        {
            int index = dictionary.Keys.IndexOf(value);
            if (index == -1)
                throw new KeyNotFoundException(ConsoleMessage.NoOptionWithKey0Found.NiceToString().Formato(value));

            return index;
        }

        WithDescription<V> GetValue(string value)
        {
            return dictionary.GetOrThrow(value, ConsoleMessage.NoOptionWithKey0Found.NiceToString());
        }

        public IEnumerator<KeyValuePair<string, WithDescription<V>>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public enum ConsoleMessage
    {
        [Description("Enter your selection (nothing to exit): ")]
        EnterYourSelection,
        [Description("Enter your selections separated by comma or hyphen (nothing to exit): ")]
        EnterYoutSelectionsSeparatedByComma,
        [Description("No option with key {0} found")]
        NoOptionWithKey0Found,
        [Description("Select one of the following options:")]
        SelectOneOfTheFollowingOptions
    }

    public class WithDescription<T>
    {
        public T Value { get; private set; }

        public string Description { get; private set; }

        public WithDescription(T value)
            : this(value, DefaultDescription(value))
        {

        }

        public WithDescription(T value, string description)
        {
            this.Value = value;
            this.Description = description;
        }

        static string DefaultDescription(object value)
        {
            if (value is Delegate)
                return ((Delegate)value).Method.Name.SpacePascal(true);
            if (value is Enum)
                return ((Enum)value).NiceToString();
            if (value == null)
                return "[No Name]";
            return value.ToString();
        }
    }
}
