using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelPrepManager : MonoBehaviour, IDataPersistence
{
        private int coinTotal = 0;

        private int fortressUpgradeLevel = 1;
        private float attackSpeedUpgradeLevel = 1;
        private float spellCooldownUpgradeLevel = 1;
        private float expBoostUpgradeLevel = 1;

        [SerializeField] private TextMeshProUGUI coinCounterText;
        [SerializeField] private TextMeshProUGUI fortressUpgradeLevelText;
        [SerializeField] private TextMeshProUGUI attackSpeedUpgradeLevelText;
        [SerializeField] private TextMeshProUGUI cooldownUpgradeLevelText;
        [SerializeField] private TextMeshProUGUI expBoostUpgradeLevelText;

        public void LoadData(GameData data)
        {
                this.coinTotal = data.coinTotal;

                this.fortressUpgradeLevel = data.fortressUpgradeLevel;
                this.attackSpeedUpgradeLevel = data.attackSpeedUpgradeLevel;
                this.spellCooldownUpgradeLevel = data.spellCooldownUpgradeLevel;
                this.expBoostUpgradeLevel = data.expBoostUpgradeLevel;
        }

        public void SaveData(ref GameData data)
        {
                data.coinTotal = this.coinTotal;

                data.fortressUpgradeLevel = this.fortressUpgradeLevel;
                data.attackSpeedUpgradeLevel = this.attackSpeedUpgradeLevel;
                data.spellCooldownUpgradeLevel= this.spellCooldownUpgradeLevel;
                data.expBoostUpgradeLevel = this.expBoostUpgradeLevel;
        }

        private void Start()
        {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();
        }

        private void Update()
        {
                coinCounterText.text = coinTotal.ToString();
                fortressUpgradeLevelText.text = "Add 1000 HP Level " + fortressUpgradeLevel;
                attackSpeedUpgradeLevelText.text = "Add x2 Attack Speed Level " + attackSpeedUpgradeLevel;
                cooldownUpgradeLevelText.text = "Reduce Cooldowns 20% Level " +spellCooldownUpgradeLevel;
                expBoostUpgradeLevelText.text = "x2 Experience Boost Level " +expBoostUpgradeLevel;
        }

        public void FortressUpgrade()
        {
                if (coinTotal >= 100)
                {
                        coinTotal -= 100;
                        fortressUpgradeLevel++;
                }
        }

        public void AttackSpeed()
        {
                if (coinTotal >= 100)
                {
                        coinTotal -= 100;
                        attackSpeedUpgradeLevel++;
                }
        }

        public void SpellCoolDown()
        {
                if (coinTotal >= 100)
                {
                        coinTotal -= 100;
                        spellCooldownUpgradeLevel++;
                }
        }

        public void ExpBoost()
        {
                if (coinTotal >= 100)
                {
                        coinTotal -= 100;
                        expBoostUpgradeLevel++;
                }
        }
}
