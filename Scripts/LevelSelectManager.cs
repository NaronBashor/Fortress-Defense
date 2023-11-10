using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelSelectManager : MonoBehaviour, IDataPersistence
{
        private int currentLevel = 0;
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

        private int levelUnlocked = 0;

        private int coinTotal;

        public List<GameObject> levelBanners = new List<GameObject>();
        public List<int> levelScores = new List<int>();

        [SerializeField] private Sprite oneStar;
        [SerializeField] private Sprite twoStar;
        [SerializeField] private Sprite threeStar;

        [SerializeField] private TextMeshProUGUI expLevelText;
        [SerializeField] private TextMeshProUGUI coinTotalText;

        public void LoadData(GameData data)
        {
                this.levelUnlocked = data.levelUnlocked;

                this.coinTotal = data.coinTotal;

                this.currentLevel = data.currentLevel;

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
                data.levelUnlocked = this.levelUnlocked;

                data.coinTotal = this.coinTotal;

                data.currentLevel = this.currentLevel;

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
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();

                for (int i = 0; i < levelBanners.Count; i++)
                {
                        levelBanners[i].GetComponentInChildren<UnityEngine.UI.Button>().interactable = false;
                }
                for (int i = 0; i < levelUnlocked; i++)
                {
                        levelBanners[i].GetComponentInChildren<UnityEngine.UI.Button>().interactable = true;
                }

                expLevelText.text = currentLevel.ToString();
                coinTotalText.text = coinTotal.ToString();

                levelScores.Add(level1Score);
                levelScores.Add(level2Score);
                levelScores.Add(level3Score);
                levelScores.Add(level4Score);
                levelScores.Add(level5Score);
                levelScores.Add(level6Score);
                levelScores.Add(level7Score);
                levelScores.Add(level8Score);
                levelScores.Add(level9Score);
                levelScores.Add(level10Score);
                levelScores.Add(level11Score);
                levelScores.Add(level12Score);
                levelScores.Add(level13Score);
                levelScores.Add(level14Score);
                levelScores.Add(level15Score);

                for (int i = 1; i < levelUnlocked; i++)
                {
                        Sprite banner;
                        int image = levelScores[i - 1];
                        if (image == 1)
                        {
                                banner = oneStar;
                                GameObject.FindGameObjectWithTag("Level" + i).GetComponent<UnityEngine.UI.Image>().sprite = banner;
                        }
                        else if (image == 2)
                        {
                                banner = twoStar;
                                GameObject.FindGameObjectWithTag("Level" + i).GetComponent<UnityEngine.UI.Image>().sprite = banner;
                        }
                        else if (image == 3)
                        {
                                banner = threeStar;
                                GameObject.FindGameObjectWithTag("Level" + i).GetComponent<UnityEngine.UI.Image>().sprite = banner;
                        }
                }

        }
}
