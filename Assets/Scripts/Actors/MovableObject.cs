using UnityEngine;
using System.Collections;

public class MovableObject : MonoBehaviour
{

    public float speed;

    private Vector3 newPosition;
    private Vector3 currentPosition;
    private Vector3 startPosition;
    private float startTime;
    private float journeyLength;

    protected void Awake()
    {
        startPosition = transform.position;
        currentPosition = startPosition;
        journeyLength = 0f;
    }

    protected void Update()
    {
        if (journeyLength > 0)
            MoveToLocation();
    }


    public void SetNewPosition(Vector3 position)
    {
        newPosition = position;
        startPosition = currentPosition;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, newPosition);
        //Selected = false;
    }

    private void MoveToLocation()
    {

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        currentPosition = Vector3.Lerp(startPosition, newPosition, fracJourney);

        transform.position = new Vector3(currentPosition.x, currentPosition.y, -0.5f);
    }
}
