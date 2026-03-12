using Core.Interfaces;
using UnityEngine;

namespace Gameplay.PlayerSystem
{
    public class PlayerProvider : MonoBehaviour, IEntityProvider
    {
        private Core.Player _player;
        
        public void Initialize(IEntity entity) => _player = entity as Core.Player;
        public IEntity Provide() => _player;
    }
}