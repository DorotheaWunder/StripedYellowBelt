namespace Lvl2;

public class Character
{
    public string Name { get; set; } 
    public int Health { get; set; }
    
    public delegate void CharacterAction(Character target, int amount);
    public event CharacterAction OnHealthChanged; //-----------------might be a regular action instead of a character one
    
    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }
    
    //------------------------------------------------ right now the characters are attacking themselves
    public void Attack(Character target, int damage)
    {
        Console.WriteLine($"{this.Name} attacks {target.Name} for {damage} damage");
        OnHealthChanged?.Invoke(target, damage); 
    }
}

//--------------------------- put the event subscription logic into a separare class to keep Main() free
public class EventHandler
{
    public void SubscribeToEvents(Character character)
    {
        character.OnHealthChanged += ProcessHealthChanged;
    }

    public void ProcessHealthChanged(Character target, int damage)
    {
        target.Health -= damage;
        Console.WriteLine($"{target.Name}'s health changed from {target.Health + damage} HP to {target.Health} HP");
    }
}


//maybe another class for character interaction so Main() can be free?
//class that includes combat turn? handle subscription there?
//class for character creation and auto subscription???