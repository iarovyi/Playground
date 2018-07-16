namespace Tasks.Specs
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContactsSpecs
    {
        [TestMethod]
        public void Can_find_contacts()
        {
            Contacts.AddContact("hack");
            Contacts.AddContact("hackerrank");

            var res1 = Contacts.CountContactsThatStartsWith("hac");
            res1.Should().Be(2);

            var res2 = Contacts.CountContactsThatStartsWith("hak");
            res2.Should().Be(0);
        }
    }
}
