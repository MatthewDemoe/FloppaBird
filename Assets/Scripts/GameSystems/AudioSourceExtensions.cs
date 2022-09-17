using UnityEngine;

namespace GameSystems
{
    public static class AudioSourceExtensions
    {
        public static float pitchRange = 0.1f;

        public static void PlayAudioClip(this AudioSource audioSource, AudioClip audioClip)
        {
            audioSource.gameObject.SetActive(true);
            audioSource.clip = audioClip;

            audioSource.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

            audioSource.Play();

            audioSource.GetComponentInParent<AudioSourcePool>().DisableAudioClipWhenFinished(audioSource);
        }

        public static void StopAudioClip(this AudioSource audioSource)
        {
            audioSource.Stop();
            audioSource.gameObject.SetActive(false);
        }
    }
}