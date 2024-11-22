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
    
    public interface IIAbility
    {
        string Name { get; set; }
        string Effect { get; set; }
    }
    
    public class AttackAbility : IIAbility
    {
        public string Name { get; set; }
        public string Effect { get; set; }

        public AttackAbility(string name, string effect)
        {
            Name = name;
            Effect = effect;
        }
    }
    
    public class HealAbility : IIAbility
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        
        public HealAbility(string name, string effect)
        {
            Name = name;
            Effect = effect;
        }
    }

    public  void InstanciateAbilities(AbilityContainer<IIAbility> abilityContainer)
    {
        IIAbility attack = new AttackAbility("Attack", "Perform a physical attack on the enemy");
        IIAbility heal = new HealAbility("Heal", "Restore health for one of your party members");
        
        abilityContainer.AddAbility(attack);
        abilityContainer.AddAbility(heal);
    }
    public void DisplayAbilities(AbilityContainer<IIAbility> abilityContainer)
    {
        var abilities = abilityContainer.RetrieveAbility();

        foreach (var ability in abilities)
        {
            Console.WriteLine($"{ability.Name}: {ability.Effect}");
        }
    }
}
