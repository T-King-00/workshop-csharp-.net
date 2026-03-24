namespace TestProject;
using CalculatorProject;
public class CalculatorTest
{
    private CalculatorOperations _calc;
    [SetUp]
    public void Setup()
    {
        _calc = new CalculatorOperations();
    }

    // Addition test cases. 
    /** case 1: given two +ve numbers
     * case 2: given one +ve and one -ve number
     * case 3: given two -ve numbers
     */
    [Test]
    public void Add_WhenBothInputsArePositive_ReturnsCorrectResult()
    {
        //arange
        float expected,num1 = 1, num2 = 4;
        expected = 5;
        
        //act
        float result=_calc.Add(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Add_WhenOneInputIsNegative_ReturnsCorrectResult()
    {
        //arange
        float expected,num1 = 5, num2 = -2;
        expected = 3;
        
        //act
        float result=_calc.Add(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Add_WhenBothInputsAreNegative_ReturnsCorrectResult()
    {
        //arange
        float expected,num1 = -5, num2 = -5;
        expected = -10;
        
        //act
        float result=_calc.Add(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    
    // Subtraction test cases. 
    /** case 1: given two +ve numbers
     * case 2: given one +ve and one -ve number
     * case 3: given two -ve numbers
     */
    [Test]
    public void Subtract_WhenBothInputsArePositive_ReturnsCorrectResult()
    {
        //arange
        float expected,num1 = 10, num2 = 20;
        expected = -10;
        
        //act
        float result=_calc.Subtract(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Subtract_WhenOneInputIsNegative_ReturnsCorrectResult()
    {
        //arange
        float expected,num1 = 5, num2 = -2;
        expected = 7;
        
        //act
        float result=_calc.Subtract(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Subtract_WhenBothInputsAreNegative_ReturnsCorrectResult()
    {
        //arange
        float expected,num1 = -5, num2 = -5;
        expected = 0;
        
        //act
        float result=_calc.Subtract(num1,num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    
    // Division test cases. 
    /** case 1: given two +ve numbers
     * case 2: given one +ve and one -ve number
     * case 3: given two -ve numbers
     * case 4: given 0 as divisor
     */
    [Test]
    public void Divide_WhenBothInputsArePositive_ReturnsCorrectResult()
    {
        //arange
        float expected, num1 = 10, num2 = 2;
        expected = 5;
        
        //act
        float result = _calc.Divide(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_WhenOneInputIsNegative_ReturnsCorrectResult()
    {
        //arange
        float expected, num1 = 10, num2 = -2;
        expected = -5;
        
        //act
        float result = _calc.Divide(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_WhenBothInputsAreNegative_ReturnsCorrectResult()
    {
        //arange
        float expected, num1 = -10, num2 = -2;
        expected = 5;
        
        //act
        float result = _calc.Divide(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Divide_WhenDivisorIsZero_ReturnsInfinity()
    {
        //arange
        float expected, num1 = 10, num2 = 0;
        expected = float.PositiveInfinity;
        
        //act
        float result = _calc.Divide(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Multiplication test cases.
    /** case 1: given two +ve numbers
     * case 2: given one +ve and one -ve number
     */
    [Test]
    public void Multiply_WhenBothInputsArePositive_ReturnsCorrectResult()
    {
        //arange
        float expected, num1 = 5, num2 = 4;
        expected = 20;
        
        //act
        float result = _calc.Multiply(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Multiply_WhenOneInputIsNegative_ReturnsCorrectResult()
    {
        //arange
        float expected, num1 = 5, num2 = -4;
        expected = -20;
        
        //act
        float result = _calc.Multiply(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Power test cases.
    /** case 1: given +ve base and exponent
     * case 2: given exponent is zero
     */
    [Test]
    public void Power_WhenPositiveBaseAndExponent_ReturnsCorrectResult()
    {
        //arange
        float expected, num1 = 2, num2 = 3;
        expected = 8;
        
        //act
        float result = _calc.Power(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Power_WhenExponentIsZero_ReturnsOne()
    {
        //arange
        float expected, num1 = 5, num2 = 0;
        expected = 1;
        
        //act
        float result = _calc.Power(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // SquareRoot test cases.
    /** case 1: given +ve number
     * case 2: given -ve number
     */
    [Test]
    public void SquareRoot_WhenInputIsPositive_ReturnsCorrectResult()
    {
        //arange
        float expected, num1 = 25;
        expected = 5;
        
        //act
        float result = _calc.SquareRoot(num1);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void SquareRoot_WhenInputIsNegative_ReturnsNaN()
    {
        //arange
        float expected, num1 = -25;
        expected = float.NaN;
        
        //act
        float result = _calc.SquareRoot(num1);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // Modulus test cases.
    /** case 1: given two +ve numbers
     * case 2: given 0 as divisor
     */
    [Test]
    public void Modulus_WhenPositiveInputs_ReturnsCorrectRemainder()
    {
        //arange
        float expected, num1 = 10, num2 = 3;
        expected = 1;
        
        //act
        float result = _calc.Modulus(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Modulus_WhenDivisorIsZero_ReturnsNaN()
    {
        //arange
        float expected, num1 = 10, num2 = 0;
        expected = float.NaN;
        
        //act
        float result = _calc.Modulus(num1, num2);
        
        //assert
        Assert.That(result, Is.EqualTo(expected));
    }
}