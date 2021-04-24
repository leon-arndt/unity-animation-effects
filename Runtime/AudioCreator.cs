using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationEffects
{
    /// <summary>
    /// Handle the sound for the game
    /// Dynamically creates audio sources from audio clips
    /// Domain: runtime
    /// </summary>
    public class AudioCreator : MonoBehaviour
    {
        private const float safetyTailDuration = 0.3f;

        //Create audio source as child in scene and destroy after clip duration
        public static void CreateTemporarySound(SoundEffectData data)
        {
            AudioSource source = CreateSound(data.audioClip);
            source.volume = data.volume;
            
            //random pitching
            if (data.useRandomPitch)
            {
                //determine the pitch according to min and max settings
                float pitch = Random.Range(data.randomPitch[0], data.randomPitch[1]);
                source.pitch = pitch;
            }

            //automatically destroy
            Destroy(source.gameObject, data.audioClip.length + safetyTailDuration);
        }

        /// <summary>
        /// Create a sound in the scene hierarchy
        /// </summary>
        /// <param name="clip"></param>
        /// <returns></returns>
        private static AudioSource CreateSound(AudioClip clip)
        {
            GameObject audioGO = new GameObject(clip.name);
            AudioSource source = audioGO.AddComponent<AudioSource>();
            source.clip = clip;
            source.Play();

            AudioCreator creator = FindObjectOfType<AudioCreator>();
            audioGO.transform.SetParent(creator.transform);

            return source;
        }
    }
}