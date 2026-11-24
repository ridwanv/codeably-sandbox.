namespace Sandbox.Core.Tests;

public sealed class SlugTests
{
    [Theory]
    [InlineData("Hello World", "hello-world")]
    [InlineData("  Leading and trailing  ", "leading-and-trailing")]
    [InlineData("Crème Brûlée", "creme-brulee")]
    [InlineData("C# 14 & .NET 10!", "c-14-net-10")]
    [InlineData("", "")]
    public void From_ProducesExpectedSlug(string input, string expected) =>
        Assert.Equal(expected, Slug.From(input));

    [Fact]
    public void From_Null_Throws() =>
        Assert.Throws<ArgumentNullException>(() => Slug.From(null!));
}
