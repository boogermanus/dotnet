using Moq;
using MoqItDemo.Interfaces;
using MoqItDemo.Services;

namespace MoqItTests;

public class MoqServiceTests : IDisposable
{
    private IMoqService _moqService;
    private Mock<IMoqService> _mock;
    private IMoqService _mockService;
    
    public MoqServiceTests()
    {
        _moqService = new MoqService();
        _mock = new Mock<IMoqService>();
        _mockService = _mock.Object;
    }
    
    public void Dispose()
    {
        _moqService = null;
        _mock = null;
    }

    [Fact]
    public void IncrementCountIncrementsCountByOne()
    {
        _moqService.IncrementCount();
        Assert.Equal(1, _moqService.GetCount());
    }

    [Fact]
    public void IncrementCountMockIncrementsCountByOne()
    {
        _mock.Setup(fs => fs.GetCount()).Returns(1);
        Assert.Equal(1, _mockService.GetCount());
    }

    [Fact]
    public void IncrementCountMockOverrides()
    {
        _mock.Setup(fs => fs.GetCount()).Returns(1);
        Assert.Equal(1, _mockService.GetCount());
        _mock.Setup(fs => fs.GetCount()).Returns(2);
        Assert.NotEqual(1, _mockService.GetCount());
    }

    [Fact]
    public void GetCountWithOptionAnyReturnsZero()
    {
        _mock.Setup(fs => fs.GetCount(It.IsAny<string>())).Returns(0);
        Assert.Equal(0, _mockService.GetCount("test"));
    }

    [Fact]
    public void GetCountWithZeroReturnsOne()
    {
        _mock.Setup(fs => fs.GetCount("zero")).Returns(1);
        Assert.Equal(1, _mockService.GetCount("zero"));
    }

    [Fact]
    public void GetCountMockThrows()
    {
        _mock.Setup(fs => fs.GetCount()).Throws<Exception>();
        Assert.Throws<Exception>(() => _mockService.GetCount());
    }
}