using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEffects
{
    /// <summary>
    /// Play animation effects on the character
    /// Domain: Runtime
    /// </summary>
    public class AnimationEffectsPlayer : MonoBehaviour
    {
        /// <summary>
        /// Play the selected animation effects data
        /// </summary>
        /// <param name="data"></param>
        public void Play(Animator animator, AnimationEffectsData data)
        {
            foreach (var item in data.particles)
            {
                StartCoroutine(DelaySpawnParticles(item, animator));
            }

            //spawn the sound
            foreach (var item in data.sound)
            {
                StartCoroutine(DelaySounds(item));
            }
        }

        /// <summary>
        /// Spawn the particles with a delay
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEnumerator DelaySpawnParticles(ParticleEffectData data, Animator animator)
        {
            yield return new WaitForSeconds(data.particleSpawnTime);

            //spawn the particle
            GameObject particle = Instantiate(data.particlePrefab);

            //set the particle position
            if (data.useLocalSpace)
            {
                //use TransformPoint to convert to animator's local space
                Vector3 localPosition = animator.transform.TransformPoint(data.positionOffset);
                particle.transform.position = localPosition;
            }
            else
            {
                //use global space
                particle.transform.position = transform.position + data.positionOffset;
            }

            //parent to the character according to bool
            if (data.parentToCharacter)
            {
                particle.transform.parent = animator.transform;
            }
        }

        /// <summary>
        /// Create sounds with delay based on the data inside the sound effect
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEnumerator DelaySounds(SoundEffectData data)
        {
            yield return new WaitForSeconds(data.soundTriggerTime);

            //spawn the sound
            AudioCreator.CreateTemporarySound(data);
        }
    }
}