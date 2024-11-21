namespace Lvl1
{
    public class Character //----- basic setup of the character class
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
    public class CharacterCreation //----- creating different character classes and sorting them into a list
    {
        public List<Character> InitializeCharacterList()
        {
            Character warrior = new Character("WARRIOR", 100, 50, (character, target) =>
            {
                Console.WriteLine($"{character.Name} slams down his sword for {character.ChangeAmount} damage!");
            });
            
            Character rogue = new Character("ROGUE", 40, 50, (character, target) =>
            {
                Console.WriteLine($"{character.Name} performs a sneak attack for {character.ChangeAmount} damage!");
            });
            
            Character mage = new Character("MAGE", 20, 20, (character, target) =>
            {
                Console.WriteLine($"{character.Name} casts a spell for {character.ChangeAmount} damage!");
            });
            
            Character healer = new Character("HEALER", 60, 30, (character, target) =>
            {
                target.Health += character.ChangeAmount;
                Console.WriteLine($"{character.Name} chooses {target.Name} as heal target because of lowest health");
                Console.WriteLine($"{target.Name} is healed for {character.ChangeAmount} HP and now has {target.Health} HP!");
            });
            
            return new List<Character> {warrior,rogue,mage,healer};
        }
    }
    public class CombatConditions //----- the condition checks that determine the turn
    {
       public static Func<Character, bool> IsHealthbelow50 = character => character.Health < 50;

       public static Func<Character, bool> IsHealer = character => character.Name == "HEALER"; //---oh no! - hardcode!

       public static Func<List<Character>, List<Character>> SortedByHealth = characters =>
       {
           return characters.OrderBy(character => character.Health).ToList();
       };
    }
    public class CombatGameflow //----- turn order governed by the combat conditions
    {
        private List<Character> _characterList { get; set; }

        public CombatGameflow(List<Character> characters)
        {
            _characterList = characters;
        }
        
        public void CombatTurn()
        {
            _characterList = CombatConditions.SortedByHealth(_characterList);
            var healer = _characterList.FirstOrDefault(character => CombatConditions.IsHealer(character));
            
            Action HeroTurn = () =>
            {
                Console.WriteLine("------- The battle begins -------");
                Console.WriteLine();
                
                foreach (var character in _characterList)
                {
                    if (CombatConditions.IsHealthbelow50(character)) //----- characters with below 50 health go first
                    {
                        Console.WriteLine($"{character.Name} moves first because of below 50 health");
                        character.PrimaryAction(character, null);
                    }
                    else //----- now all remaining characters attack
                    {
                        if (CombatConditions.IsHealer(character)) //----- healer picks character with lowest health as target
                        {
                            var healTarget = _characterList.OrderBy(character => character.Health).FirstOrDefault();
                            character.PrimaryAction(healer, healTarget);
                        }
                        else
                        {
                            character.PrimaryAction(character, null);
                        }
                    }
                }
            };
            
            HeroTurn();
            TriggerEndCondition();
        }
        
        public void TriggerEndCondition()
        {
            Action BattleEnd = () =>
            {
                Console.WriteLine();
                Console.WriteLine("------------------- Combat has ended -------------------");
            };
            BattleEnd();
        }
    }
}