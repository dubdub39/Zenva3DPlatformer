using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    public float bobSpeed;

    [SerializeField]
    public float rotateSpeed;

    [SerializeField]
    public float bobHeight;

    private Vector3 startPos, targetPos;

    private void Awake()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, bobHeight, 0);
    }

    private void Update()
    {
        //moves the coin to the height (Y-axis) that we want

        transform.position = Vector3.MoveTowards(transform.position, targetPos, bobSpeed * Time.deltaTime);

        //rotates the coin with the Rotate method.  This method takes the axis of rotation (Vector3.up), 
        //the speed of rotation, and the space that the rotation is relative to.  By default, I think it's
        //local space and won't rotate.  When setting to Space.World, the coin will rotate

        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        //code for coin bobbing up and down.  the target pos will pretty much be the bobHeight.  if the coin's
        //position has reached our defined bobHeight...

        if (transform.position == targetPos)
        {
            //if our coin's Y position has gotten back to where it started

            if (targetPos == startPos)

                //then set the target position to bobHeight

                targetPos = startPos + new Vector3(0, bobHeight, 0);

            //if the target position is already set to bobHeight

            else if (targetPos == startPos + new Vector3(0, bobHeight, 0))

                //set the target position as our starting point

                targetPos = startPos;


        }
    }

}
