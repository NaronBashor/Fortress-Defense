using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FortressManager : MonoBehaviour
{
        SpriteRenderer sprite;

        [SerializeField] private Sprite fullHealth;
        [SerializeField] private Sprite firstDamage;
        [SerializeField] private Sprite secondDamage;
        [SerializeField] private Sprite destroyed;
        [SerializeField] private Image healthBar;
        [SerializeField] private TextMeshProUGUI currentHealth;

        [SerializeField] private AudioSource fortressDamage;
        [SerializeField] private AudioSource gameOver;

        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private int currentGameLevel;

        Damageable damageable;

        private bool playedFirstSound = false;
        private bool playedSecondSound = false;
        private bool gameOverSound = false;

        private int coinTotal;

        public int CurrentGameLevel
        {
                get
                {
                        return currentGameLevel;
                }
                set
                {
                        currentGameLevel = value;
                }
        }

        private void Awake()
        {
                if (Time.timeScale == 0)
                {
                        Time.timeScale = 1;
                }
        }

        private void Start()
        {
                damageable = GetComponent<Damageable>();
                sprite = GetComponent<SpriteRenderer>();
                sprite.sprite = fullHealth;

                gameOverScreen.SetActive(false);
        }

        private void Update()
        {
                currentHealth.text = damageable.Health.ToString() + " / " + damageable.MaxHealth.ToString();
                healthBar.fillAmount = damageable.Health / damageable.MaxHealth;
                if (damageable.Health / damageable.MaxHealth < .66 && damageable.Health / damageable.MaxHealth > .33)
                {
                        if (!playedFirstSound)
                        {
                                playedFirstSound = true;
                                fortressDamage.Play();
                        }
                        sprite.sprite = firstDamage;
                }
                else if (damageable.Health / damageable.MaxHealth < .33 && damageable.Health / damageable.MaxHealth > 0)
                {
                        if (!playedSecondSound)
                        {
                                playedSecondSound = true;
                                fortressDamage.Play();
                        }
                        sprite.sprite = secondDamage;
                }
                else if (damageable.Health <= 0)
                {
                        if (!gameOverSound)
                        {
                                gameOverSound = true;
                                gameOver.Play();
                        }
                        sprite.sprite = destroyed;
                        Time.timeScale = 0;
                        gameOverScreen.SetActive(true);
                        GameObject.Find("ExperienceManager").GetComponent<ExperienceManager>().ResetValues = true;
                }
        }
}
