using Bunit;
using Microsoft.Extensions.DependencyInjection;
using ReadingList.Web.Components.Layout;

namespace ReadingList.Web.Tests;

public sealed class MainLayoutTests
{
    private static readonly DateTimeOffset FixedNow = new(2030, 6, 15, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void Render_FixedTimeProvider_FooterShowsFixedYear()
    {
        using var ctx = new BunitContext();
        ctx.Services.AddSingleton<TimeProvider>(new FixedTimeProvider(FixedNow));

        var cut = ctx.Render<MainLayout>(parameters => parameters
            .Add(layout => layout.Body, "<p>content</p>"));

        Assert.Equal("Reading List \u00a9 2030", cut.Find("footer").TextContent.Trim());
    }
}
