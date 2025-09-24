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
}