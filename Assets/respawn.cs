using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
  public Transform Player; //manipulere spillerens position og vi gør så vi kan proppe spilleren ind i boksen i scriptet 
   public Transform respawnPoint;//her gør vi det samme som før, nu kan bare også sætte et object ind i boksen, hvor vi skal respawn

    void OnTriggerEnter(Collider Player) //vi laver en function. Her er det når du gameojekts collider med hinanden bruger man ontriggerenter, og her siger vi det skal ske når noget med tag "player" collider med den.
    {
        Player.transform.position = respawnPoint.transform.position; //her skal playeren spawn ved respawn pointet, transformer players position til respawnpointet.
    }
}