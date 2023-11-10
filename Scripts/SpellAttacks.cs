using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellAttacks : MonoBehaviour, IDataPersistence
{
        [SerializeField] private GameObject iceAttackPrefab;
        [SerializeField] private GameObject lightningAttackPrefab;
        [SerializeField] private GameObject fireballAttackPrefab;
        [SerializeField] private Image iceCountdownTimer;
        [SerializeField] private Image lightningCountdownTimer;
        [SerializeField] private Image fireballCountdownTimer;

        [SerializeField] private GameObject iceObject;
        [SerializeField] private GameObject lightningObject;
        [SerializeField] private GameObject fireballObject;
        [SerializeField] private GameObject iceLock;
        [SerializeField] private GameObject lightningLock;

        [SerializeField] private GameObject fireballLock;

        [SerializeField] private GameObject unlockSpellText;

        [SerializeField] private AudioSource lightningSound;
        [SerializeField] private AudioSource iceSound;
        [SerializeField] private AudioSource iceTwoSound;
        [SerializeField] private AudioSource fireballSound;

        [SerializeField] private TextMeshProUGUI iceTimer;
        [SerializeField] private TextMeshProUGUI lightningTimer;
        [SerializeField] private TextMeshProUGUI fireballTimer;

        public List<GameObject> iceAttacks = new List<GameObject>();
        public List<GameObject> lightningAttacks = new List<GameObject>();

        private float end;

        private bool iceAttack = false;
        private bool lightningAttack = false;
        private bool fireballAttack = false;

        private float iceSpellCountDown = 0f;
        private float lightningSpellCountDown = 0f;
        private float fireballSpellCountDown = 0f;

        private bool startIceCountDown = false;
        private bool startLightningCountDown = false;
        private bool startFireballCountDown = false;

        private bool iceSpellUnlocked;
        private bool lightningSpellUnlocked;
        private bool fireballSpellUnlocked;

        private float cooldownLevel;

        public void LoadData(GameData data)
        {
                this.iceSpellUnlocked = data.iceSpellUnlocked;
                this.lightningSpellUnlocked = data.lightningSpellUnlocked;
                this.fireballSpellUnlocked = data.fireballSpellUnlocked;
                this.cooldownLevel = data.spellCooldownUpgradeLevel;
        }

        public void SaveData(ref GameData data)
        {
        }

        private void Start()
        {
                iceSpellCountDown = 0f;
                lightningSpellCountDown = 0f;
                fireballSpellCountDown = 0f;

                iceObject.SetActive(false);
                lightningObject.SetActive(false);
                fireballObject.SetActive(false);

                if (iceSpellUnlocked)
                {
                        iceLock.SetActive(false);
                        unlockSpellText.SetActive(false);
                }
                else if (!iceSpellUnlocked)
                {
                        iceLock.SetActive(true);
                }

                if (lightningSpellUnlocked)
                {
                        lightningLock.SetActive(false);
                        unlockSpellText.SetActive(false);
                }
                else if (!lightningSpellUnlocked)
                {
                        lightningLock.SetActive(true);
                }

                if (fireballSpellUnlocked)
                {
                        fireballLock.SetActive(false);
                        unlockSpellText.SetActive(false);
                }
                else if (!fireballSpellUnlocked)
                {
                        fireballLock.SetActive(true);
                }
        }

        private void Update()
        {
                iceCountdownTimer.fillAmount = iceSpellCountDown / (20 * (Mathf.Pow((1 - .20f), (cooldownLevel - 1))));
                lightningCountdownTimer.fillAmount = lightningSpellCountDown / (20 * (Mathf.Pow((1 - .20f), (cooldownLevel - 1))));
                fireballCountdownTimer.fillAmount = fireballSpellCountDown / (20 * (Mathf.Pow((1 - .20f), (cooldownLevel - 1))));

                iceTimer.text = ((int)iceSpellCountDown).ToString();
                lightningTimer.text = ((int)lightningSpellCountDown).ToString();
                fireballTimer.text = ((int)fireballSpellCountDown).ToString();

                if (startIceCountDown)
                {
                        iceSpellCountDown -= Time.deltaTime;
                        if (iceSpellCountDown <= 0)
                        {
                                startIceCountDown = false;
                                iceObject.SetActive(false);
                        }
                }
                if (startLightningCountDown)
                {
                        lightningSpellCountDown -= Time.deltaTime;
                        if (lightningSpellCountDown <= 0)
                        {
                                startLightningCountDown = false;
                                lightningObject.SetActive(false);
                        }
                }
                if (startFireballCountDown)
                {
                        fireballSpellCountDown -= Time.deltaTime;
                        if (fireballSpellCountDown <= 0)
                        {
                                startFireballCountDown = false;
                                fireballObject.SetActive(false);
                        }
                }
        }

        public void IceAttack()
        {
                if (iceSpellUnlocked && !iceAttack && iceSpellCountDown <= 0)
                {
                        iceSound.Play();
                        iceTwoSound.Play();
                        iceObject.SetActive(true);
                        end = 20 * (Mathf.Pow((1 - .20f), (cooldownLevel - 1)));
                        iceSpellCountDown = end;
                        lightningSpellCountDown = end;
                        fireballSpellCountDown = end;
                        startIceCountDown = true;
                        startLightningCountDown = true;
                        startFireballCountDown = true;
                        iceAttack = true;
                        int numberOfAttacks = Random.Range(4, 7);
                        for (int i = 0; i < numberOfAttacks; i++)
                        {
                                int randomNumberOne = Random.Range(-9, 5);
                                int randomNumberTwo = Random.Range(-5, -1);
                                Vector2 location = new Vector2(randomNumberOne, randomNumberTwo);
                                GameObject iceAttack = Instantiate(iceAttackPrefab, location, Quaternion.identity);
                                iceAttacks.Add(iceAttack);
                        }
                }
                StartCoroutine(Delay());
                IEnumerator Delay()
                {
                        yield return new WaitForSeconds(.8f);
                        iceAttack = false;
                        foreach (GameObject iceAttack in iceAttacks)
                        {
                                Destroy(iceAttack);
                        }
                        iceAttacks.Clear();
                }
        }

        public void LightningAttack()
        {
                if (lightningSpellUnlocked && !lightningAttack && lightningSpellCountDown <=0)
                {
                        lightningSound.Play();
                        lightningObject.SetActive(true);
                        end = 20 * (Mathf.Pow((1 - .20f), (cooldownLevel - 1)));
                        iceSpellCountDown = end;
                        lightningSpellCountDown = end;
                        fireballSpellCountDown = end;
                        startIceCountDown = true;
                        startLightningCountDown = true;
                        startFireballCountDown = true;
                        lightningAttack = true;
                        int numberOfAttacks = Random.Range(4, 6);
                        for (int i = 1; i < numberOfAttacks; i++)
                        {
                                int randomNumberOne = Random.Range(-10, 5);
                                int randomNumberTwo = Random.Range(-5, 2);
                                Vector2 location = new Vector2(randomNumberOne, randomNumberTwo);
                                GameObject lightningAttack = Instantiate(lightningAttackPrefab, location, Quaternion.identity);
                                lightningAttacks.Add(lightningAttack);
                        }
                        StartCoroutine(Delay());
                        IEnumerator Delay()
                        {
                                yield return new WaitForSeconds(.8f);
                                lightningAttack = false;
                                foreach (GameObject lightningAttack in lightningAttacks)
                                {
                                        Destroy(lightningAttack);
                                }
                                lightningAttacks.Clear();
                        }
                }
        }

        public void FireballAttack()
        {
                if (fireballSpellUnlocked && !fireballAttack && fireballSpellCountDown <= 0)
                {
                        fireballSound.Play();
                        fireballObject.SetActive(true);
                        end = 20 * (Mathf.Pow((1 - .20f), (cooldownLevel - 1)));
                        iceSpellCountDown = end;
                        lightningSpellCountDown = end;
                        fireballSpellCountDown = end;
                        startIceCountDown = true;
                        startLightningCountDown = true;
                        startFireballCountDown = true;
                        fireballAttack = true;
                        int numberOfAttacks = Random.Range(4, 7);
                        for (int i = 0; i < numberOfAttacks; i++)
                        {
                                int randomNumberOne = Random.Range(-9, 4);
                                Vector2 location = new Vector2(randomNumberOne, 9);
                                GameObject fireballAttackInstance = Instantiate(fireballAttackPrefab, location, Quaternion.Euler(0, 0, -110));
                                float randomDelayTime = Random.Range(80, 100);
                                float timeDelay = randomDelayTime / 100;
                                StartCoroutine(FireballDelay(timeDelay));
                                IEnumerator FireballDelay(float delayTime)
                                {
                                        yield return new WaitForSeconds(delayTime);
                                        fireballAttackInstance.GetComponent<Animator>().SetTrigger("explode");
                                        fireballAttackInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
                                        fireballAttackInstance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                                        yield return new WaitForSeconds(0.5f);
                                        Destroy(fireballAttackInstance);
                                        fireballAttack = false;
                                }
                        }
                }
        }
}
