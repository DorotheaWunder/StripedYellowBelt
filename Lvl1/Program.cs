namespace Lvl1
{
    public class Program
    {
        public static void Main()
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
                Console.WriteLine($"{character.Name} heals {target.Name} for {character.ChangeAmount} HP!");
                Console.WriteLine($"{target.Name} now has {target.Health} HP");
            });

            List<Character> characters = new List<Character> {warrior,rogue,mage,healer};
            
            Func<Character, bool> isHealthbelow50 = (Character character) => character.Health < 50;    
            
            Action BattleEnd = () =>
            {
                Console.WriteLine();
                Console.WriteLine("The heroes realize that they've been fighting the air");
                Console.WriteLine("They all decide to visit a mental health specialist");
                Console.WriteLine("------------------- GAME OVER -------------------");
            };

            Action HeroTurn = () =>
            {
                var charactersOrdered = characters.OrderBy(character => character.Health).ToList();
                    
                Console.WriteLine("------- The battle begins -------");
                Console.WriteLine();

                foreach (var character in charactersOrdered)
                {
                    if (isHealthbelow50(character))
                    {
                        Console.WriteLine($"{character.Name} moves first because of below 50 health");
                        character.PrimaryAction(character, null); 
                    }
                    else if(character != healer)
                    { 
                        character.PrimaryAction(character, null); 
                    }
                    var healTarget = characters.OrderBy(character => character.Health).First();
                    healer.PrimaryAction(healer, healTarget);
                    
                }
                BattleEnd();
            };

            HeroTurn();
        }
    }
}