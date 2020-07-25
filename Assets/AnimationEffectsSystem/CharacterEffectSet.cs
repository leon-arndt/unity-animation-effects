using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace AnimationEffects
{
    /// <summary>
    /// Used to scope animation effects to characters (the player shouldn't play an enemy's explosion)
    /// Domain: Editor, Project-specific
    /// </summary>
    [CreateAssetMenu(fileName = "CharacterEffectSet", menuName = "ScriptableObjects/CharacterEffectSet", order = 1)]
    public class CharacterEffectSet : ScriptableObject {
        [InfoBox("Add all AnimationEffectsData below")]
        public AnimationEffectsData[] effects;
    }
}