/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
       //Start knap
        public void PlayGame ()
        {
            SceneManger.LoadScene(SceneManger.GetActiveScene().buildIndex + 1);
        }

       //Aflsut knap
       public void QuitGame ()
       {
           Debug.Log("Afslut");
           Application.Quit();
       }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

 public void PlayGame () 
 {
  SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
 }
 
 public void QuitGame ()
 {
  Debug.Log ("QUIT!");
  Application.Quit();
 }

}