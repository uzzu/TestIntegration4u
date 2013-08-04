using NUnit.Framework;


[TestFixture]
public class ExampleTest
{
    [Test]
    public void CanCombineTestsWithAndOperator()
    {
        Assert.That(41, Is.GreaterThan(40) & Is.LessThan(42));
    }
}
