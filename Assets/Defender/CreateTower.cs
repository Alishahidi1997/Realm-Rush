using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    [SerializeField] GameObject defender;

    Bank accessToBank;
    void Start()
    {
        accessToBank = GameObject.FindGameObjectWithTag("Bank").GetComponent<Bank>();
    }

    public void CreateTowerProcess(GameObject tile, int towerCost)
    {
            Instantiate(defender, tile.transform.position, tile.transform.rotation);
            defender.transform.parent = transform.parent;
            accessToBank.withdraw(towerCost);
    }
}
