using System;
using System.Threading;

class SimpleRPG
{
    static Random random = new Random();
    
    static void Main()
    {
        Console.WriteLine("⚔️ Добро пожаловать в текстовую RPG!");
        
        int playerHealth = 100;
        int playerDamage = 15;
        int playerHeals = 3;
        
        int enemyHealth = 80;
        int enemyDamage = 12;
        
        Console.WriteLine($"Твое здоровье: {playerHealth} ❤️");
        Console.WriteLine($"Здоровье врага: {enemyHealth} 💀");
        
        while (playerHealth > 0 && enemyHealth > 0)
        {
            Console.WriteLine("\nВыбери действие:");
            Console.WriteLine("1. ⚔️ Атаковать");
            Console.WriteLine("2. ❤️ Лечиться (осталось: " + playerHeals + ")");
            Console.WriteLine("3. 🛡️ Защищаться");
            
            string choice = Console.ReadLine();
            
            // Ход игрока
            switch (choice)
            {
                case "1":
                    int damage = random.Next(playerDamage - 5, playerDamage + 6);
                    enemyHealth -= damage;
                    Console.WriteLine($"💥 Ты нанес {damage} урона врагу!");
                    break;
                    
                case "2":
                    if (playerHeals > 0)
                    {
                        int heal = random.Next(15, 26);
                        playerHealth += heal;
                        playerHeals--;
                        Console.WriteLine($"✨ Ты восстановил {heal} здоровья!");
                    }
                    else
                    {
                        Console.WriteLine("❌ У тебя не осталось зелий!");
                    }
                    break;
                    
                case "3":
                    Console.WriteLine("🛡️ Ты приготовился к защите!");
                    break;
                    
                default:
                    Console.WriteLine("❌ Неверный выбор! Пропускаешь ход.");
                    break;
            }
            
            if (enemyHealth <= 0) break;
            
            // Ход врага
            if (choice != "3") // Если игрок не защищался
            {
                int enemyAttack = random.Next(enemyDamage - 4, enemyDamage + 5);
                playerHealth -= enemyAttack;
                Console.WriteLine($"💀 Враг нанес тебе {enemyAttack} урона!");
            }
            else
            {
                int blockedDamage = random.Next(5, 11);
                Console.WriteLine($"🛡️ Ты заблокировал {blockedDamage} урона!");
            }
            
            // Отображение статуса
            Console.WriteLine($"\nТвое здоровье: {Math.Max(0, playerHealth)} ❤️");
            Console.WriteLine($"Здоровье врага: {Math.Max(0, enemyHealth)} 💀");
            
            Thread.Sleep(1000); // Пауза для драматизма
        }
        
        // Результат битвы
        if (playerHealth > 0)
        {
            Console.WriteLine("\n🎉 ПОБЕДА! Ты победил врага!");
        }
        else
        {
            Console.WriteLine("\n💀 ПОРАЖЕНИЕ... Враг оказался сильнее.");
        }
    }
}
