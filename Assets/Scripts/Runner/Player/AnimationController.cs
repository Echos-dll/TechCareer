using UnityEngine;

namespace Player
{
    public class AnimationController : MonoBehaviour
    {
        private Animator m_animator;
        private int m_animationState;
        private static readonly int s_state = Animator.StringToHash("State");
        
        private void Awake()
        {
            m_animator = GetComponent<Animator>();
        }
        
        public void UpdateAnimationState(int state)
        {
            Debug.Log($"Current animation state {state}");
            m_animationState = state;
            m_animator.SetInteger(s_state, m_animationState);
        }
    }
}
