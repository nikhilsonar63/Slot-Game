using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenager : MonoBehaviour
{
    public Reel reel1;
    public Reel reel2;
    public Reel reel3;

    public Button button;
    public Text resultText;

    private int totalSymbols = 4;
    public void OnSpineButtonClick()
    {
        button.interactable = false;
        resultText.text = "Spinning...";
        int result1 = Random.Range(0, totalSymbols);
        int result2 = Random.Range(0, totalSymbols);
        int resul3 = Random.Range(0, totalSymbols);

        reel1.startSpinning(2.0f, 6.0f, result1, totalSymbols);
        reel2.startSpinning(2.8f, 7.0f, result2, totalSymbols);
        reel3.startSpinning(3.6f, 8.0f, resul3, totalSymbols);
    }
    public IEnumerator chackWinningLogic(float deley,int r1,int r2,int r3)
    {
        yield return new WaitForSeconds(deley);
        if (r1 == r2 && r2 == r3)
        {
            resultText.text = "JACKPOT! YOU WIN! 🤑";
        }
        else
        {
            resultText.text = "YOU LOSE! TRY AGAIN!";
        }
        button.interactable = true;
    }
}
