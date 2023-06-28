using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public string nameInvader;
    public int points;
    public System.Action<Invader> killed;

    public string GetName() => this.nameInvader;
    public int GetPoints() => this.points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerBullet") ||
            collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            killed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
