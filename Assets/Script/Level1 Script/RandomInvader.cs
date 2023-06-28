using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInvader : MonoBehaviour
{
    [Header("Invader Settings")]
    [SerializeField] private string _name;
    [SerializeField] private int points;

    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction = Vector3.right;

    public Action killed;
    private Vector3 startPos;
    private bool isKilled = false;

    private void Awake()
    {
        startPos = this.transform.position;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        this.transform.position += direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        if (direction == Vector3.right && this.transform.position.x >= (rightEdge.x - 1.0f))
        {
            ChangeDirection();
        }
        else if (direction == Vector3.left && this.transform.position.x <= (leftEdge.x + 1.0f))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        direction *= -1.0f;
    }

    public int GetPoint()
    {
        return points;
    }

    public void ResetSpawn()
    {
        this.transform.position = startPos;
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            isKilled = true;
            this.gameObject.SetActive(false);
            killed?.Invoke();
        }
    }

    public bool GetKilled()
    {
        return isKilled;
    }
}
