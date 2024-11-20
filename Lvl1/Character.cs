namespace Lvl1
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int ChangeAmount { get; set; }
        public Action<Character, Character> PrimaryAction { get; set; }
        public Character(string name, int health, int changeAmount, Action<Character, Character> primaryAction)
        {
            Name = name;
            Health = health;
            ChangeAmount = changeAmount;
            PrimaryAction = primaryAction;
        }
    }
}