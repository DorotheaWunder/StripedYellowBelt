namespace Lvl3;

public class Program
{
    public static void Main()
    {
        //Instanciate the Template class and ability container Generic
        Templates templates = new Templates();
        var abilityContainer = new Templates.AbilityContainer<Templates.IAbility>();

        //Instanciate heal and attack abilities and put them into the container
        templates.AddAbilities(abilityContainer);

        //Display all abilities in the container
        templates.DisplayAbilities(abilityContainer);
    }
}