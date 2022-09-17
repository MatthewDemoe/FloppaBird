using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Identifiers;

namespace GameSystems
{
    public class AudioSettingAdjuster : MonoBehaviour
    {
        private const string Volume = nameof(Volume);
        private const float MinVolume = -80.0f;
        private const float MaxVolume = 10.0f;

        [SerializeField]
        AudioMixer masterAudio;

        [SerializeField]
        AudioMixer musicAudio;

        [SerializeField]
        AudioMixer sfxAudio;

        [SerializeField]
        Slider masterSlider;

        [SerializeField]
        Slider musicSlider;

        [SerializeField]
        Slider sfxSlider;

        void Start()
        {
            SetInitialValues();
            gameObject.SetActive(false);
        }

        private void SetInitialValues()
        {
            masterSlider.minValue = MinVolume;
            masterSlider.maxValue = MaxVolume;

            musicSlider.minValue = MinVolume;
            musicSlider.maxValue = MaxVolume;

            sfxSlider.minValue = MinVolume;
            sfxSlider.maxValue = MaxVolume;

            masterSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.MasterVolume);
            masterAudio.SetFloat(Volume, masterSlider.value);

            musicSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.MusicVolume);
            musicAudio.SetFloat(Volume, musicSlider.value);

            sfxSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.SFXVolume);
            sfxAudio.SetFloat(Volume, sfxSlider.value);

            masterSlider.onValueChanged.AddListener(delegate (float value)
            {
                UpdateValues();
            });

            musicSlider.onValueChanged.AddListener(delegate (float value)
            {
                UpdateValues();
            });

            sfxSlider.onValueChanged.AddListener(delegate (float value)
            {
                UpdateValues();
            });
        }

        public void UpdateValues()
        {
            masterAudio.SetFloat(Volume, masterSlider.value);
            if (masterSlider.value != PlayerPrefs.GetFloat(PlayerPrefsKeys.MasterVolume))
                PlayerPrefs.SetFloat(PlayerPrefsKeys.MasterVolume, masterSlider.value);

            musicAudio.SetFloat(Volume, musicSlider.value);
            if (musicSlider.value != PlayerPrefs.GetFloat(PlayerPrefsKeys.MusicVolume))
                PlayerPrefs.SetFloat(PlayerPrefsKeys.MusicVolume, musicSlider.value);

            sfxAudio.SetFloat(Volume, sfxSlider.value);
            if (sfxSlider.value != PlayerPrefs.GetFloat(PlayerPrefsKeys.SFXVolume))
                PlayerPrefs.SetFloat(PlayerPrefsKeys.SFXVolume, sfxSlider.value);
        }
    }
}