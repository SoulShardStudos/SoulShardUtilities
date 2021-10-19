using UnityEngine;
namespace SoulShard.Utils
{
    // a simple animator controller, this allows for better 2D animation control.
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField] protected Animator _animator;
        string _currentState;
        protected void ChangeAnimState(string state)
        {
            if (_currentState == state)
                return;
            _animator.Play(state);
            _currentState = state;
        }
    }
}