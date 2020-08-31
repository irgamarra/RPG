using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allies_Movement : MonoBehaviour
{
    // Public variables
    public float speed = 1.0f;
    public GameObject focusedEnemy;
    public int initialSpotNumber;
    public string myInput;

    //Private variables
    private int currentSpotNumber;
    private List<Transform> spots = new List<Transform>();
    
    void Start()
    {
        spots = GetSpots(); //TODO: Would it be better if this was a public variable???
        currentSpotNumber = initialSpotNumber;
    }

    void Update()
    {
        //To look at enemy
        if (focusedEnemy != null)
            transform.LookAt(focusedEnemy.transform);

        if (Input.GetAxis("Horizontal") > 0)
        {
            MoveTo(NextSpotNumber(1));
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            MoveTo(NextSpotNumber(0));
        }
    }

    void MoveTo(int targetSpotNum)
    {
        float step = speed * Time.deltaTime;
        
        //To determine target
        Transform target = spots[targetSpotNum];
        
        //To get Y axis with characters of different height
        float y = this.transform.position.y + target.position.y;
        Vector3 destination = new Vector3(target.position.x, y, target.position.z);
        
        //To move character
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }

    private List<Transform> GetSpots()
    {
        //To get all children from a GameObject tagged as "Spots"

        List<Transform> children = new List<Transform>();

        Transform spots = GameObject.FindWithTag("Spots").transform;

        foreach (Transform child in spots)
            children.Add(child);

        return children; //TODO: To return or to spots.Add() ???
    }

    private int NextSpotNumber(int direction)
    {
        //Direction 0 => backwards. Direction 1 => forward.
        int target = 0;
        int lastSpotNum = spots.Count - 1;

        if (direction == 0) // If backwards
        {
            if (currentSpotNumber == 0)
                target = lastSpotNum;
            else
                target = currentSpotNumber - 1;
        }

        if (direction == 1) // If forward
        {
            if (currentSpotNumber == lastSpotNum)
                target = 0;
            else
                target = currentSpotNumber + 1;
        }

        //To determine when the player reaches the target
        //It does not count the Y axis
        Vector3 thisPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetPosition = new Vector3(spots[target].transform.position.x, 0, spots[target].transform.position.z);

        if (thisPosition == targetPosition)
            currentSpotNumber = target;

        return target;
    }
}
