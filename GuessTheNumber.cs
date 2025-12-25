using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int attempts = 0;
            int maxAttempts = 7;
            
            Console.WriteLine("🎮 Добро пожаловать в игру 'Угадай число'");
            Console.WriteLine($"Я загадал число от 1 до 100. У тебя {maxAttempts} попыток!");            
            while (attempts < maxAttempts)
            {
                attempts++;
                Console.Write($"\nПопытка {attempts}. Введи число: ");
                
                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("❌ Пожалуйста, введи целое число!");
                    attempts--;
                    continue;
                }
                
                if (guess == secretNumber)
                {
                    Console.WriteLine($"🎉 Поздравляю! Ты угадал число {secretNumber} за {attempts} попыток!");
                    break;
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("📈 Загаданное число БОЛЬШЕ");
                }
                else
                {
                    Console.WriteLine("📉 Загаданное число МЕНЬШЕ");
                }
                
                if (attempts == maxAttempts)
                {
                    Console.WriteLine($"💥 Попытки закончились! Загаданное число было: {secretNumber}");
                }
                else
                {
                    Console.WriteLine($"Осталось попыток: {maxAttempts - attempts}");
                }
            }
            
            Console.WriteLine("\nСпасибо за игру! Нажми любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
