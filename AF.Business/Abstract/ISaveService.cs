using AF.Core.Results;
using AF.Entities;
using AF.Entities.Characters.Enemies;
using AF.Entities.Characters.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Business.Abstract
{
    /// <summary>
    /// Kaydetme ve yükleme işlemleri için servis arayüzü
    /// </summary>
    public interface ISaveService
    {
        IResult Save(Player player, Enemy enemy);
        IDataResult<GameState> Load();
    }
}