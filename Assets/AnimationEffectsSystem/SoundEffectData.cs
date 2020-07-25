using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace AnimationEffects
{
    /// <summary>
    /// Use this class to attach sound effects data to animations
    /// Optional: randomize the pitch for the sounds
    /// Domain: Editor, project-specific
    /// </summary>
    [System.Serializable]
    public class SoundEffectData : System.Object
    {
        public AudioClip audioClip = null;
        public float soundTriggerTime = 0f;

        [Tooltip("should the sound pitch be randomized?")]
        public bool useRandomPitch = false;

        //internal min and max pitch settings
        private const float minPitch = 0f;
        private const float maxPitch = 2f;

        //set up some reasonable defaults
        private const float defaultMinPitch = 0.7f;
        private const float defaultMaxPitch = 1.4f;

        [ShowIf("useRandomPitch")]
        [MinMaxSlider(minPitch, maxPitch)]
        public Vector2 randomPitch = new Vector2(defaultMinPitch, defaultMaxPitch);
    }
}