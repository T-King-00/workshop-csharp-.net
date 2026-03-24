namespace CalculatorProject;


//Application logic :: calculator operations
public class CalculatorOperations
{
    public float Add(float a, float b) => a + b;  
    public float Subtract(float a, float b) => a - b;
    public float Multiply(float a, float b) => a * b;
    public float Divide(float a, float b) => a / b;
    public float Power(float a, float b) => (float)Math.Pow(a, b);
    public float Modulus(float a, float b) => a % b;
    public float SquareRoot(float a) => (float)Math.Sqrt(a);

    
}