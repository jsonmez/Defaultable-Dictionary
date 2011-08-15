using System;
using System.Collections.Generic;
using System.Linq;
using DefaultableDictionary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DefaultableDictionaryTest
{
    [TestClass]
    public class DefaultableDictionaryTest
    {
        [TestMethod]
        public void when_creating_a_dictionary_with_a_default_value_it_returns_the_default_value()
        {
            var dictionary = new DefaultableDictionary<string, string>(new Dictionary<string, string>(), "default");
            var value = dictionary["test"];

            Assert.AreEqual("default", value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void when_trying_to_retrieve_an_entry_with_a_null_key_the_implementation_throws()
        {
            var dictionary = new DefaultableDictionary<string, string>(new Dictionary<string, string>(), "default");

            var value = dictionary[null];
        }

        [TestMethod]
        public void when_creating_a_dictionary_with_an_extension_method_it_returns_the_default_value()
        {
            var dictionary = new Dictionary<string, int>().WithDefaultValue(5);
            var value = dictionary["test"];

            Assert.AreEqual(5, value);
        }

        [TestMethod]
        public void when_getting_all_the_values_from_the_dictionary_the_default_is_included()
        {
            var dictionary = new Dictionary<int, Func<string, string>>()
                                 {
                                     {1, s => s}
                                 }.WithDefaultValue(s => new string(s.Reverse().ToArray()));

            Assert.AreEqual(2, dictionary.Values.Count);
            Assert.AreEqual("ploof", dictionary.Values.Last()("foolp"));

        }
    }
}
