using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UsefulStuff;

namespace UsefullStuff.UnitTests
{
    [TestFixture]
    public class StringConversionTests
    {
        [TestCase("True")]
        [TestCase("true")]
        [TestCase("tRuE")]
        [TestCase("t")]
        [TestCase("T")]
        [TestCase("Yes")]
        [TestCase("yes")]
        [TestCase("yEs")]
        [TestCase("Y")]
        [TestCase("y")]
        [TestCase("1")]
        public void ShouldHandleTrueCases(string value)
        {
            Assert.True(value.ToBool(), value);
        }
    }
}
