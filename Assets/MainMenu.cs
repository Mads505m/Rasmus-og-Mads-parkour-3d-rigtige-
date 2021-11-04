
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

 public void Spilspillet () //en function ved navn spilspillet, som vi kan bruge til vores button
 {
  SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); //Det gør så den loader næste scene
 }
 
 public void afslutspillet () //dette lukker spillet og skriver i conosole.log "afslut"
 {
  Debug.Log ("afslut");
  Application.Quit();
 }

}