using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy_Stats
{
    public float maxHealth;
    public float currentHealth;

    //public float damage;
}

public class Enemy : MonoBehaviour
{
    public Enemy_Stats stats;
    private Quaternion randomRotation;

   // public GameObject exploaionPrefab;

    private void Start()
    {
        stats.currentHealth = stats.maxHealth;
        randomRotation = Random.rotation;
    }

    private void Update()
    {
        transform.Rotate(randomRotation.eulerAngles * 0.1f * Time.deltaTime);

        if (stats.currentHealth <= 0)
        {
          //  Instantiate(exploaionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}