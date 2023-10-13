using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocator : MonoBehaviour
{
    [SerializeField] float towersRange = 15f;
    [SerializeField] ParticleSystem bow; 
    [SerializeField] Transform weapon;
    Transform target;


    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float minDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (minDistance > targetDistance) {
                closestTarget = enemy.transform;
                minDistance = targetDistance; 
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance < towersRange)
        {
            Attack(true);
            transform.LookAt(target);
        }
        else
            Attack(false);
        
    }
    
    void Attack(bool isActive)
    {
        var bowEmission = bow.emission; 
        bowEmission.enabled = isActive; 
        
    }
}

