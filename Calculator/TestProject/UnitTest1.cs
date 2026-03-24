namespace TestProject;
using CalculatorProject;
public class Tests
{
    private Calculator calc;
    [SetUp]
    public void Setup()
    {
        calc = new Calculator();
    }

    [Test]
    public void Add2numbers_OnResultCorrect_ReturnsTrue()
    {
        //arange
        float expected,num1 = 1, num2 = 4;
        expected = 5;
        
        //act
        float result=calc.Add(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Subtract2numbers_OnResultCorrect_ReturnsTrue()
    {
        //arange
        float expected,num1 = 10, num2 = 20;
        expected = -10;
        
        //act
        float result=calc.Subtract(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    
}