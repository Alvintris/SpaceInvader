using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet preFab;
    [SerializeField] private float speed;

    [SerializeField] private float _fireDelay = 0.5f;
    private float _fireTime = 0.15f;

    public int lives = 3;

    public Action damaged;
    public Action shootingSound;

    private void FixedUpdate()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _fireTime)
        {
            shootingSound?.Invoke();
            Instantiate(preFab, this.transform.position, Quaternion.identity);
            _fireTime = Time.time + _fireDelay;
        }
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet") ||
            collision.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            damaged?.Invoke();
        }
    }
}
