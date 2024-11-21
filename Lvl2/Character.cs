namespace Lvl2;

public class Character
{
    public string Name { get; set; } 
    public int Health { get; set; }
    public delegate void CharacterAction(Character target, int amount);
    public event Action<int> HealthChanged; 
    
    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    //---------------------is it supposed to be nested???
    public void Attack(Character target, int damage)
    {
        CharacterAction attack = (target, damage) =>
        {
            target.Health -= damage;
            Console.WriteLine($"{this.Name} attacks {target.Name} for {damage} damage");
            target.HealthChanged?.Invoke(target.Health);
        };
        attack(target, damage);
    }
}

// public class EventHandler
// {
//     public void SubscribeToEvents(Character character)
//     {
//         character.HealthChanged += OnHealthChanged;
//     }
//
//     public void OnHealthChanged(Character target, int damage)
//     {
//         target.Health -= damage;
//         Console.WriteLine($"{target.Name}'s health changed from {target.Health + damage} HP to {target.Health} HP");
//     }
// }

//maybe another class for character interaction so Main() can be free?
//class that includes combat turn? handle subscription there?
//class for character creation and auto subscription???

//class to initialize characters?