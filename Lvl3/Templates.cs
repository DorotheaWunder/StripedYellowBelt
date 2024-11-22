namespace Lvl3;

public class Templates
{
    public class AbilityContainer<T>
    {
        private List<T> abilities = new List<T>();

        public void AddAbility(T ability)
        {
            abilities.Add(ability);
        }

        public void RemoveAbility(T ability)
        {
            abilities.Remove(ability);
        }
        
        public List<T> RetrieveAbility()
        {
            return abilities;
        }
    }
    
    public interface IAbility
    {
        string Name { get; set; }
        string Effect { get; set; }
    }
    
    public class AttackAbility : IAbility
    {
        public string Name { get; set; }
        public string Effect { get; set; }

        public AttackAbility(string name, string effect)
        {
            Name = name;
            Effect = effect;
        }
    }
    
    public class HealAbility : IAbility
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        
        public HealAbility(string name, string effect)
        {
            Name = name;
            Effect = effect;
        }
    }

    public List<IAbility> CreateAbilities()
    {
        return new List<IAbility>
        {
            new AttackAbility("Attack", "Perform a physical attack on the enemy"),
            new HealAbility("Heal", "Restore health for one of your party members")
        };
    }
    
    public void AddAbilities(AbilityContainer<IAbility> abilityContainer)
    {
        var abilities = CreateAbilities();
        foreach (var ability in abilities)
        {
            abilityContainer.AddAbility(ability);
        }
    }
    
    public void DisplayAbilities(AbilityContainer<IAbility> abilityContainer)
    {
        var abilities = abilityContainer.RetrieveAbility();

        foreach (var ability in abilities)
        {
            Console.WriteLine($"{ability.Name}: {ability.Effect}");
        }
    }
}
