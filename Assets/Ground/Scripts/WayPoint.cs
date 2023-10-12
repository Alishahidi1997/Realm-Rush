using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    
    [SerializeField] GameObject defender;
    [SerializeField] GameObject towerSpawnAtRunTime;


    [SerializeField] bool isPlaceable;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(defender, transform.position, transform.rotation);
            isPlaceable = false; 
        }
    }


}
