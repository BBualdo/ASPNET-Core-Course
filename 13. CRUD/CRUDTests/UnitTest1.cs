namespace CRUDTests
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      // Arrange - arranging input values and expected result
      MyMath mm = new MyMath();
      int input1 = 10, input2 = 14;
      int expected = 24;

      // Act - calling a method to test
      int actual = mm.Add(input1, input2);
      // Assert - proving, comparing expected and actual result
      Assert.Equal(expected, actual);
    }
  }
}