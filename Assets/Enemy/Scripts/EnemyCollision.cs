using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    int currentHitPoint = 0;
    private void Start()
    {
        currentHitPoint = maxHitPoint; 
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();   
    }

    private void ProcessHit()
    {
        Debug.Log(currentHitPoint);
        currentHitPoint -= 1;
        if (currentHitPoint <= 0)
            Destroy(this.gameObject);
    }
}
