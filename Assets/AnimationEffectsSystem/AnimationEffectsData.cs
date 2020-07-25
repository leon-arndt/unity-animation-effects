using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace AnimationEffects
{
    /// <summary>
    /// Scriptable object which is used to save info for spawned particle effects and sounds
    /// Domain: Editor, project-specific
    /// </summary>
    [CreateAssetMenu(fileName = "AnimationEffects", menuName = "ScriptableObjects/AnimationEffects", order = 1)]
    [Sirenix.OdinInspector.HideMonoScript]
    public class AnimationEffectsData : ScriptableObject
    {
        [Title("Animation Effects Data")]

        [InfoBox("Scriptable object which is used to save info for spawned particle effects and sounds. Use it by adding the corresponding animations and particles below.")]

        [Tooltip("React when the animator plays this clip.")]
        public AnimationClip linkedClip;

        [Header("Particles")]
        public ParticleEffectData[] particles;

        [Header("Sounds")]
        public SoundEffectData[] sound;
    }
}
