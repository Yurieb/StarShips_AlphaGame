using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
   

    private void Start()
    {
        transform.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
    }



}
