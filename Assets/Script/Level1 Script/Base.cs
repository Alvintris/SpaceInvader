using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private float health = 30f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            health--;

            if(health <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ResetBases()
    {
        this.health = 30f;
        this.gameObject.SetActive(true);
    }
}