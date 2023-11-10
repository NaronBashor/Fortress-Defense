using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour, IDataPersistence
{
        #region Inspector

        [Header("Game Objects")]
        [SerializeField] public List<GameObject> enemies = new List<GameObject>();
        [SerializeField] private UnityEngine.UI.Image waveProgressBarImage;

        [Header("Spawn Locations")]
        [SerializeField] public List<Transform> spawnLevels = new List<Transform>();

        [Header("Spawn Stats")]
        [SerializeField] private float initialSpawnTimer;
        [SerializeField] private float countDownTimer;

        [Header("Wave Info")]
        [SerializeField] private float initialWaveTime;
        [SerializeField] private float waveTime;
        [SerializeField] private int waveTimeMultiplier = 1;
        [SerializeField] private int layerIncrease;

        [Header("Level End Screen")]
        [SerializeField] private GameObject levelClearedPanel;
        [SerializeField] private GameObject starIcon;
        [SerializeField] private Sprite oneStarIcon;
        [SerializeField] private Sprite twoStarIcon;
        [SerializeField] private Sprite threeStarIcon;

        [Header("Level Info")]
        [SerializeField] private int currentLevel;
        [SerializeField] private int levelUnlocked;

        [Header("Enemy Death Stats")]
        [SerializeField] public List<GameObject> killCount = new List<GameObject>();
        [SerializeField] public List<GameObject> currentEnemiesRemaining = new List<GameObject>();

        [SerializeField] private AudioSource bossSpawn;

        [SerializeField] private TextMeshProUGUI killCountText;
        [SerializeField] private TextMeshProUGUI currentKillCountText;

        [SerializeField] private AudioSource endOfLevel;

        private float waveStartTime;
        private bool playedEndSound = false;
        private bool addedCoins = false;

        private int level1Score = 0;
        private int level2Score = 0;
        private int level3Score = 0;
        private int level4Score = 0;
        private int level5Score = 0;
        private int level6Score = 0;
        private int level7Score = 0;
        private int level8Score = 0;
        private int level9Score = 0;
        private int level10Score = 0;
        private int level11Score = 0;
        private int level12Score = 0;
        private int level13Score = 0;
        private int level14Score = 0;
        private int level15Score = 0;

        private int score;
        private bool save = false;
        private bool bossLevel = false;
        private bool spawnBoss = false;
        private bool bossSpawnSoundPlayed = false;

        private int coinsEarned;
        private int killTotal;

        #endregion

        public int WaveTimeMultplier
        {
                get
                {
                        return waveTimeMultiplier;
                }
                set
                {
                        waveTimeMultiplier = value;
                }
        }

        public void LoadData(GameData data)
        {
                this.killTotal = data.totalKills;
                this.coinsEarned = data.coinTotal;
                this.levelUnlocked = data.levelUnlocked;

                this.level1Score = data.level1Score;
                this.level2Score = data.level2Score;
                this.level3Score = data.level3Score;
                this.level4Score = data.level4Score;
                this.level5Score = data.level5Score;
                this.level6Score = data.level6Score;
                this.level7Score = data.level7Score;
                this.level8Score = data.level8Score;
                this.level9Score = data.level9Score;
                this.level10Score = data.level10Score;
                this.level11Score = data.level11Score;
                this.level12Score = data.level12Score;
                this.level13Score = data.level13Score;
                this.level14Score = data.level14Score;
                this.level15Score = data.level15Score;
        }

        public void SaveData(ref GameData data)
        {
                data.totalKills += this.killTotal;
                if (save)
                {
                        data.coinTotal += this.coinsEarned;
                }
                data.levelUnlocked = this.levelUnlocked;

                data.level1Score = this.level1Score;
                data.level2Score = this.level2Score;
                data.level3Score = this.level3Score;
                data.level4Score = this.level4Score;
                data.level5Score = this.level5Score;
                data.level6Score = this.level6Score;
                data.level7Score = this.level7Score;
                data.level8Score = this.level8Score;
                data.level9Score = this.level9Score;
                data.level10Score = this.level10Score;
                data.level11Score = this.level11Score;
                data.level12Score = this.level12Score;
                data.level13Score = this.level13Score;
                data.level14Score = this.level14Score;
                data.level15Score = this.level15Score;
        }

        private void Start()
        {
                waveStartTime = initialWaveTime * waveTimeMultiplier;
                waveTime = waveStartTime;
                layerIncrease = 0;

                levelClearedPanel.SetActive(false);
        }

        private void Update()
        {
                currentKillCountText.text = coinsEarned.ToString();

                if (currentLevel == 5 || currentLevel == 8 || currentLevel == 10 || currentLevel == 15)
                {
                        bossLevel = true;
                }
                else
                {
                        bossLevel = false;
                }
                if (initialSpawnTimer >= 0.5f)
                {
                        initialSpawnTimer -= Time.deltaTime / 50;
                }

                if (countDownTimer >=0)
                {
                        countDownTimer -= Time.deltaTime;
                }

                if (waveTime >= 0)
                {
                        waveTime -= Time.deltaTime;
                }
                else if (waveTime <= 0)
                {
                        if (bossLevel && !spawnBoss)
                        {
                                if (!bossSpawnSoundPlayed)
                                {
                                        bossSpawnSoundPlayed = true;
                                        bossSpawn.Play();
                                }
                                spawnBoss = true;
                                bossLevel = false;
                                OnSpawn(10, 2);
                        }
                        if (!bossLevel && currentEnemiesRemaining.Count <= 0)
                        {
                                killCountText.text = killCount.Count.ToString();
                                StartCoroutine(Delay());
                                IEnumerator Delay()
                                {
                                        yield return new WaitForSeconds(1f);
                                        GameObject fortress = GameObject.Find("Fortress");
                                        float healthPercent = fortress.GetComponent<Damageable>().Health / fortress.GetComponent<Damageable>().MaxHealth;
                                        if (healthPercent >= 0.8)
                                        {
                                                score = 3;
                                                starIcon.GetComponent<UnityEngine.UI.Image>().sprite = threeStarIcon;
                                        }
                                        else if (healthPercent >= 0.50f && healthPercent < 0.80f)
                                        {
                                                score = 2;
                                                starIcon.GetComponent<UnityEngine.UI.Image>().sprite = twoStarIcon;
                                        }
                                        else if (healthPercent < 0.50f)
                                        {
                                                score =1;
                                                starIcon.GetComponent<UnityEngine.UI.Image>().sprite = oneStarIcon;
                                        }

                                        switch (currentLevel)
                                        {
                                                case 1:
                                                        if (score >= level1Score)
                                                        {
                                                                level1Score = score;
                                                        }
                                                        break;
                                                case 2:
                                                        if (score >= level2Score)
                                                        {
                                                                level2Score = score;
                                                        }
                                                        break;
                                                case 3:
                                                        if (score >= level3Score)
                                                        {
                                                                level3Score = score;
                                                        }
                                                        break;
                                                case 4:
                                                        if (score >= level4Score)
                                                        {
                                                                level4Score = score;
                                                        }
                                                        break;
                                                case 5:
                                                        if (score >= level5Score)
                                                        {
                                                                level5Score = score;
                                                        }
                                                        break;
                                                case 6:
                                                        if (score >= level6Score)
                                                        {
                                                                level6Score = score;
                                                        }
                                                        break;
                                                case 7:
                                                        if (score >= level7Score)
                                                        {
                                                                level7Score = score;
                                                        }
                                                        break;
                                                case 8:
                                                        if (score >= level8Score)
                                                        {
                                                                level8Score = score;
                                                        }
                                                        break;
                                                case 9:
                                                        if (score >= level9Score)
                                                        {
                                                                level9Score = score;
                                                        }
                                                        break;
                                                case 10:
                                                        if (score >= level10Score)
                                                        {
                                                                level10Score = score;
                                                        }
                                                        break;
                                                case 11:
                                                        if (score >= level11Score)
                                                        {
                                                                level11Score = score;
                                                        }
                                                        break;
                                                case 12:
                                                        if (score >= level12Score)
                                                        {
                                                                level12Score = score;
                                                        }
                                                        break;
                                                case 13:
                                                        if (score >= level13Score)
                                                        {
                                                                level13Score = score;
                                                        }
                                                        break;
                                                case 14:
                                                        if (score >= level14Score)
                                                        {
                                                                level14Score = score;
                                                        }
                                                        break;
                                                case 15:
                                                        if (score >= level15Score)
                                                        {
                                                                level15Score = score;
                                                        }
                                                        break;
                                        }

                                        if (!playedEndSound)
                                        {
                                                playedEndSound = true;
                                                endOfLevel.Play();
                                        }
                                        if (!addedCoins)
                                        {
                                                save = true;
                                                addedCoins = true;
                                                coinsEarned = killCount.Count;
                                                killTotal = killCount.Count;
                                        }
                                        levelClearedPanel.SetActive(true);
                                        levelUnlocked = currentLevel + 1;
                                        Time.timeScale = 0;
                                }
                        }
                }

                waveProgressBarImage.fillAmount = waveTime / waveStartTime;
                if (countDownTimer <= 0 && waveTime >= 0)
                {
                        RandomSpawn();
                        countDownTimer = initialSpawnTimer;
                }
        }

        private void RandomSpawn()
        {
                int randomNumber = Random.Range(0, 101);
                if (randomNumber <= 80)
                {
                        int spawnIndex = Random.Range(0, 7);
                        if (spawnIndex < 5)
                        {
                                int laneIndex = Random.Range(0, 4);
                                OnSpawn(spawnIndex, laneIndex);
                        }
                        else if (spawnIndex >= 5)
                        {
                                int laneIndex = Random.Range(4, 6);
                                OnSpawn(spawnIndex, laneIndex);
                        }
                }
                else if (randomNumber > 80)
                {
                        int spawnIndex = Random.Range(7, 10);
                        int laneIndex = Random.Range(2, 4);
                        OnSpawn(spawnIndex, laneIndex);
                }
                else
                {
                        Debug.LogError("Random Number Excpetion.");
                }
        }

        private void OnSpawn(int index, int lane)
        {
                GameObject enemyObj = Instantiate(enemies[index], spawnLevels[lane].position, Quaternion.identity);
                if (lane == 0)
                {
                        enemyObj.GetComponent<SpriteRenderer>().sortingOrder = 500 + layerIncrease;
                        enemyObj.transform.localScale = new Vector2(1.30f, 1.30f);
                }
                if (lane == 1)
                {
                        enemyObj.GetComponent<SpriteRenderer>().sortingOrder = 400 + layerIncrease;
                        enemyObj.transform.localScale = new Vector2(1.20f, 1.20f);
                }
                if (lane == 2)
                {
                        enemyObj.GetComponent<SpriteRenderer>().sortingOrder = 300 + layerIncrease;
                        enemyObj.transform.localScale = new Vector2(1.10f, 1.10f);
                }
                if (lane == 3)
                {
                        enemyObj.GetComponent<SpriteRenderer>().sortingOrder = 200 + layerIncrease;
                        enemyObj.transform.localScale = new Vector2(1, 1);
                }
                if (lane == 4)
                {
                        enemyObj.GetComponent<SpriteRenderer>().sortingOrder = 100 + layerIncrease;
                        enemyObj.transform.localScale = new Vector2(0.9f, 0.9f);
                }
                if (lane == 5)
                {
                        enemyObj.GetComponent<SpriteRenderer>().sortingOrder = 1 + layerIncrease;
                        enemyObj.transform.localScale = new Vector2(0.8f, 0.8f);
                }
                currentEnemiesRemaining.Add(enemyObj);
                layerIncrease++;
        }
}
