namespace Lvl2;

public class Program
{
    public static void Main()///------------------------wonder if I should put all that into another program
    {
        // initialize characters
        Character hero = new Character("Hans-Peterine", 100);
        Character villain = new Character("Inge-Borg", 200);

        // create Eventhandler and add characters to it
        EventHandler eventHandler = new EventHandler();
        eventHandler.SubscribeToEvents(hero);
        eventHandler.SubscribeToEvents(villain);
        
        // characters perform CharacterAction
        //hero.Attack(villain, 100);
        villain.Attack(hero, 50);
        // hero.Attack(hero, 100);
        //Console.WriteLine("It has hurt itself in confusion");
    }
}

