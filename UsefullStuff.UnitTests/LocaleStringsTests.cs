using System;
using NUnit.Framework;
using UsefulStuff;

namespace UsefullStuff.UnitTests
{
    [TestFixture]
    public class LocaleStringsTests
    {
        [Test]
        public void YesNo()
        {
            Assert.That(LocaleStrings.Yes, Is.EqualTo("Yes"));
            Assert.That(LocaleStrings.No, Is.EqualTo("No"));
        }

        [Test]
        public void Dump()
        {

            for (uint i = 0; i < 10000; i++)
            {
                var load = LocaleStrings.Load(i);
                if(!string.IsNullOrEmpty(load))
                    Console.WriteLine($"{load} = {i},");
            }
        }

    }
}