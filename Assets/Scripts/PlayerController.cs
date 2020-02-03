using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce;

    private Rigidbody rig;

    private void Awake()
    {
        //get the rigidbody component
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();

        //Maybe GetButtonDown is similar to GetKeyDown, but is 
        //used for Unity's built in input settings?
        if (Input.GetButtonDown("Jump"))
        {
            TryJump();
        }
    }

    private void Move()
    {
        // getting our inputs
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        //Y-axis equals whatever the currently velocity of Y is at any given moment
        dir.y = rig.velocity.y;

        rig.velocity = dir;

        Vector3 facingDir = new Vector3(xInput , 0, zInput);

        //without this code, the player would immediately snap back to facing the same direction
        //on the Z axis when nothing is pressed.  This code forces the player to face the last
        //direction they were in when a direction key was pressed
        if(facingDir.magnitude > 0)
        {
            //forward is a function that turns an object to face its Z-axis
            transform.forward = facingDir;
        }
        
    }

    void TryJump()
    {
        //Here we're creating 4 raycasts, which is an invisble line pointing in a direction that we
        //assign it.  The rays includes information about the object it hits, how far the object was, etc.
        //the rays takes two parameters: where it's origin is, and what direction it's traveling.

        //Our cube character is 1 unit long, so we're projecting 4 rays downward, one at each corner
        //of the player.  This way the player will jump even if most of its body is hanging off an edge.

        Ray ray1 = new Ray(transform.position + new Vector3(0.5f, 0, 0.5f), Vector3.down);
        Ray ray2 = new Ray(transform.position + new Vector3(-0.5f, 0, 0.5f), Vector3.down);
        Ray ray3 = new Ray(transform.position + new Vector3(0.5f, 0, -0.5f), Vector3.down);
        Ray ray4 = new Ray(transform.position + new Vector3(-0.5f, 0, -0.5f), Vector3.down);

        bool cast1 = Physics.Raycast(ray1, 0.7f);
        bool cast2 = Physics.Raycast(ray2, 0.7f);
        bool cast3 = Physics.Raycast(ray3, 0.7f);
        bool cast4 = Physics.Raycast(ray4, 0.7f);

        //Here we're actually casting the ray using the Physics.Raycast method, which takes the raycast
        //that we created as an argument, as well as a distance
        if (cast1 || cast2 || cast3 || cast4)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //AddForce is a function that does what it sounds like and pushes our object with rigidbody.
        //ForceMode.Impulse creates a behavior similar to hitting a golfball.  As soon as that force
        //is applied, the reaction is explosive and more reactive.  Without ForceMode.Impulse, the
        //object would not move or would need more momentum before moving very slowly
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
