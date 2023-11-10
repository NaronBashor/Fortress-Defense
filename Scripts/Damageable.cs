using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Damageable : MonoBehaviour, IDataPersistence
{
        Animator anim;

        [Header("Sounds")]
        [SerializeField] private AudioSource arrowImpact;

        [SerializeField] private float maxFortressHealth;
        [SerializeField] private float health;
        [SerializeField] GameObject damageText;
        [SerializeField] private int characterIndex = 0;
        [SerializeField] private int currentGameLevel;
        [SerializeField] private string characterType;

        public List<int> enemyHealthList = new List<int>();

        private int fortressUpgradeLevel = 1;
        private int currentLevel;

        public float Health
        {
                get
                {
                        return health;
                }
                set
                {
                        health = value;
                }
        }

        public float MaxHealth
        {
                get
                {
                        return maxFortressHealth;
                }
                set
                {
                        maxFortressHealth = value;
                }
        }

        public void LoadData(GameData data)
        {
                this.fortressUpgradeLevel = data.fortressUpgradeLevel;
        }

        public void SaveData(ref GameData data)
        {
                data.fortressUpgradeLevel = this.fortressUpgradeLevel;
        }

        private void Start()
        {
                anim = GetComponent<Animator>();

                currentGameLevel = GameObject.Find("Fortress").GetComponent<FortressManager>().CurrentGameLevel;
                currentLevel = GameObject.Find("ExperienceManager").GetComponent<ExperienceManager>().CurrentLevel;

                enemyHealthList.Add(24);
                enemyHealthList.Add(24);
                enemyHealthList.Add(200);
                enemyHealthList.Add(24);
                enemyHealthList.Add(40);
                enemyHealthList.Add(24);
                enemyHealthList.Add(30);
                enemyHealthList.Add(40);
                enemyHealthList.Add(24);
                enemyHealthList.Add(30);
                enemyHealthList.Add(24);

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

                if (characterIndex == 12)
                {
                        health = 1000 * fortressUpgradeLevel;
                        MaxHealth = health;
                }
                for (int i = 0; i < 12; i++)
                {
                        if (i == characterIndex)
                        {
                                if (currentGameLevel < 1)
                                {
                                        health = enemyHealthList[i];
                                }
                                else if (currentGameLevel >= 1)
                                {
                                        health = enemyHealthList[i] * currentLevel;
                                }
                        }
                }
        }

        private void Update()
        {
                if (Health <= 0)
                {
                        anim.SetBool("isAlive", false);
                }
        }

        public void OnHit(float damage, string arrow)
        {
                arrowImpact.Play();
                health -= damage;
                GameObject damageTextPopUp = Instantiate(damageText, transform.position, Quaternion.identity);
                if (arrow == "Poison")
                {
                        damageTextPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color.green;
                }
                else if (arrow == "Fire")
                {
                        damageTextPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color.red;
                }
                else if (arrow == "Ice")
                {
                        damageTextPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color.blue;
                }
                else
                {
                        damageTextPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color.black;
                }
                damageTextPopUp.transform.GetChild(0).GetComponent<TextMeshPro>().text = damage.ToString();
        }

        public void OnHeal(int healthRestore)
        {
                health += healthRestore;
        }
}
