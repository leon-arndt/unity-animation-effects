using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEffects
{
    /// <summary>
    /// Add this class to every animation layer inside the animator
    /// It will automatically play linked animation efffects inside its character set
    /// Domain: Runtime
    /// </summary>
    public class AnimationListener : StateMachineBehaviour
    {

        public CharacterEffectSet characterSet;

        /// <summary>
        /// Evaluate whether any newly entered state should play an animation
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="animatorStateInfo"></param>
        /// <param name="layerIndex"></param>
        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            AnimationEffectsPlayer player = FindObjectOfType<AnimationEffectsPlayer>();

            foreach (var effect in characterSet.effects)
            {
                //does the animation clip name match?
                if (animator.GetNextAnimatorStateInfo(layerIndex).IsName(effect.linkedClip.name))
                {
                    player.Play(animator, effect);

                    //return early because one animator state may only play one animation effect (that effect can still have multiple particles).
                    return;
                }
            }
        }
    }
}