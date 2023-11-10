using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArcherManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] public List<GameObject> archers = new List<GameObject>();
        [SerializeField] public List<Transform> archerLocations = new List<Transform>();

        [SerializeField] private GameObject buttonArcherOnePurchased;
        [SerializeField] private GameObject buttonArcherTwoPurchased;

        [SerializeField] private GameObject buttonArcherOne;
        [SerializeField] private GameObject buttonArcherTwo;

        private int locationIndex = 0;
        private int archerSelected = 0;

        private int iceSpellLevel;
        private int lightningSpellLevel;
        private int fireballSpellLevel;
        private int coinTotal;

        private float attackSpeedUpgradeLevel;

        private bool canAdd = true;
        private bool secondArcherPurchased = false;
        private bool thirdArcherPurchased = false;
        private bool secondArcherAdded = false;
        private bool thirdArcherAdded = false;

        public bool allArchersPurchased = false;

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

        public int FireballSpellLevel
        {
                get
                {
                        return fireballSpellLevel;
                }
                set
                {
                        fireballSpellLevel = value;
                }
        }

        public float AttackSpeedUpgradeLevel
        {
                get
                {
                        return attackSpeedUpgradeLevel;
                }
                set
                {
                        attackSpeedUpgradeLevel = value;
                }
        }

        public void LoadData(GameData data)
        {
                this.archerSelected = data.archerSelected;
                this.attackSpeedUpgradeLevel = data.attackSpeedUpgradeLevel;
                this.iceSpellLevel = data.iceSpellLevel;
                this.lightningSpellLevel = data.lightningSpellLevel;
                this.fireballSpellLevel = data.fireballSpellLevel;
                this.coinTotal = data.coinTotal;
                this.secondArcherPurchased = data.secondArcherPurchased;
                this.thirdArcherPurchased = data.thirdArcherPurchased;
                this.allArchersPurchased = data.allArchersPurchased;
        }

        public void SaveData(ref GameData data)
        {
                data.archerSelected = this.archerSelected;
                data.attackSpeedUpgradeLevel = this.attackSpeedUpgradeLevel;
                data.secondArcherPurchased = this.secondArcherPurchased;
                data.thirdArcherPurchased = this.thirdArcherPurchased;
                data.allArchersPurchased = this.allArchersPurchased;
        }

        private void Start()
        {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().StopMusic();
                GameObject archer = Instantiate(archers[archerSelected], archerLocations[locationIndex].position, Quaternion.identity);
                locationIndex++;

                if (secondArcherPurchased)
                {
                        buttonArcherOnePurchased.SetActive(true);
                        buttonArcherOne.SetActive(false);
                }
                else if (!secondArcherPurchased)
                {
                        buttonArcherOnePurchased.SetActive(false);
                        buttonArcherOne.SetActive(true);
                }
                if (thirdArcherPurchased)
                {
                        buttonArcherTwoPurchased.SetActive(true);
                        buttonArcherTwo.SetActive(false);
                }
                else if (!thirdArcherPurchased)
                {
                        buttonArcherTwoPurchased.SetActive(false);
                        buttonArcherTwo.SetActive(true);
                }
        }

        public void Archer()
        {
                if (!secondArcherPurchased && !thirdArcherPurchased && !allArchersPurchased)
                {
                        if (!secondArcherAdded && coinTotal >= 500)
                        {
                                secondArcherAdded = true;
                                secondArcherPurchased = true;
                                buttonArcherOne.SetActive(false);
                                if (canAdd && coinTotal >= 500)
                                {
                                        coinTotal -= 500;
                                        AddArcher();
                                        StartCoroutine(Delay());
                                        IEnumerator Delay()
                                        {
                                                yield return new WaitForSeconds(0.2f);
                                                canAdd = true;
                                        }
                                }
                        }
                }
                else if (secondArcherPurchased && !thirdArcherPurchased && !allArchersPurchased)
                {
                        if (!thirdArcherAdded && coinTotal >= 500)
                        {
                                thirdArcherPurchased = true;
                                allArchersPurchased = true;
                                thirdArcherAdded = true;
                                buttonArcherTwo.SetActive(false);
                                if (canAdd && coinTotal >= 500)
                                {
                                        coinTotal -= 500;
                                        AddArcher();
                                        StartCoroutine(Delay());
                                        IEnumerator Delay()
                                        {
                                                yield return new WaitForSeconds(0.2f);
                                                canAdd = true;
                                        }
                                }
                        }
                }
                else if (allArchersPurchased)
                {
                        AddArcher();
                        StartCoroutine(Delay());
                        IEnumerator Delay()
                        {
                                yield return new WaitForSeconds(0.2f);
                                canAdd = true;
                        }
                }
        }

        public void AddArcher()
        {
                if (locationIndex > 2)
                {
                        Debug.Log("Max amount of archers reached.");
                        return;
                }
                if (locationIndex == 1)
                {
                        buttonArcherOnePurchased.SetActive(false);
                }
                else if (locationIndex == 2)
                {
                        buttonArcherTwoPurchased.SetActive(false);
                }
                canAdd = false;
                GameObject archer = Instantiate(archers[archerSelected], archerLocations[locationIndex].position, Quaternion.identity);
                locationIndex++;
        }
}
