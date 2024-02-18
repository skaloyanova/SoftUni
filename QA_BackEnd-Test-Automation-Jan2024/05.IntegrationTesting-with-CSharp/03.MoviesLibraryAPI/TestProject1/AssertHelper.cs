using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibraryAPI.XUnitTests
{
    public static class AssertHelper
    {
        public static void AssertPropertiesEqual<T>(T expected, T actual)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var expectedValue = property.GetValue(expected, null);
                var actualValue = property.GetValue(actual, null);
                Assert.Equal(expectedValue, actualValue);
            }
        }
    }
}