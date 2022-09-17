using UnityEngine;

namespace GameSystems
{
    public class FloppaAudioPlayer : MonoBehaviour
    {
        AudioSourcePool audioSourcePool;

        [SerializeField]
        AudioClip flapClip;
        
        [SerializeField]
        AudioClip impactClip;
        
        [SerializeField]
        AudioClip groundImpactClip;

        private void Start()
        {
            audioSourcePool = GetComponent<AudioSourcePool>();
        }

        public void PlayFlapClip()
        {
            audioSourcePool.PlayAudioClip(flapClip);
        }

        public void PlayImpactClip()
        {
            audioSourcePool.PlayAudioClip(impactClip);
        }

        public void PlayGroundImpactClip()
        {
            audioSourcePool.PlayAudioClip(groundImpactClip);
        }
    }
}