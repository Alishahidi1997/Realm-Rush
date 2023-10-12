using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target; 
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        transform.LookAt(target);
    }
}
