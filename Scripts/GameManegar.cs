using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachine : MonoBehaviour
{

    
    public Reel reel1;
    public Reel reel2;
    public Reel reel3;
    public TMP_Text coinTx;
   
    public Animator anim;
    public Text resultText;
    public Button spineButton;

    public Button EMIBUTTON;

    public int EMI = 10;
    public int counTep;
    public int Manny = 5000;
    public bool lonePurchesse = false;
    private int totalSymbols = 4;

    // Keep the money value between 0 and 5000 and update the coin UI
    private void Update()
    {
        Manny = Mathf.Clamp(Manny, 0, 5000);
        coinTx.text = Manny.ToString();
    }

    // Called when the Spin button is pressed
    public void onSpineButtonClick()
    {
        // Deduct the spin cost
        Manny -= 100;

        // Check if the player currently has an active loan
        if (lonePurchesse)
        {
            // Count the number of spins made after taking the loan
            counTep += 1;

            // Deduct EMI after every 4 spins
            if (counTep >= 4)
            {
                Manny -= 500;
                EMI -= 1;
                counTep = 0;
                Debug.Log("emi-");
               

                // Check if all EMIs have been paid
                if (EMI <= 0)
                {
                    lonePurchesse = false;
                    EMI = 0;
                    Debug.Log("lone ok");
                }
            }
           
           
        }

        // Stop the spin if the player has no money
        if (Manny <= 0)
        {
            return;
        }

        // Play the slot machine animation
        anim.Play("slot");
        spineButton.interactable = false;
        resultText.text = "Spinning...";

        // Generate a random result for each reel
        int result1 = Random.Range(0, totalSymbols);
        int resilt2 = Random.Range(0, totalSymbols);
        int result3 = Random.Range(0, totalSymbols);

        // Start each reel with different speed and duration
        reel1.startSpinning(2.0f, 6.0f, result1, totalSymbols);
        reel2.startSpinning(2.8f, 7.0f, resilt2, totalSymbols);
        reel3.startSpinning(3.6f, 8.0f, result3, totalSymbols);

        // Check the winning result after the reels finish spinning
        StartCoroutine(checkWinningLogic(4.0f, result1, resilt2, result3));
    }

    // Gives the player a loan if there is no active loan
    public void loneButton()
    {
        // Prevent taking another loan while the current loan is active
        if (lonePurchesse)
        {
            return;
        }

        // Give the player 5000 coins
        Manny += 5000;
        lonePurchesse = true;
        EMI = 10;
        counTep = 0;
    }

    // Checks whether the player has won or lost
    public IEnumerator checkWinningLogic(float deley, int r1, int r2, int r3)
    {
        // Wait until all reels have finished spinning
        yield return new WaitForSeconds(deley);

        // Player wins when all three symbols are the same
        if (r1 == r2 && r2 == r3)
        {
            resultText.text = "JACKPOT! YOU WIN! 🤑";
            Manny += 300;
            Debug.Log("JACKPOT! YOU WIN!🔷🔹");
        }
        else
        {
            resultText.text = "YOU LOSE! TRY AGAIN!";

            Debug.Log("YOU LOSE! TRY AGAIN!");
        }

        // Enable the Spin button again
        spineButton.interactable = true;
    }
    }
