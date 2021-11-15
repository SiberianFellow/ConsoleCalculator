using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            showInfo();
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
                calculate(firstNumber, secondNumber, operation);
            }
        }
        static void readNumber(ref int number, string message)
        {
            string input = Console.ReadLine();
            if (input == "!info")
                showInfo();
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
                Console.WriteLine("Произошёл StackOverflow, введите число из диапазона int32.");
                Console.WriteLine($"{message} или !info");
                readNumber(ref number, message);
            }
        }

        static void readOperation(ref string str)
        {
            str = Console.ReadLine();
            if (str == "!info")
                showInfo();
            if (!((str == "/") | (str == "+") | (str == "-") | (str == "*")))
            {
                Console.WriteLine("Введите корректный знак или !info");
                readOperation(ref str);
            }
        }

        static void calculate(int firstNumber, int secondNumber, string operation)
        {
            switch (operation)
            {
                case "-":
                    {
                        Console.WriteLine("ABOBA");
                        subtraction(firstNumber, secondNumber);
                        break;
                    }
                case "+":  
                    {
                        addition(firstNumber, secondNumber);
                        break;
                    }
                case "/":
                    {
                        division(firstNumber, secondNumber);
                        break;
                    }
                default:
                    {
                        multiplication(firstNumber, secondNumber); // Т.к. sign к моменту вызова метода может иметь только одно из четырёх значений (-, +, *, /), deafult подразумевает единственное не перечисленное в case значение
                        break;
                    }
            }

        }
        static void showInfo()
        {
            Console.WriteLine("Добро пожаловать в консольный калькулятор!");
            Console.WriteLine("Он умеет выполнять следующие вычисления с целыми (и только целыми!) числами:\n- вычитание (-);\n-сложение (+);\n- деление (/);\n- умножение (*).");
            Console.WriteLine("Алгоритм работы: сначала пользователь вводит первое число, затем вводит желаемую операцию, а после второе число, после чего калькулятор выведет ответ.");
            Console.WriteLine("");
        }

        static void multiplication(int a, int b)
        {
            long result = (long)a * (long)b;
            Console.WriteLine("Результат: " + a + " * " + b + " = " + result);
            Console.WriteLine("");
        }

        static void division(int a, int b)
        {
            try
            {
                int result = a / b;
                Console.WriteLine("Результат: " + a + " / " + b + " = " + result);
                Console.WriteLine("");
        }
            catch (Exception)
            {
                Console.WriteLine("Деление на ноль. Зачем?");
                Console.WriteLine("");
            }
}
        static void addition(int a, int b)
        {
            long result = (long)a + (long)b;
            Console.WriteLine("Результат: " + a + " + " + b + " = " + result);
            Console.WriteLine("");
        }
        static void subtraction(int a, int b)
        {
            long result = (long)a - (long)b;
            Console.WriteLine("Результат: " + a + " - " + b + " = " + result);
            Console.WriteLine("");
        }
    }
}