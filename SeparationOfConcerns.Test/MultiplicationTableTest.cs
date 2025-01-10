namespace SeparationOfConcerns.Test;

public class MultiplicationTableTest
{
    [Fact]
    public void Test()
    {
        
    }
    
    [Fact]
    public void Test_BiggestValue()
    {
        var numbers = new List<int> { 3, 7, 2, 10, 5 };

        var result = MultiplicationTable.findBiggestValue(numbers);

        Assert.Equal(10, result);
    }
}