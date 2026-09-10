using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reelSpine : MonoBehaviour
{
    private RawImage rawImage;
    private bool isSpinning = false;
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

   public void startSpinning(float duration,float speed, int targetSymbolId,int totalSymbols)
    {
        if (!isSpinning)
        {
            StartCoroutine(spine(duration, speed, targetSymbolId, totalSymbols));
        }
    }
    public IEnumerator spine(float duration,float speed,int targetSymbolId,int totalSymbols)
    {
        isSpinning = true;
        float elapsed = 0;
        while (elapsed < duration)
        {
            Rect currentRect = rawImage.uvRect;
            currentRect.y += speed * Time.deltaTime;
            rawImage.uvRect = currentRect;
            yield return null;
            elapsed += Time.deltaTime;
        }
        Rect finalRect = rawImage.uvRect;
        float step = 1f / totalSymbols;
        finalRect.y = targetSymbolId * step;
        rawImage.uvRect = finalRect;
        isSpinning = false;
    }
}
