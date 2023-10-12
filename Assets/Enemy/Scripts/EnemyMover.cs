using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f,5f)] float movementSpeed = 1f;
    
    void Start()
    {
        StartCoroutine(FollowPath());
    }
    
    IEnumerator FollowPath()
    {
        foreach(WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position; 
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while (travelPercent < 1f) {
                    travelPercent += movementSpeed * Time.deltaTime;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
           
        }
    }
    
}
