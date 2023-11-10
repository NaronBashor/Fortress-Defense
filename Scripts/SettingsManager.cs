using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
        [SerializeField] private float musicVolumeValue;
        [SerializeField] private float levelVolumeValue;
        [SerializeField] private float soundFXVolumeValue;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundFXSlider;
        [SerializeField] private GameObject settingsWindow;
        [SerializeField] private GameObject blackBackground;
        [SerializeField] private GameObject pauseMenu;

        private void Start()
        {
                musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
                musicSlider.value = PlayerPrefs.GetFloat("LevelVolume");
                soundFXSlider.value = PlayerPrefs.GetFloat("SoundFXVolume");
        }

        private void Update()
        {
                musicVolumeValue = musicSlider.value;
                levelVolumeValue = musicSlider.value;
                soundFXVolumeValue = soundFXSlider.value;
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<AudioSource>().volume = musicVolumeValue;
                if (GameObject.FindGameObjectWithTag("LevelMusic") != null)
                {
                        GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<AudioSource>().volume = levelVolumeValue;
                }
                GameObject.FindGameObjectWithTag("SoundFX").GetComponent<AudioSource>().volume = soundFXVolumeValue;
        }

        public void CloseSettingsWindow()
        {
                PlayerPrefs.SetFloat("MusicVolume", musicVolumeValue);
                PlayerPrefs.SetFloat("LevelVolume", levelVolumeValue);
                PlayerPrefs.SetFloat("SoundFXVolume", soundFXVolumeValue);
                settingsWindow.SetActive(false);
                blackBackground.SetActive(false);
                if (pauseMenu != null)
                {
                        pauseMenu.SetActive(true);
                }
        }

        public void OnSettings()
        {
                settingsWindow.SetActive(true);
                blackBackground.SetActive(true);
                if (pauseMenu != null)
                {
                        pauseMenu.SetActive(false);
                }
        }
}
