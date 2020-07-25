using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace AnimationEffects
{
    /// <summary>
    /// This class is a serialized system object which is used to set up particles.
    /// Domain: Editor, Project-specific
    /// </summary>
    [System.Serializable]
    public class ParticleEffectData : System.Object
    {
        [AssetsOnly]
        public GameObject particlePrefab = null;

        public Vector3 positionOffset = Vector3.zero;

        [Tooltip("The delay in seconds to spawn particles after state is entered.")]
        public float particleSpawnTime = 0f;

        [Tooltip("Should the newly spawned particle be created as a child of the character?")]
        public bool parentToCharacter = false;

        [Tooltip("Should the newly spawned particle be created in the character's local space?")]
        public bool useLocalSpace = false;
    }
}