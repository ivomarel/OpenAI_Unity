using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    public float speed = 100;
    private void Update()
    {
        this.transform.Rotate(0, Time.deltaTime * speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerController>())
        {
            Destroy(this.gameObject);
        }

    }
}
