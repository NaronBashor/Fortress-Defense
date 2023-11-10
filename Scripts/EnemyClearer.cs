using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyClearer : MonoBehaviour
{
        public GameObject[] gameObjectsToRemove;

        private float timer;

        private void Update()
        {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                        gameObjectsToRemove = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject gameObject in gameObjectsToRemove)
                        {
                                if (!gameObject.GetComponent<Animator>().GetBool("isAlive"))
                                {
                                        Destroy(gameObject);
                                }
                        }
                        timer = 2;
                }
        }
}
