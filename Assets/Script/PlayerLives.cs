using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.gameObject.tag == "Enemy"){
            Destroy(other.collider.gameObject);
            lives -= 1;
            for(int i = 0; i < livesUI.Length; i++){
                if(i < lives){
                    livesUI[i].enabled = true;
                }
                else{
                    livesUI[i].enabled = false;
                }
            }
            if(lives <= 0){
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy Projectile"){
            Destroy(other.gameObject);
            lives -= 1;
            for(int i = 0; i < livesUI.Length; i++){
                if(i < lives){
                    livesUI[i].enabled = true;
                }
                else{
                    livesUI[i].enabled = false;
                }
            }
            if(lives <= 0){
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
