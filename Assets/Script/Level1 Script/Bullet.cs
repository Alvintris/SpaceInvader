using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    public System.Action destroyed;

    private void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;
        Invoke("DestroyBullet", 2);
    }

    private void DestroyBullet()
    {
        if(destroyed != null)
        {
            destroyed?.Invoke();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(destroyed != null)
        {
            destroyed.Invoke();
        }
        DestroyBullet();
    }
}
