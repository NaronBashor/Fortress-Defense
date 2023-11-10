using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArcherController : MonoBehaviour
{
        Animator anim;

        [SerializeField] private float initialAttackRange;
        [SerializeField] private float currentAttackSpeed;
        [SerializeField] private float currentAttackRange;
        [SerializeField] private float arrowSpawnDelay;
        [SerializeField] private float attackSpeedCountdown;
        [SerializeField] private Transform arrowLocation;

        [SerializeField] private GameObject arrowRadialMenu;
        [SerializeField] private GameObject arrowRadialOpenButton;

        public int index;

        public List<GameObject> shotArrows = new List<GameObject>();
        public List<GameObject> arrowTypes = new List<GameObject>();
        public List<GameObject> lockedArrowOverlay = new List<GameObject>();

        private bool fireArrowUnlocked = false;
        private bool iceArrowUnlocked = false;
        private bool poisonArrowUnlocked = false;
        private bool lightArrowUnlocked = false;
        private bool darkArrowUnlocked = false;

        public bool unlockAllArrows = false;

        #region Properties

        public bool DarkArrowUnlocked
        {
                get
                {
                        return darkArrowUnlocked;
                }
                set
                {
                        darkArrowUnlocked = value;
                }
        }

        public bool LightArrowUnlocked
        {
                get
                {
                        return lightArrowUnlocked;
                }
                set
                {
                        lightArrowUnlocked = value;
                }
        }

        public bool PoisonArrowUnlocked
        {
                get
                {
                        return poisonArrowUnlocked;
                }
                set
                {
                        poisonArrowUnlocked = value;
                }
        }

        public bool IceArrowUnlocked
        {
                get
                {
                        return iceArrowUnlocked;
                }
                set
                {
                        iceArrowUnlocked = value;
                }
        }

        public bool FireArrowUnlocked
        {
                get
                {
                        return fireArrowUnlocked;
                }
                set
                {
                        fireArrowUnlocked = value;
                }
        }

        #endregion

        private void Awake()
        {
                arrowRadialMenu.SetActive(false);
        }

        public enum ArrowChosen
        {
                iron, fire, ice, poison, light, dark
        }

        private void Start()
        {
                anim = GetComponent<Animator>();

                AttackSpeed(ArrowChosen.iron);

                currentAttackRange = initialAttackRange;

                unlockAllArrows = false;
                if (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().FireArrowLevel > 0)
                {
                        fireArrowUnlocked = true;
                }
                if (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().IceArrowLevel > 0)
                {
                        iceArrowUnlocked = true;
                }
                if (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().PoisonArrowLevel > 0)
                {
                        poisonArrowUnlocked = true;
                }
                if (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().LightArrowLevel > 0)
                {
                        lightArrowUnlocked = true;
                }
                if (GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().DarkArrowLevel > 0)
                {
                        darkArrowUnlocked = true;
                }
        }

        private void Update()
        {
                if (attackSpeedCountdown >= 0)
                {
                        attackSpeedCountdown -= Time.deltaTime;
                }

                float distanceToClosestEnemy = Mathf.Infinity;
                EnemyController closestEnemy = null;
                EnemyController[] allEnemies = GameObject.FindObjectsOfType<EnemyController>();
                if (attackSpeedCountdown <= 0 && allEnemies.Length > 0)
                {
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
                        if (closestEnemy != null && Vector2.Distance(closestEnemy.transform.position, transform.position) < currentAttackRange)
                        {
                                Attack();
                        }
                }

                if (unlockAllArrows)
                {
                        fireArrowUnlocked = true;
                        iceArrowUnlocked = true;
                        poisonArrowUnlocked = true;
                        lightArrowUnlocked = true;
                        darkArrowUnlocked = true;
                }
        }

        #region Arrows

        public void IronArrow()
        {
                ArrowShooting(ArrowChosen.iron);
                AttackSpeed(ArrowChosen.iron);
                CloseRadialArrowMenu();
        }

        public void FireArrow()
        {
                if (fireArrowUnlocked)
                {
                        ArrowShooting(ArrowChosen.fire);
                        AttackSpeed(ArrowChosen.fire);
                        CloseRadialArrowMenu();
                }
        }

        public void IceArrow()
        {
                if (iceArrowUnlocked)
                {
                        ArrowShooting(ArrowChosen.ice);
                        AttackSpeed(ArrowChosen.ice);
                        CloseRadialArrowMenu();
                }
        }

        public void PoisonArrow()
        {
                if (poisonArrowUnlocked)
                {
                        ArrowShooting(ArrowChosen.poison);
                        AttackSpeed(ArrowChosen.poison);
                        CloseRadialArrowMenu();
                }
        }

        public void LightArrow()
        {
                if (lightArrowUnlocked)
                {
                        ArrowShooting(ArrowChosen.light);
                        AttackSpeed(ArrowChosen.light);
                        CloseRadialArrowMenu();
                }
        }

        public void DarkArrow()
        {
                if (darkArrowUnlocked)
                {
                        ArrowShooting(ArrowChosen.dark);
                        AttackSpeed(ArrowChosen.dark);
                        CloseRadialArrowMenu();
                }
        }

        public void ArrowShooting(ArrowChosen arrow)
        {
                if (arrow == ArrowChosen.iron)
                {
                        index = 0;
                }
                else if (arrow == ArrowChosen.fire)
                {
                        index = 1;
                }
                else if (arrow == ArrowChosen.ice)
                {
                        index = 2;
                }
                else if (arrow == ArrowChosen.poison)
                {
                        index = 3;
                }
                else if (arrow == ArrowChosen.light)
                {
                        index = 4;
                }
                else if (arrow == ArrowChosen.dark)
                {
                        index = 5;
                }
        }

        #endregion        

        void Attack()
        {
                attackSpeedCountdown = currentAttackSpeed;

                anim.SetTrigger("attack");
                StartCoroutine(Delay());
                IEnumerator Delay()
                {
                        yield return new WaitForSeconds(arrowSpawnDelay);
                        GameObject arrow = Instantiate(arrowTypes[index], arrowLocation.position, Quaternion.identity);
                        shotArrows.Add(arrow);
                }
        }

        #region Panels and Menus

        public void OpenRaidalArrowMenu()
        {
                arrowRadialMenu.SetActive(true);
                arrowRadialMenu.GetComponent<Animator>().SetTrigger("menuOpened");
                if (fireArrowUnlocked)
                {
                        lockedArrowOverlay[0].SetActive(false);
                }
                if (iceArrowUnlocked)
                {
                        lockedArrowOverlay[1].SetActive(false);
                }
                if (poisonArrowUnlocked)
                {
                        lockedArrowOverlay[2].SetActive(false);
                }
                if (lightArrowUnlocked)
                {
                        lockedArrowOverlay[3].SetActive(false);
                }
                if (darkArrowUnlocked)
                {
                        lockedArrowOverlay[4].SetActive(false);
                }
                arrowRadialOpenButton.SetActive(false);
        }

        public void CloseRadialArrowMenu()
        {
                arrowRadialMenu.GetComponent<Animator>().SetTrigger("menuClosed");
                StartCoroutine(Delay());
                IEnumerator Delay()
                {
                        yield return new WaitForSeconds(0.5f);
                        arrowRadialMenu.SetActive(false);
                        arrowRadialOpenButton.SetActive(true);
                }
        }

        #endregion        

        public void AttackSpeed(ArrowChosen arrow)
        {
                float attackSpeedUpgradeLevel = GameObject.Find("ArcherManager").GetComponent<ArcherManager>().AttackSpeedUpgradeLevel;
                if (arrow == ArrowChosen.iron)
                {
                        currentAttackSpeed = 2 / attackSpeedUpgradeLevel;
                        attackSpeedCountdown = (float)currentAttackSpeed;
                }
                else if (arrow == ArrowChosen.ice)
                {
                        currentAttackSpeed = 3 / attackSpeedUpgradeLevel;
                        attackSpeedCountdown = (float)currentAttackSpeed;
                }
                else if (arrow == ArrowChosen.fire)
                {
                        currentAttackSpeed = 3 / attackSpeedUpgradeLevel;
                        attackSpeedCountdown = (float)currentAttackSpeed;
                }
                else if (arrow == ArrowChosen.poison)
                {
                        currentAttackSpeed = 3 / attackSpeedUpgradeLevel;
                        attackSpeedCountdown = (float)currentAttackSpeed;
                }
                else if (arrow == ArrowChosen.light)
                {
                        currentAttackSpeed = 1 / attackSpeedUpgradeLevel;
                        attackSpeedCountdown = (float)currentAttackSpeed;
                }
                else if (arrow == ArrowChosen.dark)
                {
                        currentAttackSpeed = 3 / attackSpeedUpgradeLevel;
                        attackSpeedCountdown = (float)currentAttackSpeed;
                }
        }

        private void OnDrawGizmos()
        {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, currentAttackRange);
        }
}
