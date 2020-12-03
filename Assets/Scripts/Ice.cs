using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        other.gameObject.GetComponent<Rigidbody2D>().velocity *= 1.2f;

    }
}
