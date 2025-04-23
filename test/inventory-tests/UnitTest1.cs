using inventory.Features.Items;

namespace inventory_tests;

public class UnitTest1
{
    private CreateHandler _sut;

    public UnitTest1()
    {
        _sut = new CreateHandler();
    }
    
    
    [Fact]
    public void Test1()
    {
        _sut.Handle(new CreateCommand { Name = "something"}, CancellationToken.None);
    }
}