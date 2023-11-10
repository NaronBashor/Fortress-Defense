using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour, IDataPersistence
{
        private int ironArrowLevel = 0;
        private int fireArrowLevel = 0;
        private int iceArrowLevel = 0;
        private int poisonArrowLevel = 0;
        private int lightArrowLevel = 0;
        private int darkArrowLevel = 0;

        private float expBoostLevel = 1;

        private int currentLevel = 0;

        private int iceSpellLevel = 1;
        private int fireSpellLevel = 1;
        private int lightningSpellLevel = 1;

        #region Properties

        public int LightningSpellLevel
        {
                get
                {
                        return lightningSpellLevel;
                }
                set
                {
                        lightningSpellLevel = value;
                }
        }

        public int FireSpellLevel
        {
                get
                {
                        return fireSpellLevel;
                }
                set
                {
                        fireSpellLevel = value;
                }
        }

        public int IceSpellLevel
        {
                get
                {
                        return iceSpellLevel;
                }
                set
                {
                        iceSpellLevel = value;
                }
        }

        public float ExpBoostLevel
        {
                get
                {
                        return expBoostLevel;
                }
                set
                {
                        expBoostLevel = value;
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

        public int IronArrowLevel
        {
                get
                {
                        return ironArrowLevel;
                }
                set
                {
                        ironArrowLevel = value;
                }
        }

        public int FireArrowLevel
        {
                get
                {
                        return fireArrowLevel;
                }
                set
                {
                        fireArrowLevel = value;
                }
        }

        public int IceArrowLevel
        {
                get
                {
                        return iceArrowLevel;
                }
                set
                {
                        iceArrowLevel = value;
                }
        }

        public int PoisonArrowLevel
        {
                get
                {
                        return poisonArrowLevel;
                }
                set
                {
                        poisonArrowLevel = value;
                }
        }

        public int LightArrowLevel
        {
                get
                {
                        return lightArrowLevel;
                }
                set
                {
                        lightArrowLevel = value;
                }
        }

        public int DarkArrowLevel
        {
                get
                {
                        return darkArrowLevel;
                }
                set
                {
                        darkArrowLevel = value;
                }
        }
        #endregion        

        public void LoadData(GameData data)
        {
                this.ironArrowLevel = data.ironArrowUpgrade;
                this.fireArrowLevel = data.fireArrowUpgrade;
                this.iceArrowLevel = data.iceArrowUpgrade;
                this.poisonArrowLevel = data.poisonArrowUpgrade;
                this.lightArrowLevel = data.lightArrowUpgrade;
                this.darkArrowLevel = data.darkArrowUpgrade;
                this.expBoostLevel = data.expBoostUpgradeLevel;

                this.currentLevel = data.currentLevel;
        }

        public void SaveData(ref GameData data)
        {
        }
}
