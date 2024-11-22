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