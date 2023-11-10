using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
        Animator anim;

        [SerializeField] Transform projectileLocation;
        [SerializeField] GameObject projectile;
        [SerializeField] private float bombDelay;
        [SerializeField] private float throwDelay;
        [SerializeField] private float bombDestroyDelay;
        [SerializeField] private Vector2 throwVelocity;

        private GameObject proj;

        private void Start()
        {
                anim = GetComponent<Animator>();
        }

        private void Update()
        {
                if (!anim.GetBool("isAlive") && proj != null)
                {
                        Destroy(proj);
                }
        }

        public void RangeAttack(float damage, int sortingOrder)
        {
                StartCoroutine(ThrowDelay());
                IEnumerator ThrowDelay()
                {
                        yield return new WaitForSeconds(throwDelay);
                        proj = Instantiate(projectile, projectileLocation.position, Quaternion.identity);
                        proj.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
                        proj.GetComponent<Rigidbody2D>().AddForce(throwVelocity, ForceMode2D.Impulse);
                        StartCoroutine(Delay());
                        IEnumerator Delay()
                        {
                                yield return new WaitForSeconds(bombDelay);
                                if (proj != null)
                                {
                                        proj.GetComponent<Animator>().SetTrigger("explode");
                                        GameObject.FindGameObjectWithTag("Fortress").GetComponent<Damageable>().OnHit(damage, "range");
                                        proj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                                        proj.GetComponent<Rigidbody2D>().gravityScale = 0;
                                        StartCoroutine(SecondDelay());
                                        IEnumerator SecondDelay()
                                        {
                                                yield return new WaitForSeconds(bombDestroyDelay);
                                                Destroy(proj);
                                        }
                                }                                
                        }
                }                
        }
}
