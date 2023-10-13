using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] float waitBeforeReloadScene = 2f;
    [SerializeField] int startingBalance = 100;
    [SerializeField] TextMeshProUGUI showCurrentAmount;

    int currentBallance;

    
    public int CurrentBallance
    {
        get
        {
            return currentBallance; 
        }
    }

    void Start()
    {
        currentBallance = startingBalance;
        DisplayBalance();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Deposit(int amount)
    {
         currentBallance += Mathf.Abs(amount);
         DisplayBalance();
    }

    public void withdraw(int amount)
    {
        currentBallance -= Mathf.Abs(amount);
        DisplayBalance();
        IsGameOver();
    }

    void DisplayBalance()
    {
        showCurrentAmount.text = "Gold: " + currentBallance; 
    }

    void IsGameOver()
    {
        if (CurrentBallance < 0)
            StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        Debug.Log("reload Mission");
        yield return new WaitForSeconds(waitBeforeReloadScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
