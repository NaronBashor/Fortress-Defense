using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
        public int currentLevel;
        public float experienceTotal;

        public int coinTotal;

        public bool iceSpellUnlocked;
        public bool lightningSpellUnlocked;
        public bool fireballSpellUnlocked;

        public int totalKills;

        public int ironArrowUpgrade;
        public int fireArrowUpgrade;
        public int iceArrowUpgrade;
        public int poisonArrowUpgrade;
        public int lightArrowUpgrade;
        public int darkArrowUpgrade;

        public int iceSpellLevel;
        public int lightningSpellLevel;
        public int fireballSpellLevel;

        public int level1Score;
        public int level2Score;
        public int level3Score;
        public int level4Score;
        public int level5Score;
        public int level6Score;
        public int level7Score;
        public int level8Score;
        public int level9Score;
        public int level10Score;
        public int level11Score;
        public int level12Score;
        public int level13Score;
        public int level14Score;
        public int level15Score;

        public int levelUnlocked;

        public bool secondArcherPurchased;
        public bool thirdArcherPurchased;

        public bool allArchersPurchased;

        public bool archerOneUnlocked;
        public bool archerTwoUnlocked;
        public bool archerThreeUnlocked;
        public bool archerFourUnlocked;
        public bool archerFiveUnlocked;
        public bool archerSixUnlocked;
        public bool archerSevenUnlocked;
        public bool archerEightUnlocked;

        public int fortressUpgradeLevel;
        public float attackSpeedUpgradeLevel;
        public float spellCooldownUpgradeLevel;
        public float expBoostUpgradeLevel;

        public int spentPoints;

        public int archerSelected;

        public GameData()
        {
                this.coinTotal = 0;

                this.iceSpellUnlocked = false;
                this.lightningSpellUnlocked = false;
                this.fireballSpellUnlocked = false;

                this.fortressUpgradeLevel = 1;
                this.attackSpeedUpgradeLevel = 1;
                this.spellCooldownUpgradeLevel = 1;
                this.expBoostUpgradeLevel = 1;

                this.spentPoints = 0;

                this.currentLevel = 0;
                this.experienceTotal = 0;
                this.ironArrowUpgrade = 1;
                this.fireArrowUpgrade = 0;
                this.iceArrowUpgrade = 0;
                this.poisonArrowUpgrade = 0;
                this.lightArrowUpgrade = 0;
                this.darkArrowUpgrade = 0;
                this.totalKills =0;

                this.iceSpellLevel = 0;
                this.lightningSpellLevel = 0;
                this.fireballSpellLevel = 0;

                this.levelUnlocked = 1;

                this.secondArcherPurchased = false;
                this.thirdArcherPurchased = false;

                this.allArchersPurchased = false;

                this.level1Score = 0;
                this.level2Score = 0;
                this.level3Score = 0;
                this.level4Score = 0;
                this.level5Score = 0;
                this.level6Score = 0;
                this.level7Score = 0;
                this.level8Score = 0;
                this.level9Score = 0;
                this.level10Score = 0;
                this.level11Score = 0;
                this.level12Score = 0;
                this.level13Score = 0;
                this.level14Score = 0;
                this.level15Score = 0;

                this.archerOneUnlocked = false;
                this.archerTwoUnlocked = false;
                this.archerThreeUnlocked = false;
                this.archerFourUnlocked = false;
                this.archerFiveUnlocked = false;
                this.archerSixUnlocked = false;
                this.archerSevenUnlocked = false;
                this.archerEightUnlocked = false;

                this.archerSelected = 0;
        }
}
