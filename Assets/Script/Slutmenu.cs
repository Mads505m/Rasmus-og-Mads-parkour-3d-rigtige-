using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slutmenu : MonoBehaviour {

 public void Genstart () //en funktion
 {
  SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex -1); // her skal den gå en scene tilbage
 }
 
 public void tilbage ()
 {
  SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex -2); //her går den 2 scener tilbage
 }
}