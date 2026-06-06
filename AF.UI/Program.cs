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
            ISaveRepository saveRepository = new SaveRepository();
            CharacterRepository characterRepository = new CharacterRepository();
            SkillRepository skillRepository = new SkillRepository();
            ItemRepository itemRepository = new ItemRepository();

            CombatManager combatManager = new CombatManager();
            EnemyAIManager enemyAIManager = new EnemyAIManager();
            ItemManager itemManager = new ItemManager();
            SaveManager saveManager = new SaveManager(saveRepository, characterRepository, itemRepository, skillRepository);
            SkillManager skillManager = new SkillManager();

            IGameService gameManager = new GameManager(combatManager, enemyAIManager, itemManager, saveManager, skillManager, characterRepository);

            ConsoleUI ui = new ConsoleUI(gameManager);
            ui.Run();
        }
    }
}