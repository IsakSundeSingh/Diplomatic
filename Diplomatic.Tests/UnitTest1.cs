using System.Collections.Generic;
using Xunit;

namespace Diplomatic.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            List<string> yourMom = new List<string>() { "ayy" };
            Assert.Single(yourMom);
        }
    }
}
