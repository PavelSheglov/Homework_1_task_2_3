using System;

namespace lec_1_hw_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                double leftOperand, rightOperand, result;
                string operation;
                InputData(out leftOperand, out operation, out rightOperand);
                result = Calculate(leftOperand, operation, rightOperand);
                Console.WriteLine("({0}) {1} ({2}) = ({3:f2})", leftOperand, operation, rightOperand, result);
                Console.Write("Продолжить: Да (1), Нет (any other)...");
            } while(Console.ReadLine()=="1");
        }

        static void InputData(out double leftOperand, out string operation, out double rightOperand)
        {
            bool leftOperandIsOk, rightOperandIsOk, operationIsOk;
            do
            {
                leftOperandIsOk = false;
                rightOperandIsOk = false;
                operationIsOk = false;
                leftOperand = 0;
                rightOperand = 0;
                operation = string.Empty;
                try
                {
                    Console.Write("Введите левый операнд:");
                    leftOperand = Convert.ToDouble(Console.ReadLine());
                    leftOperandIsOk = true;
                    while (!operationIsOk)
                    {
                        Console.Write("Введите знак операции (+, -, *, /, %):");
                        operation = Console.ReadLine();
                        switch (operation)
                        {
                            case "+":
                            case "-":
                            case "*":
                            case "/":
                            case "%":
                                operationIsOk = true;
                                break;
                            default:
                                Console.WriteLine("Не существующая операция!!!");
                                break;
                        }
                    }
                    while (!rightOperandIsOk)
                    {
                        Console.Write("Введите правый операнд:");
                        rightOperand = Convert.ToDouble(Console.ReadLine());
                        if ((operation == "/" || operation == "%") && rightOperand == 0)
                            Console.WriteLine("Неверное значение правого операнда - попытка деления на ноль!!!");
                        else
                            rightOperandIsOk = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Операнд(ы) не является(ются) числом(ами)!!!!");
                }
            } while (!(leftOperandIsOk && rightOperandIsOk && operationIsOk));
        }

        static double Calculate(double leftOperand, string operation, double rightOperand)
        {
            double result=0;
            switch (operation)
            {
                case "+":
                    result = leftOperand + rightOperand;
                    break;
                case "-":
                    result = leftOperand - rightOperand;
                    break;
                case "*":
                    result = leftOperand * rightOperand;
                    break;
                case "/":
                    result = leftOperand / rightOperand;
                    break;
                case "%":
                    result = Math.IEEERemainder(leftOperand, rightOperand);
                    break;
            }
            return result;
        }
    }
}
