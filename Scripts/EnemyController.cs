using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
        Animator anim;

        [SerializeField] private float moveSpeed;

        [SerializeField] private float attackSpeed;
        [SerializeField] private float meleeDamageDelay;
        [SerializeField] private float attackSpeedCountdown;
        [SerializeField] private bool rangeAttacker;
        [SerializeField] private bool impactSmoke;
        [SerializeField] private GameObject smokeObject;

        [SerializeField] private float experiencePoints;
        [SerializeField] private float experiencePointsMultiplier;
        [SerializeField] private int sortingOrderNumber;
        [SerializeField] private int currentGameLevel;

        [SerializeField] private string debuffType;
        [SerializeField] Transform debuffPosition;

        [SerializeField] private AudioSource enemyDeath;

        public List<GameObject> debuffs = new List<GameObject>();
        public List<GameObject> debuffsInstantiated = new List<GameObject>();
        public List<GameObject> arrowsTargeting = new List<GameObject>();
        public List<GameObject> enemyList = new List<GameObject>();
        public List<int> enemyDamageList = new List<int>();

        EnemyRangeAttack rangeAttack;
        Damageable damageable;

        private int characterIndex;
        private float intdamage;

        private bool attacking;
        public bool lockedOn = false;
        private bool expAdded = false;
        public bool debuffAdded = false;

        private int currentLevel = 0;

        #region Properties
        public int SortingOrderNumber
        {
                get
                {
                        return sortingOrderNumber;
                }
                set
                {
                        sortingOrderNumber = value;
                }
        }

        public string DebuffType
        {
                get
                {
                        return debuffType;
                }
                set
                {
                        debuffType = value;
                }
        }

        public float ExpPointsGained
        {
                get
                {
                        return experiencePoints;
                }
        }

        public bool LockedOn
        {
                get
                {
                        return lockedOn;
                }
                set
                {
                        lockedOn = value;
                }
        }

        public float MoveSpeed
        {
                get
                {
                        return moveSpeed;
                }
                set
                {
                        moveSpeed = value;
                }
        }

        public float Damage
        {
                get
                {
                        return intdamage;
                }
                set
                {
                        intdamage = value;
                }
        }
        #endregion

        private void Awake()
        {
                anim = GetComponent<Animator>();
                rangeAttack = GetComponent<EnemyRangeAttack>();
        }

        private void Start()
        {
                experiencePointsMultiplier = GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().ExpBoostLevel;
                currentLevel = GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().CurrentLevel;

                enemyDamageList.Add(25);
                enemyDamageList.Add(25);
                enemyDamageList.Add(250);
                enemyDamageList.Add(35);
                enemyDamageList.Add(50);
                enemyDamageList.Add(40);
                enemyDamageList.Add(40);
                enemyDamageList.Add(75);
                enemyDamageList.Add(50);
                enemyDamageList.Add(55);
                enemyDamageList.Add(35);

                damageable = GetComponent<Damageable>();

                sortingOrderNumber = GetComponent<SpriteRenderer>().sortingOrder;

                #region Setting Character Index
                if (this.gameObject.name == "BatArmyBomb(Clone)")
                {
                        characterIndex = 0;
                }
                else if (this.gameObject.name == "BatSword(Clone)")
                {
                        characterIndex = 1;
                }
                else if (this.gameObject.name == "BigBoss(Clone)")
                {
                        characterIndex = 2;
                }
                else if (this.gameObject.name == "BombThrower(Clone)")
                {
                        characterIndex = 3;
                }
                else if (this.gameObject.name == "Giant(Clone)")
                {
                        characterIndex = 4;
                }
                else if (this.gameObject.name == "Onager(Clone)")
                {
                        characterIndex = 5;
                }
                else if (this.gameObject.name == "ShieldMan(Clone)")
                {
                        characterIndex = 6;
                }
                else if (this.gameObject.name == "SkullStone(Clone)")
                {
                        characterIndex = 7;
                }
                else if (this.gameObject.name == "Spearman(Clone)")
                {
                        characterIndex = 8;
                }
                else if (this.gameObject.name == "Warrior(Clone)")
                {
                        characterIndex = 9;
                }
                else if (this.gameObject.name == "Witch(Clone)")
                {
                        characterIndex = 10;
                }
                #endregion                

                for (int i = 0; i < enemyList.Count; i++)
                {
                        if (i == characterIndex)
                        {
                                if (currentGameLevel < 1)
                                {
                                        intdamage = (enemyDamageList[i] * 1);
                                }
                                else if (currentGameLevel >= 1)
                                {
                                        intdamage = (enemyDamageList[i] * 1.25f);
                                }
                        }
                }
        }

        private void Update()
        {
                if (attacking && !anim.GetBool("isFrozen"))
                {
                        attackSpeedCountdown -= Time.deltaTime;
                        if (attackSpeedCountdown <= 0)
                        {
                                anim.SetTrigger("attack");
                                if (rangeAttacker)
                                {
                                        rangeAttack.RangeAttack(intdamage, sortingOrderNumber);
                                }
                                else if (!rangeAttacker)
                                {
                                        StartCoroutine(Delay());
                                        IEnumerator Delay()
                                        {
                                                yield return new WaitForSeconds(meleeDamageDelay);
                                                if (impactSmoke)
                                                {
                                                        smokeObject.GetComponent<Animator>().SetTrigger("smoke");
                                                }
                                                GameObject.FindGameObjectWithTag("Fortress").GetComponent<Damageable>().OnHit(intdamage, "melee");
                                        }
                                }
                                attackSpeedCountdown = attackSpeed;
                        }
                }

                if (damageable.Health <= 0 && !expAdded)
                {
                        enemyDeath.Play();
                        expAdded = true;
                        ExperiencePointsAward();
                        GameObject kills = GameObject.Find("SpawnManager");
                        kills.GetComponent<EnemySpawner>().killCount.Add(this.gameObject);
                        kills.GetComponent<EnemySpawner>().currentEnemiesRemaining.RemoveAt(0);
                        GameObject expMan = GameObject.FindGameObjectWithTag("ExpManager");
                        expMan.GetComponent<ExperienceManager>().AddExp(experiencePoints);
                        for (int i = 0; i < arrowsTargeting.Count; i++)
                        {
                                Destroy(arrowsTargeting[i]);
                                StartCoroutine(Delay());
                                IEnumerator Delay()
                                {
                                        yield return new WaitForSeconds(0.8f);
                                        Destroy(this.gameObject);
                                }
                        }
                }
                if (debuffType != null)
                {
                        if (debuffType == "Burn" && !debuffAdded && debuffsInstantiated.Count < 1)
                        {
                                GameObject burnDebuffInstance = Instantiate(debuffs[0], debuffPosition.position, Quaternion.identity);
                                burnDebuffInstance.transform.parent = transform;
                                debuffsInstantiated.Add(burnDebuffInstance);
                                debuffAdded = true;
                        }
                        else if (debuffType == "Cursed" && !debuffAdded && debuffsInstantiated.Count < 1)
                        {
                                GameObject cursedDebuffInstance = Instantiate(debuffs[1], debuffPosition.position, Quaternion.identity);
                                cursedDebuffInstance.transform.parent = transform;
                                debuffsInstantiated.Add(cursedDebuffInstance);
                                debuffAdded = true;
                        }
                        else if (debuffType == "Poison" && !debuffAdded && debuffsInstantiated.Count < 1)
                        {
                                GameObject poisonDebuffInstance = Instantiate(debuffs[2], debuffPosition.position, Quaternion.identity);
                                poisonDebuffInstance.transform.parent = transform;
                                debuffsInstantiated.Add(poisonDebuffInstance);
                                debuffAdded = true;
                        }
                        else if (debuffType == "Slowed" && !debuffAdded && debuffsInstantiated.Count < 1)
                        {
                                GameObject slowedDebuffInstance = Instantiate(debuffs[3], debuffPosition.position, Quaternion.identity);
                                slowedDebuffInstance.transform.parent = transform;
                                debuffsInstantiated.Add(slowedDebuffInstance);
                                debuffAdded = true;
                        }
                        else if (debuffType == "none")
                        {
                                foreach (var debuff in debuffsInstantiated)
                                {
                                        Destroy(debuff);
                                }
                                debuffsInstantiated.Clear();
                                debuffAdded = false;
                        }
                }
        }

        private void FixedUpdate()
        {
                if (!attacking && anim.GetBool("isAlive"))
                {
                        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision != null)
                {
                        if (collision.CompareTag("Fortress") && anim.GetBool("isAlive"))
                        {
                                attacking = true;
                                anim.SetTrigger("attack");
                        }
                }
        }

        public void ExperiencePointsAward()
        {
                if (this.gameObject.name == "BatArmyBomb(Clone)")
                {
                        experiencePoints = 5 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "BatSword(Clone)")
                {
                        experiencePoints = 5 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "BigBoss(Clone)")
                {
                        experiencePoints = 250 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "BombThrower(Clone)")
                {
                        experiencePoints = 15 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "Giant(Clone)")
                {
                        experiencePoints = 25 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "Onager(Clone)")
                {
                        experiencePoints = 15 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "ShieldMan(Clone)")
                {
                        experiencePoints = 15 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "SkullStone(Clone)")
                {
                        experiencePoints = 25 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "Spearman(Clone)")
                {
                        experiencePoints = 10 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "Warrior(Clone)")
                {
                        experiencePoints = 15 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else if (this.gameObject.name == "Witch(Clone)")
                {
                        experiencePoints = 25 * experiencePointsMultiplier * (currentLevel + 1);
                }
                else
                {
                        Debug.Log("Enemy name not found." + this.name);
                }
        }
}
