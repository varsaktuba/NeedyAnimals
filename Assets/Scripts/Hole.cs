using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private Vector3 spawn = new Vector3();
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        spawn = GameObject.Find("Player").transform.position;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        player.transform.position = spawn;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }
}
