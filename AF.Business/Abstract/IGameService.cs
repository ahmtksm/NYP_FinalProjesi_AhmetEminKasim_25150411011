using AF.Core.Results;
using AF.Entities;
using AF.Entities.Abstract;
using AF.Entities.Characters;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Players;
using AF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Abstract
{
    /// <summary>
    /// Oyun hizmetleri için arayüz, bir oyunu başlatmak, savaşları yönetmek ve oyun akışını ele almak için yöntemler tanımlar
    /// </summary>
    public interface IGameService
    {
        IDataResult<Player> NewGame(PlayerType playerType);
        IDataResult<GameState> LoadGame();
        IDataResult<Enemy> GenerateRandomEnemy();
        IResult SaveGame(Player player, Enemy enemy);
        IResult ProcessPlayerAction(ActionType action, Player player, Enemy enemy, ISkill? skill = null, IItem? item = null);
        IResult ProcessEnemyAction(Player player, Enemy enemy);
        IResult EndTurn(Character character);
        bool IsBattleOver(Player player, Enemy enemy);
    }
}