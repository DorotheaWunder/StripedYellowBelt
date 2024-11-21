namespace Lvl1
{
    public class Program
    {
        public static void Main()
        {
            CharacterCreation characterCreation = new CharacterCreation();
            List<Character> characters = characterCreation.InitializeCharacterList();
            CombatGameflow combatGameflow = new CombatGameflow(characters);
            
            combatGameflow.CombatTurn();
        }
    }
}