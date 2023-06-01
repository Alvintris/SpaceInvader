using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            if(isPause){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    void PauseGame(){
        Time.timeScale = 0;
        isPause = true;
    }

    void ResumeGame(){
        Time.timeScale = 1;
        isPause = false;
    }
}
