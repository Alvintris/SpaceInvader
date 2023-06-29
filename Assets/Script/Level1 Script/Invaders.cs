using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    [Header("Invader Settings")]
    [SerializeField] private Invader[] invaders;

    [Header("Invader Position Settings")]
    [SerializeField] private int column;
    [SerializeField] private int row;
    [SerializeField] private float spacing;

    [Header("Movement Settings")]
    [SerializeField] private float speed;

    [Header("Invader Attack")]
    [SerializeField] private Bullet _preFab;
    [SerializeField] private float _attackRate = 1.0f;

    private Vector3 direction = Vector3.right;
    public Action<Invader> killed;
    private Vector3 startPos;

    private int _invaderKilled = 0;
    private int _totalInvaders => row * column;
    private float _amountAlive => _totalInvaders - _invaderKilled;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Start()
    {
        InvokeRepeating("Shoot", _attackRate, _attackRate);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Shoot()
    {
        foreach(Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(UnityEngine.Random.value < (1.0f/ (float) _amountAlive))
            {
                Instantiate(_preFab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    private void Movement()
    {
        this.transform.position += direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                ChangeDirection();
            }else if(direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void SpawnInvaders()
    {
        int index = 0;
        for(int i = 0; i < row; i++)
        {
            float width = spacing * (column - 1);
            float height = spacing * (row - 1);
            Vector3 centering = new Vector3(-width * 0.5f, -height * 0.5f, 0);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (i * spacing), 0);

            for(int j = 0; j < column; j++)
            {
                Invader invader = Instantiate(invaders[index], this.transform);
                invader.killed += InvaderKilled;
                invader.baseDestroyed += InvaderKilled;

                Vector3 position = rowPosition;
                position.x += j * spacing;
                invader.transform.localPosition = position;
            }

            index++;
            if(index >= invaders.Length) { index = 0; }
        }
    }

    private void InvaderKilled(Invader invader)
    {
        Destroy(invader.gameObject);
        _invaderKilled += 1;
        killed(invader);
    }

    public void ResetInvaders()
    {
        _invaderKilled = 0;
        direction = Vector3.right;
        this.transform.position = startPos;
        SpawnInvaders();
    }

    public bool InvadersCheck()
    {
        if (_invaderKilled >= _totalInvaders) return true;

        return false;
    }
}
