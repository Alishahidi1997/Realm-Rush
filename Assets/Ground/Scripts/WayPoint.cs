using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    
    [SerializeField] bool isPlaceable;
    [SerializeField] int towerCost = 50;

    CreateTower towerCreation;
    Bank accessToBank;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    void Start()
    {
        accessToBank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank>();
        towerCreation = GameObject.FindGameObjectWithTag("TowerDefensePool").GetComponent<CreateTower>(); 
    }
    private void OnMouseDown()
    {
        if (isPlaceable && accessToBank.CurrentBallance >= Mathf.Abs(towerCost))
        {
            towerCreation.CreateTowerProcess(gameObject, towerCost); 
            isPlaceable = false; 
        }
    }


}
