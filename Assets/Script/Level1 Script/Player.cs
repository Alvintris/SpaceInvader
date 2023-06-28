using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet preFab;
    [SerializeField] private float speed;

    public int lives = 3;

    public Action damaged;
    public Action shootingSound;

    private bool laserActive;

    private void FixedUpdate()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!laserActive)
            {
                shootingSound?.Invoke();
                Bullet bullet = Instantiate(preFab, this.transform.position, Quaternion.identity);
                bullet.destroyed += BulletDestroyed;
                laserActive = true;
            }
        }
    }

    private void BulletDestroyed()
    {
        laserActive = false;
    }

    private void Movement()
    {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        float direction = Input.GetAxisRaw("Horizontal");

        if (this.transform.position.x < leftEdge.x + 1.0f && direction == -1)
        {
            direction = 0;
        } else if(this.transform.position.x > rightEdge.x - 1.0f && direction == 1)
        {
            direction = 0;
        }

        this.transform.position += new Vector3 (direction * speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet") || 
            collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            damaged?.Invoke();
        }
    }
}
