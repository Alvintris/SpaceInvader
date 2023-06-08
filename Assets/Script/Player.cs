using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D player_rb;

    private Vector3 direction;
    [SerializeField] private float speed;

    private void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        player_rb.velocity = direction * Time.deltaTime * speed;
    }
}
