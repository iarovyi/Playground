namespace Tasks.Specs
{
    using System.Diagnostics;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContactsSpecs
    {
        [TestMethod]
        public void Can_find_contacts()
        {
            var contacts = new Contacts();
            contacts.AddContact("hack");
            contacts.AddContact("hackerrank");

            var res1 = contacts.CountContactsThatStartsWith("hac");
            res1.Should().Be(2);

            var res2 = contacts.CountContactsThatStartsWith("hak");
            res2.Should().Be(0);
        }

        [TestMethod]
        public void Can_find_contacts_in_big_set()
        {
            var contacts = new Contacts();
            int lineNumber = 0;
            var input = EmbeddedResources.GetLines("contacts.txt");
            var results = EmbeddedResources.GetLines("contacts_results.txt");
            using (var resultsEnumerator = results.GetEnumerator())
            {
                foreach (string line in input)
                {
                    lineNumber++;
                    if (int.TryParse(line, out _))
                    {
                        Debug.WriteLine("Skipped first line");
                    } else if (line.StartsWith("add"))
                    {
                        string name = line.Split(' ')[1];
                        contacts.AddContact(name);
                    }
                    else
                    {
                        string searchPrefix = line.Split(' ')[1];
                        resultsEnumerator.MoveNext();
                        string expected = resultsEnumerator.Current;
                        int expectedCount = int.Parse(expected);

                        int count = contacts.CountContactsThatStartsWith(searchPrefix);
                        Debug.WriteLine($"Expected {count} to be {expectedCount}");
                        count.Should().Be(expectedCount);
                    }
                }

                while (resultsEnumerator.MoveNext())
                {
                    Debug.WriteLine($"Extra expected result {resultsEnumerator.Current}");
                    false.Should().Be(true, "File with answers has more expected results than input data");
                }
            }

            Debug.WriteLine($"Completed {lineNumber} numbers");
        }
    }
}
