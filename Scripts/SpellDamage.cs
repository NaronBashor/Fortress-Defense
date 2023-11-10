using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
        [SerializeField] private int initialDamage;
        [SerializeField] private int iceSpellLevel;
        [SerializeField] private int lightningSpellLevel;
        [SerializeField] private int fireballSpellLevel;

        [SerializeField] private string spell;

        private void Start()
        {
                initialDamage = 25;
                iceSpellLevel = GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().IceSpellLevel;
                fireballSpellLevel = GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().FireSpellLevel;
                lightningSpellLevel = GameObject.Find("Upgrademanager").GetComponent<UpgradeManager>().LightningSpellLevel;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision != null)
                {
                        if (collision.CompareTag("Enemy"))
                        {
                                if (spell == "Ice")
                                {
                                        iceSpellLevel = GameObject.Find("ArcherManager").GetComponent<ArcherManager>().IceSpellLevel;
                                        int damage = initialDamage * (iceSpellLevel + 1);
                                        collision.GetComponent<Damageable>().OnHit(damage, "spell");
                                }
                                else if (spell == "Lightning")
                                {
                                        lightningSpellLevel = GameObject.Find("ArcherManager").GetComponent<ArcherManager>().LightningSpellLevel;
                                        int damage = initialDamage * (lightningSpellLevel + 1);
                                        collision.GetComponent<Damageable>().OnHit(damage, "spell");
                                }
                                else if (spell == "Fireball")
                                {
                                        fireballSpellLevel = GameObject.Find("ArcherManager").GetComponent<ArcherManager>().FireballSpellLevel;
                                        int damage = initialDamage * (fireballSpellLevel + 1);
                                        collision.GetComponent<Damageable>().OnHit(damage, "spell");
                                }
                        }
                }
        }
}
