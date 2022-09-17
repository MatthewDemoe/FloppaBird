using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameSystems
{
    public class AudioSourcePool : MonoBehaviour
    {
        protected const float FadeOutDuration = 1.0f;

        [SerializeField]
        protected GameObject audioSourcePoolParent;

        [SerializeField]
        protected GameObject audioSourcePrefab;

        [SerializeField]
        float initialNumberOfAudioSources = 5.0f;

        protected List<AudioSource> audioSourcePool = new List<AudioSource>();

        public bool isPlaying => audioSourcePool.Any(audioSource => audioSource.gameObject.activeInHierarchy);

        protected virtual void Awake()
        {
            for (int i = 0; i < initialNumberOfAudioSources; i++)
            {
                audioSourcePool.Add(CreateNewAudioSource());
            }

            audioSourcePool.ForEach((audioSource) => audioSource.gameObject.SetActive(false));
        }

        public void PlayAudioClip(AudioClip audioClip)
        {
            GetFirstAvailableAudioSource().PlayAudioClip(audioClip);
        }

        protected AudioSource GetFirstAvailableAudioSource()
        {
            AudioSource audioSource = audioSourcePool.FirstOrDefault((poolAudioSource) => !poolAudioSource.gameObject.activeInHierarchy);

            if (audioSource == null)
                audioSource = CreateNewAudioSource();

            return audioSource.GetComponent<AudioSource>(); ;
        }
        protected AudioSource CreateNewAudioSource()
        {
            AudioSource newAudioSource = Instantiate(audioSourcePrefab, audioSourcePoolParent.transform).GetComponent<AudioSource>();

            audioSourcePool.Add(newAudioSource);
            newAudioSource.gameObject.SetActive(false);

            return newAudioSource;
        }

        public void DisableAudioClipWhenFinished(AudioSource audioSource)
        {
            StartCoroutine(DisableAudioClipWhenFinishedRoutine(audioSource));
        }

        public IEnumerator DisableAudioClipWhenFinishedRoutine(AudioSource audioSource)
        {
            yield return new WaitUntil(() => !audioSource.isPlaying);

            audioSource.StopAudioClip();
        }
    }
}