namespace CalculatorProject;

public class ConsoleInterface
{
    private Calculator calc;
    private float num1, num2;
    public ConsoleInterface()
    {
        Console.WriteLine("\t Calculator Application");
        calc = new Calculator();
    }
    
    //application entry point
    public void Start()
    {
        bool flagToExit = true;
        //A while loop to allow the The program to keep running until the user chooses to end it.
        while (flagToExit)
        {
            float? result = selectFromOptions();
            if (result != null)
            {
                Console.WriteLine($"Result: {result}");
            }
            
        }
    }
    public float? selectFromOptions()
    {
        Console.WriteLine("Select an operation from the list below . ");
        Console.WriteLine("1. Addition \t 2. Subtraction \t 3. Multiplication" );
        Console.WriteLine("4. Division \t 5.Power \t\t 6.Modulus");
        Console.WriteLine("7. Square Root ");
        
        string inputOperation;
        int inputOperationIndex=0;
        try
        {
            inputOperation = Console.ReadLine()!;
            inputOperationIndex = int.TryParse(inputOperation, out int operationIndex) ? operationIndex : -1;
            
            // check option index is within bounds
            bool flagOperationIndex=ValidateOperationIndex(inputOperationIndex);
            if (!flagOperationIndex )
            {
               throw new Exception();
            }
            
        }
        catch (Exception e)
        {
            return null;

        }
        

        float ? result=null;
        result = 0;
        switch (inputOperationIndex)
        {
                
            case 1: 
                result = PerformOperation(num1,num2,calc.Add);
                break;
                
            case 2:
                result=PerformOperation(num1,num2,calc.Subtract);
                break;
            case 3:
                result=PerformOperation(num1,num2,calc.Multiply);
                break;
            case 4:
                result=PerformOperation(num1,num2,calc.Divide);
                break;
            case 5:
                result = PerformOperation(num1, num2, calc.Power);
                break;
            case 6:
                result = PerformOperation(num1, num2, calc.Modulus);
                break;
            case 7:
                result = PerformOperation(num1, calc.SquareRoot);
                break;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
        
        return result ;
    }

    private bool ValidateOperationIndex(int inputOperationIndex)
    {
        try
        {
            if (inputOperationIndex is <= 6 and >= 1)
            {
                Console.WriteLine("Enter two numbers separated by a space:");
                string[] numbers = Console.ReadLine()!.Split(' ');
                num1 = float.Parse(numbers[0]);
                num2 = float.Parse(numbers[1]);
            }
            else if (inputOperationIndex is > 6 and <= 7)
            {
                Console.WriteLine("Enter one number then hit enter button:");
                string numberRead = Console.ReadLine()!;
                num1 = float.Parse(numberRead);
            }
        }
        catch (IndexOutOfRangeException e)
        {

            Console.WriteLine("Input is missing , try entering two numbers separated by a space.");
            return false;
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid input. Try again.");
            return false;
        }
        return true;
       
        
    }

    public delegate float BinaryOperation(float num1, float num2);
    public delegate float UnaryOperation(float num1);

    public float PerformOperation(float num1, float num2,BinaryOperation op )
    {
        return op(num1, num2);
    }
    public float PerformOperation(float num1,UnaryOperation op )
    {
        return op(num1);
    }
    
}