﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerCotroller : MonoBehaviour
{
    public float speed;
    public float tilt;
    private new Rigidbody rigidbody;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float firerate = 0.5f;
    private float nextFire = 0.0f;
    

    void Update()
    {
        if (Time.time > nextFire){
            nextFire = Time.time + firerate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rigidbody.velocity = movement * speed;

            rigidbody.position = new Vector3
                (
                Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax), 
                0.0f, 
                Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
                );

        rigidbody.rotation = Quaternion.Euler(
            0.0f,
            0.0f, 
            rigidbody.velocity.x*-tilt);
    }
}


