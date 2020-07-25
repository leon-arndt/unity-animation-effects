using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEffects
{
    /// <summary>
    /// Scriptable object which is used to save info for spawned particle effects and sounds
    /// Domain: Editor, project-specific
    /// </summary>
    [CreateAssetMenu(fileName = "AnimationEffects", menuName = "ScriptableObjects/AnimationEffects", order = 1)]
    public class AnimationEffectsData : ScriptableObject
    {
        [Tooltip("React when the animator plays this clip.")]
        public AnimationClip linkedClip;

        [Header("Particles")]
        public ParticleEffectData[] particles;

        [Header("Sounds")]
        public SoundEffectData[] sound;
    }
}
