using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityScreenManager : MonoBehaviour, IDataPersistence
{
        [Header("Saved Data")]
        [SerializeField] private int ironArrowUpgrade = 1;
        [SerializeField] private int fireArrowUpgrade = 0;
        [SerializeField] private int iceArrowUpgrade = 0;
        [SerializeField] private int poisonArrowUpgrade = 0;
        [SerializeField] private int lightArrowUpgrade = 0;
        [SerializeField] private int darkArrowUpgrade = 0;
        [SerializeField] private int level;

        [Header("Level Up Boxes")]
        [SerializeField] private Sprite greenBox;
        [SerializeField] public List<Image> ironblackBoxes = new List<Image>();
        [SerializeField] public List<Image> fireblackBoxes = new List<Image>();
        [SerializeField] public List<Image> iceblackBoxes = new List<Image>();
        [SerializeField] public List<Image> poisonblackBoxes = new List<Image>();
        [SerializeField] public List<Image> lightblackBoxes = new List<Image>();
        [SerializeField] public List<Image> darkblackBoxes = new List<Image>();
        [SerializeField] public List<Image> iceSpellblackBoxes = new List<Image>();
        [SerializeField] public List<Image> lightningSpellblackBoxes = new List<Image>();
        [SerializeField] public List<Image> fireballSpellblackBoxes = new List<Image>();
        [SerializeField] private TextMeshProUGUI abilityPointsToSpend;
        [SerializeField] private TextMeshProUGUI coinTotalText;

        [Header("Level Up Buttons")]
        [SerializeField] private Button iron;
        [SerializeField] private Button ice;
        [SerializeField] private Button fire;
        [SerializeField] private Button dark;
        [SerializeField] private Button poison;
        [SerializeField] private Button lightButton;

        [SerializeField] private Button iceSpellButton;
        [SerializeField] private Button lightningSpellButton;
        [SerializeField] private Button fireballSpellButton;
        [SerializeField] private GameObject iceSpellLevelUp;
        [SerializeField] private GameObject lightningSpellLevelUp;
        [SerializeField] private GameObject fireballSpellLevelUp;
        [SerializeField] private GameObject fireballDisableButton;
        [SerializeField] private GameObject lightningDisableButton;
        [SerializeField] private GameObject iceDisableButton;

        [Header("Spell Info")]
        [SerializeField] private GameObject iceSpellUnlock;
        [SerializeField] private GameObject lightningSpellUnlock;
        [SerializeField] private GameObject fireballSpellUnlock;
        [SerializeField] private int iceSpellLevel;
        [SerializeField] private int lightningSpellLevel;
        [SerializeField] private int fireballSpellLevel;

        private int coinTotal;
        private int spentPoints;
        private int pointsAvailable;
        private bool iceSpellUnlocked = false;
        private bool lightningSpellUnlocked = false;
        private bool fireballSpellUnlocked = false;

        public void LoadData(GameData data)
        {
                this.ironArrowUpgrade = data.ironArrowUpgrade;
                this.fireArrowUpgrade = data.fireArrowUpgrade;
                this.iceArrowUpgrade = data.iceArrowUpgrade;
                this.poisonArrowUpgrade = data.poisonArrowUpgrade;
                this.lightArrowUpgrade = data.lightArrowUpgrade;
                this.darkArrowUpgrade = data.darkArrowUpgrade;
                this.iceSpellLevel = data.iceSpellLevel;
                this.lightningSpellLevel = data.lightningSpellLevel;
                this.fireballSpellLevel = data.fireballSpellLevel;
                this.level = data.currentLevel;
                this.coinTotal = data.coinTotal;
                this.iceSpellUnlocked = data.iceSpellUnlocked;
                this.lightningSpellUnlocked = data.lightningSpellUnlocked;
                this.fireballSpellUnlocked = data.fireballSpellUnlocked;
                this.spentPoints = data.spentPoints;

        }

        public void SaveData(ref GameData data)
        {
                data.ironArrowUpgrade = this.ironArrowUpgrade;
                data.fireArrowUpgrade = this.fireArrowUpgrade;
                data.iceArrowUpgrade = this.iceArrowUpgrade;
                data.poisonArrowUpgrade = this.poisonArrowUpgrade;
                data.lightArrowUpgrade = this.lightArrowUpgrade;
                data.darkArrowUpgrade = this.darkArrowUpgrade;
                data.iceSpellLevel = this.iceSpellLevel;
                data.lightningSpellLevel = this.lightningSpellLevel;
                data.fireballSpellLevel = this.fireballSpellLevel;
                data.currentLevel = this.level;
                data.coinTotal = this.coinTotal;
                data.iceSpellUnlocked = this.iceSpellUnlocked;
                data.lightningSpellUnlocked = this.lightningSpellUnlocked;
                data.fireballSpellUnlocked = this.fireballSpellUnlocked;
                data.spentPoints = this.spentPoints;
        }

        #region Start Method
        private void Start()
        {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();

                CheckIceSpell();
                CheckLightningSpell();
                CheckFireballSpell();

                if (ironArrowUpgrade > 0)
                {
                        for (int i = 0; i < ironArrowUpgrade; i++)
                        {
                                ironblackBoxes[i].sprite = greenBox;
                        }
                        if (ironArrowUpgrade == 10)
                        {
                                iron.interactable = false;
                        }
                        else if (ironArrowUpgrade < 10)
                        {
                                iron.interactable = true;
                        }
                }

                if (fireArrowUpgrade > 0)
                {
                        for (int i = 0; i < fireArrowUpgrade; i++)
                        {
                                fireblackBoxes[i].sprite = greenBox;
                        }
                        if (fireArrowUpgrade == 10)
                        {
                                fire.interactable = false;
                        }
                        else if (fireArrowUpgrade < 10)
                        {
                                fire.interactable = true;
                        }
                }

                if (iceArrowUpgrade > 0)
                {
                        for (int i = 0; i < iceArrowUpgrade; i++)
                        {
                                iceblackBoxes[i].sprite = greenBox;
                        }
                        if (iceArrowUpgrade == 10)
                        {
                                ice.interactable = false;
                        }
                        else if (iceArrowUpgrade < 10)
                        {
                                ice.interactable = true;
                        }
                }

                if (poisonArrowUpgrade > 0)
                {
                        for (int i = 0; i < poisonArrowUpgrade; i++)
                        {
                                poisonblackBoxes[i].sprite = greenBox;
                        }
                        if (poisonArrowUpgrade == 10)
                        {
                                poison.interactable = false;
                        }
                        else if (poisonArrowUpgrade < 10)
                        {
                                poison.interactable = true;
                        }
                }

                if (lightArrowUpgrade > 0)
                {
                        for (int i = 0; i < lightArrowUpgrade; i++)
                        {
                                lightblackBoxes[i].sprite = greenBox;
                        }
                        if (lightArrowUpgrade == 10)
                        {
                                lightButton.interactable = false;
                        }
                        else if (lightArrowUpgrade < 10)
                        {
                                lightButton.interactable = true;
                        }
                }

                if (darkArrowUpgrade > 0)
                {
                        for (int i = 0; i < darkArrowUpgrade; i++)
                        {
                                darkblackBoxes[i].sprite = greenBox;
                        }
                        if (darkArrowUpgrade == 10)
                        {
                                dark.interactable = false;
                        }
                        else if (darkArrowUpgrade < 10)
                        {
                                dark.interactable = true;
                        }
                }

                if (fireballSpellLevel > 0)
                {
                        for (int i = 0; i<fireballSpellLevel; i++)
                        {
                                fireballSpellblackBoxes[i].sprite = greenBox;
                        }
                        if (fireballSpellLevel == 10)
                        {
                                fireballSpellButton.interactable = false;
                        }
                        else if (fireballSpellLevel < 10)
                        {
                                fireballSpellButton.interactable= true;
                        }
                }

                if (iceSpellLevel > 0)
                {
                        for (int i = 0; i<iceSpellLevel; i++)
                        {
                                iceSpellblackBoxes[i].sprite = greenBox;
                        }
                        if (iceSpellLevel == 10)
                        {
                                iceSpellButton.interactable = false;
                        }
                        else if (iceSpellLevel < 10)
                        {
                                iceSpellButton.interactable= true;
                        }
                }

                if (lightningSpellLevel > 0)
                {
                        for (int i = 0; i<lightningSpellLevel; i++)
                        {
                                lightningSpellblackBoxes[i].sprite = greenBox;
                        }
                        if (lightningSpellLevel == 10)
                        {
                                lightningSpellButton.interactable = false;
                        }
                        else if (lightningSpellLevel < 10)
                        {
                                lightningSpellButton.interactable= true;
                        }
                }
        }
        #endregion        

        private void Update()
        {
                if (level ==  0)
                {
                        abilityPointsToSpend.text = ((level) - spentPoints).ToString();
                }
                else if (level > 0)
                {
                        abilityPointsToSpend.text = ((level - 1) - spentPoints).ToString();
                }

                coinTotalText.text = coinTotal.ToString();
                pointsAvailable = (level - 1) - spentPoints;
        }

        #region Arrow Upgrades
        public void IronArrow()
        {
                if (ironArrowUpgrade < 10 && pointsAvailable > 0)
                {
                        ironblackBoxes[ironArrowUpgrade].sprite = greenBox;
                        ironArrowUpgrade++;
                        spentPoints++;
                        if (ironArrowUpgrade == 10)
                        {
                                iron.interactable = false;
                        }
                }
        }

        public void FireArrow()
        {
                if (fireArrowUpgrade < 10 && pointsAvailable > 0)
                {
                        fireblackBoxes[fireArrowUpgrade].sprite = greenBox;
                        fireArrowUpgrade++;
                        spentPoints++;
                        if (fireArrowUpgrade == 10)
                        {
                                fire.interactable = false;
                        }
                }
        }

        public void IceArrow()
        {
                if (iceArrowUpgrade < 10 && pointsAvailable > 0)
                {
                        iceblackBoxes[iceArrowUpgrade].sprite = greenBox;
                        iceArrowUpgrade++;
                        spentPoints++;
                        if (iceArrowUpgrade == 10)
                        {
                                ice.interactable = false;
                        }
                }
        }

        public void PoisonArrow()
        {
                if (poisonArrowUpgrade < 10 && pointsAvailable > 0)
                {
                        poisonblackBoxes[poisonArrowUpgrade].sprite = greenBox;
                        poisonArrowUpgrade++;
                        spentPoints++;
                        if (poisonArrowUpgrade == 10)
                        {
                                poison.interactable = false;
                        }
                }
        }

        public void LightArrow()
        {
                if (lightArrowUpgrade < 10 && pointsAvailable > 0)
                {
                        lightblackBoxes[lightArrowUpgrade].sprite = greenBox;
                        lightArrowUpgrade++;
                        spentPoints++;
                        if (lightArrowUpgrade == 10)
                        {
                                lightButton.interactable = false;
                        }
                }
        }

        public void DarkArrow()
        {
                if (darkArrowUpgrade < 10 && pointsAvailable > 0)
                {
                        darkblackBoxes[darkArrowUpgrade].sprite = greenBox;
                        darkArrowUpgrade++;
                        spentPoints++;
                        if (darkArrowUpgrade == 10)
                        {
                                dark.interactable = false;
                        }
                }
        }
        #endregion        

        public void IceSpell()
        {
                if (iceSpellLevel < 10 && pointsAvailable > 0)
                {
                        iceSpellblackBoxes[iceSpellLevel].sprite = greenBox;
                        iceSpellLevel++;
                        spentPoints++;
                        if (iceSpellLevel == 10)
                        {
                                iceSpellButton.interactable = false;
                        }
                }
        }

        public void LightningSpell()
        {
                if (lightningSpellLevel < 10 && pointsAvailable > 0)
                {
                        lightningSpellblackBoxes[lightningSpellLevel].sprite = greenBox;
                        lightningSpellLevel++;
                        spentPoints++;
                        if (lightningSpellLevel == 10)
                        {
                                lightningSpellButton.interactable = false;
                        }
                }
        }

        public void FireballSpell()
        {
                if (fireballSpellLevel < 10 && pointsAvailable > 0)
                {
                        fireballSpellblackBoxes[fireballSpellLevel].sprite = greenBox;
                        fireballSpellLevel++;
                        spentPoints++;
                        if (fireballSpellLevel == 10)
                        {
                                fireballSpellButton.interactable = false;
                        }
                }
        }

        public void CheckIceSpell()
        {
                if (iceSpellUnlocked)
                {
                        iceSpellUnlock.SetActive(false);
                        iceSpellLevelUp.SetActive(true);
                        iceDisableButton.SetActive(false);
                }
                else if (!iceSpellUnlocked)
                {
                        iceSpellUnlock.SetActive(true);
                        iceSpellLevelUp.SetActive(false);
                        iceDisableButton.SetActive(true);
                }
        }

        public void CheckLightningSpell()
        {
                if (lightningSpellUnlocked)
                {
                        lightningSpellUnlock.SetActive(false);
                        lightningSpellLevelUp.SetActive(true);
                        lightningDisableButton.SetActive(false);
                }
                else if (!lightningSpellUnlocked)
                {
                        lightningSpellUnlock.SetActive(true);
                        lightningSpellLevelUp.SetActive(false);
                        lightningDisableButton.SetActive(true);
                }
        }

        public void CheckFireballSpell()
        {
                if (fireballSpellUnlocked)
                {
                        fireballSpellUnlock.SetActive(false);
                        fireballSpellLevelUp.SetActive(true);
                        fireballDisableButton.SetActive(false);
                }
                else if (!fireballSpellUnlocked)
                {
                        fireballSpellUnlock.SetActive(true);
                        fireballSpellLevelUp.SetActive(false);
                        fireballDisableButton.SetActive(true);
                        fireballDisableButton.SetActive(true);
                }
        }

        public void UnlockIceSpell()
        {
                if (coinTotal >= 150 && !iceSpellUnlocked)
                {
                        coinTotal -= 150;
                        iceSpellUnlocked = true;
                        iceSpellUnlock.SetActive(false);
                        iceSpellLevelUp.SetActive(true);
                        iceDisableButton.SetActive(false);
                }
        }

        public void UnlockLightningSpell()
        {
                if (coinTotal >= 150 && !lightningSpellUnlocked)
                {
                        coinTotal -= 150;
                        lightningSpellUnlocked = true;
                        lightningSpellUnlock.SetActive(false);
                        lightningSpellLevelUp.SetActive(true);
                        lightningDisableButton.SetActive(false);
                }
        }

        public void UnlockFireballSpell()
        {
                if (coinTotal >= 150 && !fireballSpellUnlocked)
                {
                        coinTotal -= 150;
                        fireballSpellUnlocked = true;
                        fireballSpellUnlock.SetActive(false);
                        fireballSpellLevelUp.SetActive(true);
                        fireballDisableButton.SetActive(false);
                }
        }
}
