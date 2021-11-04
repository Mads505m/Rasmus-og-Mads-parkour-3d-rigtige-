using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class klarbane : MonoBehaviour { 

    void OnTriggerEnter(Collider Player){ //Når genstanden collider med et tag "player"
        SceneManager.LoadScene(2); // Den skal load en scene som så er 2
}
}