using Unity.VisualScripting;

namespace Player
{
    public interface IPlayerState
    {
        void OnEnter(PlayerStateMachine player);
        void OnUpdate(PlayerStateMachine player);
        void OnExit(PlayerStateMachine player);
    }
}