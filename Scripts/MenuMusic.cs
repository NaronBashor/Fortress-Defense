using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
        [SerializeField] private AudioSource menuMusic;

        private void Awake()
        {
                DontDestroyOnLoad(this);
                menuMusic = GetComponent<AudioSource>();
        }

        public void PlayMusic()
        {
                if (menuMusic.isPlaying)
                {
                        return;
                }
                menuMusic.Play();
        }

        public void StopMusic()
        {
                menuMusic.Stop();
        }
}
