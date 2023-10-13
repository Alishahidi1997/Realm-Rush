using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [SerializeField] int difficultyRamp = 1;  
    int currentHitPoint = 0;
    int depositAmount = 25;  

    Bank accessToBank; 
    private void OnEnable()
    {
        currentHitPoint = maxHitPoint; 
    }

    void Start()
    {
        accessToBank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank>(); 
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();   
    }

    private void ProcessHit()
    {
        currentHitPoint -= 1;
        if (currentHitPoint <= 0)
        {
            accessToBank.Deposit(depositAmount);
            maxHitPoint += difficultyRamp;
            this.gameObject.active = false;
        }
    }
}
