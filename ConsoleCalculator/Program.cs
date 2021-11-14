using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            info();
            while (true)
            {
                Console.WriteLine("Введите первое число");
                int firstNumber = 0;
                readNumber(ref firstNumber, "Введите первое число");
                Console.WriteLine("Введите желаемую операцию");
                string operation = ""; // operation хранит в себе знак желаемой операции
                readOperation(ref operation);
                Console.WriteLine("Введите второе число");
                int secondNumber = 0;
                readNumber(ref secondNumber, "Введите второе число");
                Console.WriteLine("Результат: " + firstNumber + " " + operation + " " + secondNumber + " = " + calculate(firstNumber, secondNumber, operation));
                Console.WriteLine("");
            }
        }
        static void readNumber(ref int number, string message)
        {
            string input = Console.ReadLine();
            if (input == "!info")
                info();
            try
            {
                number = Int32.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine($"{message} или !info");
                readNumber(ref number, message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Произошёл StackOverflow, введите число поменьше.");
                Console.WriteLine($"{message} или !info");
                readNumber(ref number, message);
            }
        }

        static void readOperation(ref string str)
        {
            str = Console.ReadLine();
            if (str == "!info")
                info();
            if (!((str == "/") | (str == "+") | (str == "-") | (str == "*")))
            {
                Console.WriteLine("Введите корректный знак или !info");
                readOperation(ref str);
            }
        }

        static int calculate(int firstNumber, int secondNumber, string operation)
        {
            switch (operation)
            {
                case "-": return subtraction(firstNumber, secondNumber);
                case "+": return addition(firstNumber, secondNumber);
                case "/": return division(firstNumber, secondNumber);
                default: return multiplication(firstNumber, secondNumber); // Т.к. sign к моменту вызова метода может иметь только одно из четырёх значений (-, +, *, /), deafult подразумевает единственное не перечисленное в case значение
                    
            }
        }
        static void info()
        {
            Console.WriteLine("Добро пожаловать в консольный калькулятор!");
            Console.WriteLine("Он умеет выполнять следующие вычисления с целыми (и только целыми!) числами:\n- вычитание (-);\n-сложение (+);\n- деление (/);\n- умножение (*).");
            Console.WriteLine("Алгоритм работы: сначала пользователь вводит первое число, затем вводит желаемую операцию, а после второе число, после чего калькулятор выведет ответ.");
            Console.WriteLine("");
        }

        static int multiplication(int a, int b)
        {
            if ((int.MinValue <= a * b) | (a * b <= int.MaxValue))
                Console.WriteLine("Результат умножения вышел за пределы int, ответ будет некорректным");
            return a * b;
        }

        static int division(int a, int b)
        {
            return a / b;
        }
        static int addition(int a, int b)
        {
            return a * b;
        }
        static int subtraction(int a, int b)
        {
            return a - b;
        }
    }
}