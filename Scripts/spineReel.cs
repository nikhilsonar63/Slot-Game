using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    private RawImage rawImage;
    private bool isSpinning = false;

    // Get the RawImage component from this reel
    private void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Start spinning the reel if it is not already spinning
    public void startSpinning(float duretion,float speed,int targetSymbolId,int totalSymbols)
    {
        if (!isSpinning)
        {
            StartCoroutine(spineRell(duretion, speed, targetSymbolId, totalSymbols));
        }
    }

    // Handles the reel spinning animation
    public IEnumerator spineRell(float duretion,float speed,int targetSymbolId,int totalSymbols)
    {
        isSpinning = true;
        float elapsedTime = 0f;

        // Keep moving the reel until the duration is complete
        while (elapsedTime < duretion)
        {
            Rect currentRect = rawImage.uvRect;
            currentRect.y += speed * Time.deltaTime;
            rawImage.uvRect = currentRect;

            // Wait for the next frame
            yield return null;

            elapsedTime += Time.deltaTime;
        }

        // Calculate the final position of the target symbol
        Rect finalRect = rawImage.uvRect;
        float step = 1f / totalSymbols;
        finalRect.y = targetSymbolId * step;
        rawImage.uvRect = finalRect;

        // Mark the reel as no longer spinning
        isSpinning = false;
    }

}
