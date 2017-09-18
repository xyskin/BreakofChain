using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickandTap : MonoBehaviour
{

    private bool isMoving;
    public GameObject Target, targetObject;
    private float speed;
    private Vector3 targetPosition, mousePosition, startPosition;
    int index = 0;
    float distance = 15.33f;
    float startTime, journeyLength;
    // Use this for initialization
    void Start()
    {
        isMoving = false;
        Target = (GameObject)Resources.Load("Tag");
        speed = 10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Target)
            {
                DestroyImmediate(Target);
            }
            isMoving = false;
            //To get the current mouse position
            mousePosition = Input.mousePosition;

            //Convert the mousePosition according to World position
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));
            //Debug.Log(targetPosition);
            //Set the position of targetObject
            targetObject.transform.position = targetPosition;

            //create the instance of targetObject and place it at given position.
            Target = Instantiate(targetObject, targetObject.transform.position, targetObject.transform.rotation);
            startPosition = this.transform.position;
            journeyLength = Vector3.Distance(startPosition, targetPosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = true;
            Debug.Log(isMoving);
            startTime = Time.time;

        }

        if (isMoving)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fracJourney);
            if (fracJourney >= 0.99999999999f)
            {
                isMoving = false;
                DestroyImmediate(Target);
            }
        }
    }

    //void Move(Vector3 target)
    //{

    //}
}
