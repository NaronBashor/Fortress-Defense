using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private float experienceTotal;
        [SerializeField] private int currentLevel = 1;

        [SerializeField] private Image expImage;

        [SerializeField] TextMeshProUGUI expTotal;
        [SerializeField] TextMeshProUGUI level;

        private float startingExp = 0;
        private float startingLevel = 0;

        private bool resetValues = false;

        public bool ResetValues
        {
                get
                {
                        return resetValues;
                }
                set
                {
                        resetValues = value;
                }
        }

        public int CurrentLevel
        {
                get
                {
                        return currentLevel;
                }
                set
                {
                        currentLevel = value;
                }
        }

        public void LoadData(GameData data)
        {
                this.currentLevel = data.currentLevel;
                this.experienceTotal = data.experienceTotal;
        }

        public void SaveData(ref GameData data)
        {
                data.currentLevel = this.currentLevel;
                data.experienceTotal = this.experienceTotal;
        }

        private void Start()
        {
                resetValues = false;
                startingExp = experienceTotal;
                startingLevel = currentLevel;
        }

        private void Update()
        {
                expTotal.text = experienceTotal.ToString() + " / " + (currentLevel * 500).ToString();
                level.text = currentLevel.ToString();
                expImage.fillAmount = experienceTotal / (currentLevel * 500);
                if (resetValues)
                {
                        OnResetValues();
                }
        }

        public void AddExp(float expPoints)
        {
                experienceTotal += expPoints;
                if (experienceTotal >= currentLevel * 500)
                {
                        currentLevel++;
                        float newTotal = experienceTotal - ((currentLevel - 1) * 500);
                        experienceTotal = newTotal;
                }
        }

        public void OnResetValues()
        {
                experienceTotal = startingExp;
                currentLevel = (int)startingLevel;
                resetValues = false;
        }
}
