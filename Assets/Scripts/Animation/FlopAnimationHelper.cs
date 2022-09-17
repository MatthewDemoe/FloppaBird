using Identifiers;
using UnityEngine;

namespace Animation
{
    public class FlopAnimationHelper : MonoBehaviour
    {
        Animator floppaAnimator;

        void Start()
        {
            floppaAnimator = GetComponent<Animator>();
        }

        public void PlayFlopAnimation()
        {
            floppaAnimator.SetTrigger(AnimationParameters.Flop);
        }
    }
}