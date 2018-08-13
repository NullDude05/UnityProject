using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageHandler : MonoBehaviour {

    public float invulnPeriod = 0;
    public int health = 2;
    int correctLayer;
    float invulnTimer = 0;

    private void Start()
    {
        correctLayer = gameObject.layer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        if (invulnTimer <= 0)
        {
            health--;
            invulnTimer = 2f;

            gameObject.layer = 10;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0)
            gameObject.layer = correctLayer;

        if (health <= 0)
            Die();
    }
}
