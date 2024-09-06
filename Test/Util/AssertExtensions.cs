using Xunit;

namespace Test.Util
{
    public static class AssertExtensions
    {
        public static void NotNullOrEmpty<T>(IEnumerable<T> collection)
        {
            Assert.NotNull(collection);
            Assert.NotEmpty(collection);
        }
    }
}
