using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour, IDataPersistence
{
        [SerializeField] private TextMeshProUGUI coinCount;

        public int coinTotal;

        public void LoadData(GameData data)
        {
                this.coinTotal = data.coinTotal;
        }

        public void SaveData(ref GameData data)
        {
                data.coinTotal = this.coinTotal;
        }

        private void Start()
        {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().PlayMusic();
        }

        private void Update()
        {
                coinCount.text = coinTotal.ToString();
        }

        public void HundredCoins()
        {
                coinTotal += 100;
        }

        public void ThreeHundredCoins()
        {
                coinTotal += 300;
        }

        public void SevenHundredCoins()
        {
                coinTotal += 700;
        }

        public void ThousandCoins()
        {
                coinTotal += 1000;
        }
}
