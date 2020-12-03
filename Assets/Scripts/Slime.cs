using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D other)
    {

        other.gameObject.GetComponent<Rigidbody2D>().velocity *= 0.4f;

    }
}
