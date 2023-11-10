using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
        [SerializeField] AudioSource audioSource;

        private void Start()
        {
                if (audioSource.isPlaying)
                {
                        return;
                }
                audioSource.Play();
        }
}
