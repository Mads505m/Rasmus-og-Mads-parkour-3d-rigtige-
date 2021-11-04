using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller; //refrence til chractercontroller
    public Transform cam; //reference til vores kamera
    public float hastighed = 6f; // variable for hastighed
    public float turnSmoothTime = 0.1f; //variable for tiden det tager at vende sig om
    public float gravity = -9.81f; //variable vores gravity
    public float hoppehoojde = 3f; // variable vores hoppe højde

    public bool isSprinting = false; // varible hvor vi bruger bool til at kalde den false, som vi senerehen bruger til at skife fra false til true i et if statement
    public float Loobehastighed = 16f; //variable for løbeshastighed

    public int max_hop = 2; // her laver jeg en varible til maks antal hop, hvor jeg bruger int fordi det hele tal
    public int hop = 0; //laver en variable som vi bruger til at fortælle spillet vi har hoppet 0 gange.

    public Transform Groundcheck; //reference til et ojekt
    public float groundDistance = 0.4f; // radius af vores "sphere" på spilleren som vi skal bruge til at checke om vi har kontakt med ground
    public LayerMask groundMask; // hvad for nogle objekts vores cube på vores usynlige ting på vores spiller skal tjekke efter, som så er ground

    float turnSmoothVelocity; //variable som bruges til at  holde vores nuværende "smooth velocity"
    Vector3 velocity;
    bool isGrounded; // den ville gemme om vi vi er på jorden eller ej

    void Update()
    {
        isGrounded = Physics.CheckSphere(Groundcheck.position, groundDistance, groundMask); //checker om vi er på jorden, ved at se resulterne af vores physicscheck, hvor vi inputter vores variabler. så den tjekker
        //om det er true eller false

        if(isGrounded && velocity.y<0) // et if statement som får os ned på jorden
        {
            velocity.y = -2f;//hastighed i vores y retning
            hop = 0; // dette bruger jeg til at reset mit hop så når jeg double hopper og rammer jorden går den til 0 igen og jeg kan double hop igen
        }


        float horizontal = Input.GetAxisRaw("Horizontal"); //vi gør så vi kan bevæge os i x aksen -1=a  1=d 
        float vertical = Input.GetAxisRaw("Vertical"); //vi gør så vi kan bevæge os i z aksen -1=s 1 = w
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // den her "store vores direction" vi horizontale og vertical, hvor vi siger y aksen er 0 fordi vi gider ikke bevæge os i y aksen
           // vector3 beskriver in vektor i 3d områder //normalize gør så vektoren beholder den samme direction

        if (direction.magnitude >= 0.1f) // hvis længden af vores direction vektor er større eller lige meget 0.1f, så kan vi vi få noget input til at bevæge os
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // vi skal gøre så spilleren rotere den vej spilleren er
            //vi bruger nogle masse math funktioner til at udregne vinklen.
            //cam.eulerangle.y gør så spilleren kigge den rigtige vej

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //vi bruger en funktion smoothdampangle, hvor vi inputter vores nuværnedee vinkel,  
            //vores varaibler. Dette gør bare så det er "smooth" når vi vendre os rundt


            transform.rotation = Quaternion.Euler(0f, angle, 0f); // sætter vores rotation, quaternion.euler gør så vi kan inputte numrerne, ved x,y og z

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //dette gør så spilleren bevæger sig den vej vi kigger.


            controller.Move(moveDir.normalized * hastighed * Time.deltaTime); //her gør vi så karakteren kan bevæge sig med alle vores variabler osv, (time.deltatime gør så det er framerate independent)


        }
        if (Input.GetButtonDown("Jump") && (isGrounded ||max_hop>hop)) // gør så vi kan hoppe på space knappen, når vi er på jorden. Vi siger også at max_hop er større end hop
        {
            velocity.y = Mathf.Sqrt(hoppehoojde * -2f * gravity); //en math funktion, som vi indligt bare indsætter vores varibler ind og nu kan man så hoppe
            hop++; //vores hop stiger med 1 når vi hopper
        }
        velocity.y += gravity * Time.deltaTime; // vu tilføjer nu vores gravity til vore y akse(velocity) og vi skal også bruge tid i kvadratroden 
        controller.Move(velocity * Time.deltaTime); //går så vi nu kan hoppe baseret på vores velocity


        if (Input.GetKey(KeyCode.LeftShift)) // laver et if statement med at løbe, hvor vi skal trykke venstre shift for at løbe
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting == true) // hvis den er true skal vores hastihed bliver vores hastihed til vores loobeahastighed og hvis falsk bliver vores hastighed bare 8 altså gåtempo
        {
            hastighed = Loobehastighed;
        }
        else {
            if (isSprinting == false)
            {
                hastighed=8;
            }
        } 

    }


}