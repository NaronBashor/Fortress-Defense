using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DPS : MonoBehaviour
{
        [SerializeField] private float initalStartTime = 5f;
        private float startTime;
        private float damagePerSecond;
        private float totalDamage;
        private float damagePerSecondDisplay;
        public List<float> dps = new List<float>();

        [SerializeField] private TextMeshProUGUI dpsCounterText;

        private void Start()
        {
                startTime = initalStartTime;
        }

        private void Update()
        {
                startTime -= Time.deltaTime;
                if (startTime <= 0f)
                {
                        for (int i = 0; i < dps.Count; i++)
                        {
                                damagePerSecond += dps[i];
                        }
                        totalDamage = damagePerSecond;
                        damagePerSecondDisplay = totalDamage / 5;
                        dps.Clear();
                        damagePerSecond = 0f;
                        startTime = 5f;
                }

                dpsCounterText.text = damagePerSecondDisplay.ToString() + " / Sec";
        }
}
