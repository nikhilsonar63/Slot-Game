using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    private RawImage rawImage;
    private bool isSpinning = false;
    private void Start()
    {
        rawImage = GetComponent<RawImage>();
    }
    public void startSpinning(float duretion,float speed,int targetSymbolId,int totalSymbols)
    {
        if (!isSpinning)
        {
            StartCoroutine(spineRell(duretion, speed, targetSymbolId, totalSymbols));
        }
    }
    public IEnumerator spineRell(float duretion,float speed,int targetSymbolId,int totalSymbols)
    {
        isSpinning = true;
        float elapsedTime = 0f;
        while (elapsedTime < duretion)
        {
            Rect currentRect = rawImage.uvRect;
            currentRect.y += speed * Time.deltaTime;
            rawImage.uvRect = currentRect;
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Rect finalRect = rawImage.uvRect;
        float step = 1f / totalSymbols;
        finalRect.y = targetSymbolId * step;
        rawImage.uvRect = finalRect;
        isSpinning = false;
    }

}
