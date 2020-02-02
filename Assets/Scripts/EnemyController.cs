using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;    //speed of enemy movement

    [SerializeField]
    private Vector3 offsetEndPos;   //the vector3 where the enemy's movement will end

    private Vector3 startPos;   //enemy starting point
    private Vector3 targetPos;  //idk about this variable yet

    private void Awake()
    {
        startPos = transform.position;  //assigns startPos var as the enemy's initial starting point
        targetPos = startPos + offsetEndPos;    
    }

    private void Update()
    {
        //this code actually moves the enemy.  the MoveTowards method takes 3 parameters in this case:
        //the current position, the position you'd like to get to, and the speed at which to travel
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //if the enemy makes it to the target position
        if (transform.position == targetPos)
        {   
            //if the target position is actually the enemy's starting point
            if (targetPos == startPos)
                //set the target position back to the end point we'd like the enemy to go back to
                targetPos = startPos + offsetEndPos;
                //if we've reached the target position, go back to the starting position.
            else if (targetPos == startPos + offsetEndPos)
                targetPos = startPos;
        }
    }
}

