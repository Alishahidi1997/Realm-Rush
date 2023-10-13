using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f,5f)] float movementSpeed = 1f;
  


    int withdrawAmount = -25;

    Bank accessToBank;
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        accessToBank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank>();
    }
    void FindPath()
    {
        path.Clear();
        GameObject[] wayPoints = GameObject.FindGameObjectsWithTag("Path"); 
        foreach(GameObject wayPoint in wayPoints)
        {
            path.Add(wayPoint.GetComponent<WayPoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator FollowPath()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += movementSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
        ProcessReachingToCastle();
    }

    void ProcessReachingToCastle()
    {
        accessToBank.withdraw(withdrawAmount);
        gameObject.active = false;
    }
    
}
