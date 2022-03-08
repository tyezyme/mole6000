using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public Text time_left_count;

    public float time_left = 99;

    public GameObject pleaseFuckingDie;

    



    bool itsDead;
    bool TimerStarted;


    
    
    void Start()
    {
        

        
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C)) {
            TimerStarted = true;
        }

        
        

        if (itsDead) {
            
        }
        if (TimerStarted) {
            timerStart();
        }

    }

    void timerStart() {

        time_left -= Time.deltaTime;
        time_left_count.text = time_left.ToString("F0");
        if (time_left_count.text == "0") {
           SceneManager.LoadScene("GameOver");
        }


    }
}
