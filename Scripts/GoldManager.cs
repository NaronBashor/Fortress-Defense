using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
        GoldManager Instance;

        [SerializeField] private float currentGold;

        public float CurrentGold
        {
                get
                {
                        return currentGold;
                }
                set
                {
                        currentGold = value;
                }
        }

        private void Awake()
        {
                Instance = this;
        }

        public void AddGold(float amount)
        {
                currentGold += amount;
        }

        public void RemoveGold(float amount)
        {
                currentGold -= amount;
        }
}
