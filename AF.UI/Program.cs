using AF.Business;
using AF.Business.Abstract;
using AF.Business.Managers;
using AF.DataAccess;
using AF.DataAccess.Abstract;

namespace AF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            CharacterRepository characterRepository = new CharacterRepository();
            SkillRepository skillRepository = new SkillRepository();
            ItemRepository itemRepository = new ItemRepository();
            ISaveRepository saveRepository = new SaveRepository();

            ICombatService combatManager = new CombatManager();
            IEnemyAIService enemyAIManager = new EnemyAIManager();
            IItemService itemManager = new ItemManager();
            ISaveService saveManager = new SaveManager(saveRepository, characterRepository, itemRepository, skillRepository);
            ISkillService skillManager = new SkillManager();
            IGameService gameManager = new GameManager(combatManager, enemyAIManager, itemManager, saveManager, skillManager, characterRepository);

            ConsoleUI ui = new ConsoleUI(gameManager);

            try
            {
                ui.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal Error : {ex.Message}");
            }
        }
    }
}