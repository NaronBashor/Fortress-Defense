using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextHandler : MonoBehaviour
{
        private void Start()
        {
                Destroy(gameObject, 0.5f);
                transform.localPosition += new Vector3(0, 1f);
        }
}
