using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ArrowController : MonoBehaviour
{
        SpriteRenderer sprite;

        [Header("Arrow Info")]
        [SerializeField] private float arrowMoveSpeed;
        [SerializeField] private float currentArrowDamage;
        [SerializeField] private float baseArrowDamage;
        [SerializeField] private float ironArrowDamageIncrement;
        [SerializeField] private float fireArrowDamageIncrement;
        [SerializeField] private float iceArrowDamageIncrement;
        [SerializeField] private float poisonArrowDamageIncrement;
        [SerializeField] private float lightArrowDamageIncrement;
        [SerializeField] private float darkArrowDamageIncrement;
        [SerializeField] private EnemyController closestEnemy;
        [SerializeField] public EnemyController[] allEnemies;
        [SerializeField] private string arrowType;
        [SerializeField] private float damageOverTimeTimer;
        [SerializeField] private float applyOverNSeconds;

        [Header("Sounds")]
        [SerializeField] private AudioSource arrowShoot;

        Vector3 origPosition;

        Damageable damageable;

        private string fireOrPoison;

        private bool addedArrowToList;
        private bool didDamage = false;
        private bool startDoTTimer = false;
        private bool freezeRotation = false;

        private int currentLevel;

        private void Awake()
        {
                arrowShoot.Play();
        }

        private void Start()
        {
                sprite = GetComponent<SpriteRenderer>();

                origPosition = transform.position;
                addedArrowToList = false;
                FindClosestEnemy();

                ironArrowDamageIncrement = 3;
                fireArrowDamageIncrement = 8;
                iceArrowDamageIncrement = 4;
                poisonArrowDamageIncrement = 7;
                lightArrowDamageIncrement = 6;
                darkArrowDamageIncrement = 5;

                currentLevel = GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().CurrentLevel;
        }

        private void Update()
        {
                Vector3 moveDirection = this.transform.position - origPosition;
                if (moveDirection !=  Vector3.zero && !freezeRotation)
                {
                        float angle = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }

                if (allEnemies.Length <= 0 || closestEnemy == null)
                {
                        Destroy(this.gameObject);
                }

                if (allEnemies.Length > 0 && !addedArrowToList && closestEnemy != null)
                {
                        closestEnemy?.GetComponent<EnemyController>().arrowsTargeting.Add(this.gameObject);
                        closestEnemy.GetComponent<EnemyController>().LockedOn = true;
                        addedArrowToList = true;
                }

                if (closestEnemy != null)
                {
                        Vector2 moveDir = Vector2.MoveTowards(this.transform.position, closestEnemy.transform.position, Time.deltaTime * arrowMoveSpeed);
                        this.transform.position = moveDir;
                        if (Vector2.Distance(this.transform.position, closestEnemy.transform.position) < 0.01f)
                        {
                                if (!didDamage)
                                {
                                        HitEnemy();
                                }
                        }
                }
                if (startDoTTimer)
                {
                        this.GetComponent<Rigidbody2D>().freezeRotation = true;
                        freezeRotation = true;
                        if (applyOverNSeconds > 0)
                        {
                                damageOverTimeTimer -= Time.deltaTime;
                                if (damageOverTimeTimer <= 0)
                                {
                                        if (fireOrPoison == "Fire")
                                        {
                                                damageable.OnHit((int)currentArrowDamage, "Fire");
                                                GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                                                applyOverNSeconds--;
                                                damageOverTimeTimer = 1;
                                        }
                                        else if (fireOrPoison == "Poison")
                                        {
                                                damageable.OnHit((int)currentArrowDamage, "Poison");
                                                GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                                                applyOverNSeconds--;
                                                damageOverTimeTimer = 1;
                                        }
                                        else if (fireOrPoison == "Ice")
                                        {
                                                damageable.OnHit((int)currentArrowDamage, "Ice");
                                                GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                                                applyOverNSeconds--;
                                                damageOverTimeTimer = 1;
                                        }
                                }
                        }
                        else if (applyOverNSeconds <= 0)
                        {
                                closestEnemy.GetComponent<EnemyController>().DebuffType = "none";
                        }
                }
        }

        private void FindClosestEnemy()
        {
                float distanceToClosestEnemy = Mathf.Infinity;
                closestEnemy = null;
                allEnemies = GameObject.FindObjectsOfType<EnemyController>();

                foreach (EnemyController currentEnemy in allEnemies)
                {
                        if (currentEnemy.GetComponent<Animator>().GetBool("isAlive"))
                        {
                                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                                if (distanceToEnemy < distanceToClosestEnemy)
                                {
                                        distanceToClosestEnemy = distanceToEnemy;
                                        closestEnemy = currentEnemy;
                                }
                        }
                }
        }

        private void HitEnemy()
        {
                if (arrowType == "Iron")
                {
                        bool marked = false;
                        marked = closestEnemy.GetComponent<Animator>().GetBool("darkMarked");
                        didDamage = true;

                        baseArrowDamage = 8;
                        if (marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().IronArrowLevel * ironArrowDamageIncrement) * 1.25f);
                        }
                        else if (!marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().IronArrowLevel * ironArrowDamageIncrement));
                        }

                        damageable = closestEnemy?.GetComponent<Damageable>();
                        GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                        damageable?.OnHit((int)currentArrowDamage, "Iron");
                        Destroy(this.gameObject);
                }
                else if (arrowType == "Fire")
                {
                        bool marked = false;
                        marked = closestEnemy.GetComponent<Animator>().GetBool("darkMarked");
                        didDamage = true;
                        damageable = closestEnemy?.GetComponent<Damageable>();
                        baseArrowDamage = 5;

                        if (marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().FireArrowLevel * fireArrowDamageIncrement) * 1.25f);
                        }
                        else if (!marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().FireArrowLevel * fireArrowDamageIncrement));
                        }

                        GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                        closestEnemy.GetComponent<EnemyController>().DebuffType = "Burn";
                        damageable?.OnHit((int)currentArrowDamage, "Fire");
                        sprite.enabled = false;
                        fireOrPoison = "Fire";
                        startDoTTimer = true;
                        StartCoroutine(Delay());
                        IEnumerator Delay()
                        {
                                yield return new WaitForSeconds(4f);
                                closestEnemy.GetComponent<EnemyController>().DebuffType = "none";
                                Destroy(this.gameObject);
                        }
                }
                else if (arrowType == "Ice")
                {
                        bool marked = false;
                        marked = closestEnemy.GetComponent<Animator>().GetBool("darkMarked");
                        didDamage = true;
                        damageable = closestEnemy?.GetComponent<Damageable>();
                        baseArrowDamage = 3;

                        if (marked)
                        {
                                currentArrowDamage = (currentLevel + 1) *  (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().IceArrowLevel * iceArrowDamageIncrement) * 1.25f);
                        }
                        else if (!marked)
                        {
                                currentArrowDamage = (currentLevel + 1) *  (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().IceArrowLevel * iceArrowDamageIncrement));
                        }

                        GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                        closestEnemy.GetComponent<EnemyController>().DebuffType = "Slowed";
                        damageable?.OnHit((int)currentArrowDamage, "Ice");
                        sprite.enabled = false;
                        fireOrPoison = "Ice";
                        startDoTTimer = true;
                        int freezeChance = Random.Range(0, 101);
                        if (freezeChance >= 90 && !closestEnemy.GetComponent<Animator>().GetBool("isFrozen"))
                        {
                                closestEnemy.GetComponent<SpriteRenderer>().color = new Color(0, 78, 255);
                                closestEnemy.GetComponent<Animator>().SetBool("isFrozen", true);
                                closestEnemy.GetComponent<EnemyController>().MoveSpeed *= 0f;
                        }
                        else if (freezeChance < 90 && !closestEnemy.GetComponent<Animator>().GetBool("isFrozen"))
                        {
                                closestEnemy.GetComponent<EnemyController>().MoveSpeed *= 0.5f;
                        }
                        StartCoroutine(Delay());
                        IEnumerator Delay()
                        {
                                yield return new WaitForSeconds(2.5f);
                                closestEnemy.GetComponent<EnemyController>().MoveSpeed = 2f;
                                closestEnemy.GetComponent<SpriteRenderer>().color = Color.white;
                                closestEnemy.GetComponent<Animator>().SetBool("isFrozen", false);
                                closestEnemy.GetComponent<EnemyController>().DebuffType = "none";
                                Destroy(this.gameObject);
                        }
                }
                else if (arrowType == "Poison")
                {
                        bool marked = false;
                        marked = closestEnemy.GetComponent<Animator>().GetBool("darkMarked");
                        didDamage = true;
                        damageable = closestEnemy?.GetComponent<Damageable>();
                        baseArrowDamage = 5;

                        if (marked)
                        {
                                currentArrowDamage = (currentLevel + 1) *  (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().PoisonArrowLevel * poisonArrowDamageIncrement) * 1.25f);
                        }
                        else if (!marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().PoisonArrowLevel * poisonArrowDamageIncrement));
                        }

                        GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                        closestEnemy.GetComponent<EnemyController>().DebuffType = "Poison";
                        damageable?.OnHit((int)currentArrowDamage, "Poison");
                        sprite.enabled = false;
                        fireOrPoison = "Poison";
                        startDoTTimer = true;
                        StartCoroutine(Delay());
                        IEnumerator Delay()
                        {
                                yield return new WaitForSeconds(4f);
                                closestEnemy.GetComponent<EnemyController>().DebuffType = "none";
                                Destroy(this.gameObject);
                        }
                }
                else if (arrowType == "Light")
                {
                        bool marked = false;
                        marked = closestEnemy.GetComponent<Animator>().GetBool("darkMarked");
                        didDamage = true;
                        damageable = closestEnemy?.GetComponent<Damageable>();
                        baseArrowDamage = 14;

                        if (marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().LightArrowLevel * lightArrowDamageIncrement) * 1.25f);
                        }
                        else if (!marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().LightArrowLevel * lightArrowDamageIncrement));
                        }

                        GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                        damageable?.OnHit((int)currentArrowDamage, "Light");
                        Destroy(this.gameObject);
                }
                else if (arrowType == "Dark")
                {
                        bool marked = false;
                        marked = closestEnemy.GetComponent<Animator>().GetBool("darkMarked");
                        didDamage = true;
                        damageable = closestEnemy?.GetComponent<Damageable>();
                        closestEnemy?.GetComponent<Animator>().SetBool("darkMarked", true);
                        baseArrowDamage = 12;

                        if (marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().DarkArrowLevel * darkArrowDamageIncrement) * 1.25f);
                        }
                        else if (!marked)
                        {
                                currentArrowDamage = (currentLevel + 1) * (baseArrowDamage + (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().DarkArrowLevel * darkArrowDamageIncrement));
                        }

                        GameObject.Find("ArcherManager").GetComponent<DPS>().dps.Add(currentArrowDamage);
                        closestEnemy.GetComponent<EnemyController>().DebuffType = "Cursed";
                        damageable?.OnHit((int)currentArrowDamage, "Dark");
                        Destroy(this.gameObject);
                }
        }
}
