namespace Lvl2;

public class Program
{
    public static void Main()
    {
        Character hero = new Character("Hans-Peterine", 100);
        Character villain = new Character("Inge-Borg", 200);
        
        void OnHealthChanged(int newHealth)
        {
            Console.WriteLine($"[Event] Character's health changed to {newHealth}.");
        }
        
        hero.HealthChanged += OnHealthChanged;
        villain.HealthChanged += OnHealthChanged;
        
        hero.Attack(villain, 100);
        villain.Attack(hero, 50);
    }
}

