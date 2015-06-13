using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BooksAutomation.Utilities;

namespace BooksAutomation.Tests
{
    [TestClass]
    public class BaseTest
    {
        public static TestFixture fixture;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            fixture = new TestFixture();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanUp()
        {
            fixture.Dispose();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            fixture.Pages.booksPage.ConfirmationResult();
            fixture.Pages.loginPage.Logoff();
        }
    }
}
