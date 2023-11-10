using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArcherSkinManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private TextMeshProUGUI coinTotalText;

        [SerializeField] private GameObject archerOneCost;
        [SerializeField] private GameObject archerTwoCost;
        [SerializeField] private GameObject archerThreeCost;
        [SerializeField] private GameObject archerFourCost;
        [SerializeField] private GameObject archerFiveCost;
        [SerializeField] private GameObject archerSixCost;
        [SerializeField] private GameObject archerSevenCost;
        [SerializeField] private GameObject archerEightCost;

        [SerializeField] private GameObject archerOneCheckMark;
        [SerializeField] private GameObject archerTwoCheckMark;
        [SerializeField] private GameObject archerThreeCheckMark;
        [SerializeField] private GameObject archerFourCheckMark;
        [SerializeField] private GameObject archerFiveCheckMark;
        [SerializeField] private GameObject archerSixCheckMark;
        [SerializeField] private GameObject archerSevenCheckMark;
        [SerializeField] private GameObject archerEightCheckMark;

        public List<GameObject> archerEquipped = new List<GameObject>();

        public int coinTotal;

        private int archerSelected = 0;

        private bool archerOneUnlocked = false;
        private bool archerTwoUnlocked = false;
        private bool archerThreeUnlocked = false;
        private bool archerFourUnlocked = false;
        private bool archerFiveUnlocked = false;
        private bool archerSixUnlocked = false;
        private bool archerSevenUnlocked = false;
        private bool archerEightUnlocked = false;

        public void LoadData(GameData data)
        {
                this.coinTotal = data.coinTotal;

                this.archerSelected = data.archerSelected;

                this.archerOneUnlocked = data.archerOneUnlocked;
                this.archerTwoUnlocked = data.archerTwoUnlocked;
                this.archerThreeUnlocked = data.archerThreeUnlocked;
                this.archerFourUnlocked = data.archerFourUnlocked;
                this.archerFiveUnlocked = data.archerFiveUnlocked;
                this.archerSixUnlocked = data.archerSixUnlocked;
                this.archerSevenUnlocked = data.archerSevenUnlocked;
                this.archerEightUnlocked = data.archerEightUnlocked;
        }

        public void SaveData(ref GameData data)
        {
                data.coinTotal = this.coinTotal;

                data.archerSelected = this.archerSelected;

                data.archerOneUnlocked = this.archerOneUnlocked;
                data.archerTwoUnlocked = this.archerTwoUnlocked;
                data.archerThreeUnlocked = this.archerThreeUnlocked;
                data.archerFourUnlocked = this.archerFourUnlocked;
                data.archerFiveUnlocked = this.archerFiveUnlocked;
                data.archerSixUnlocked = this.archerSixUnlocked;
                data.archerSevenUnlocked = this.archerSevenUnlocked;
                data.archerEightUnlocked = this.archerEightUnlocked;
        }

        private void Start()
        {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();

                if (archerOneUnlocked)
                {
                        archerOneCost.SetActive(false);
                        archerOneCheckMark.SetActive(true);
                }
                else if (!archerOneUnlocked)
                {
                        archerOneCost.SetActive(true);
                        archerOneCheckMark.SetActive(false);
                }

                if (archerTwoUnlocked)
                {
                        archerTwoCost.SetActive(false);
                        archerTwoCheckMark.SetActive(true);
                }
                else if (!archerTwoUnlocked)
                {
                        archerTwoCost.SetActive(true);
                        archerTwoCheckMark.SetActive(false);
                }

                if (archerThreeUnlocked)
                {
                        archerThreeCost.SetActive(false);
                        archerThreeCheckMark.SetActive(true);
                }
                else if (!archerThreeUnlocked)
                {
                        archerThreeCost.SetActive(true);
                        archerThreeCheckMark.SetActive(false);
                }

                if (archerFourUnlocked)
                {
                        archerFourCost.SetActive(false);
                        archerFourCheckMark.SetActive(true);
                }
                else if (!archerFourUnlocked)
                {
                        archerFourCost.SetActive(true);
                        archerFourCheckMark.SetActive(false);
                }

                if (archerFiveUnlocked)
                {
                        archerFiveCost.SetActive(false);
                        archerFiveCheckMark.SetActive(true);
                }
                else if (!archerFiveUnlocked)
                {
                        archerFiveCost.SetActive(true);
                        archerFiveCheckMark.SetActive(false);
                }

                if (archerSixUnlocked)
                {
                        archerSixCost.SetActive(false);
                        archerSixCheckMark.SetActive(true);
                }
                else if (!archerSixUnlocked)
                {
                        archerSixCost.SetActive(true);
                        archerSixCheckMark.SetActive(false);
                }

                if (archerSevenUnlocked)
                {
                        archerSevenCost.SetActive(false);
                        archerSevenCheckMark.SetActive(true);
                }
                else if (!archerSevenUnlocked)
                {
                        archerSevenCost.SetActive(true);
                        archerSevenCheckMark.SetActive(false);
                }

                if (archerEightUnlocked)
                {
                        archerEightCost.SetActive(false);
                        archerEightCheckMark.SetActive(true);
                }
                else if (!archerEightUnlocked)
                {
                        archerEightCost.SetActive(true);
                        archerEightCheckMark.SetActive(false);
                }
        }

        private void Update()
        {
                coinTotalText.text = coinTotal.ToString();

                if (archerOneUnlocked)
                {
                        archerOneCost.SetActive(false);
                        archerOneCheckMark.SetActive(true);
                }
                else if (!archerOneUnlocked)
                {
                        archerOneCost.SetActive(true);
                        archerOneCheckMark.SetActive(false);
                }

                if (archerTwoUnlocked)
                {
                        archerTwoCost.SetActive(false);
                        archerTwoCheckMark.SetActive(true);
                }
                else if (!archerTwoUnlocked)
                {
                        archerTwoCost.SetActive(true);
                        archerTwoCheckMark.SetActive(false);
                }

                if (archerThreeUnlocked)
                {
                        archerThreeCost.SetActive(false);
                        archerThreeCheckMark.SetActive(true);
                }
                else if (!archerThreeUnlocked)
                {
                        archerThreeCost.SetActive(true);
                        archerThreeCheckMark.SetActive(false);
                }

                if (archerFourUnlocked)
                {
                        archerFourCost.SetActive(false);
                        archerFourCheckMark.SetActive(true);
                }
                else if (!archerFourUnlocked)
                {
                        archerFourCost.SetActive(true);
                        archerFourCheckMark.SetActive(false);
                }

                if (archerFiveUnlocked)
                {
                        archerFiveCost.SetActive(false);
                        archerFiveCheckMark.SetActive(true);
                }
                else if (!archerFiveUnlocked)
                {
                        archerFiveCost.SetActive(true);
                        archerFiveCheckMark.SetActive(false);
                }

                if (archerSixUnlocked)
                {
                        archerSixCost.SetActive(false);
                        archerSixCheckMark.SetActive(true);
                }
                else if (!archerSixUnlocked)
                {
                        archerSixCost.SetActive(true);
                        archerSixCheckMark.SetActive(false);
                }

                if (archerSevenUnlocked)
                {
                        archerSevenCost.SetActive(false);
                        archerSevenCheckMark.SetActive(true);
                }
                else if (!archerSevenUnlocked)
                {
                        archerSevenCost.SetActive(true);
                        archerSevenCheckMark.SetActive(false);
                }

                if (archerEightUnlocked)
                {
                        archerEightCost.SetActive(false);
                        archerEightCheckMark.SetActive(true);
                }
                else if (!archerEightUnlocked)
                {
                        archerEightCost.SetActive(true);
                        archerEightCheckMark.SetActive(false);
                }

                for (int i = 0; i < archerEquipped.Count; i++)
                {
                        archerEquipped[i].SetActive(false);
                }
                if (archerSelected > 0)
                {
                        archerEquipped[archerSelected - 1].SetActive(true);
                }
        }

        public void ArcherOne()
        {
                if (coinTotal >= 500 && !archerOneUnlocked)
                {
                        archerOneUnlocked = true;
                        archerSelected = 1;
                        coinTotal -= 500;
                }
                else if (archerOneUnlocked)
                {
                        archerSelected = 1;
                }
        }

        public void ArcherTwo()
        {
                if (coinTotal >= 500 && !archerTwoUnlocked)
                {
                        archerTwoUnlocked = true;
                        archerSelected = 2;
                        coinTotal -= 500;
                }
                else if (archerTwoUnlocked)
                {
                        archerSelected = 2;
                }
        }

        public void ArcherThree()
        {
                if (coinTotal >= 500 && !archerThreeUnlocked)
                {
                        archerThreeUnlocked = true;
                        archerSelected = 3;
                        coinTotal -= 500;
                }
                else if (archerThreeUnlocked)
                {
                        archerSelected = 3;
                }
        }

        public void ArcherFour()
        {
                if (coinTotal >= 500 && !archerFourUnlocked)
                {
                        archerFourUnlocked = true;
                        archerSelected = 4;
                        coinTotal -= 500;
                }
                else if (archerFourUnlocked)
                {
                        archerSelected = 4;
                }
        }

        public void ArcherFive()
        {
                if (coinTotal >= 500 && !archerFiveUnlocked)
                {
                        archerFiveUnlocked = true;
                        archerSelected = 5;
                        coinTotal -= 500;
                }
                else if (archerFiveUnlocked)
                {
                        archerSelected = 5;
                }
        }

        public void ArcherSix()
        {
                if (coinTotal >= 500 && !archerSixUnlocked)
                {
                        archerSixUnlocked = true;
                        archerSelected = 6;
                        coinTotal -= 500;
                }
                else if (archerSixUnlocked)
                {
                        archerSelected = 6;
                }
        }

        public void ArcherSeven()
        {
                if (coinTotal >= 500 && !archerSevenUnlocked)
                {
                        archerSevenUnlocked = true;
                        archerSelected = 7;
                        coinTotal -= 500;
                }
                else if (archerSevenUnlocked)
                {
                        archerSelected = 7;
                }
        }

        public void ArcherEight()
        {
                if (coinTotal >= 500 && !archerEightUnlocked)
                {
                        archerEightUnlocked = true;
                        archerSelected = 8;
                        coinTotal -= 500;
                }
                else if (archerEightUnlocked)
                {
                        archerSelected = 8;
                }
        }
}
