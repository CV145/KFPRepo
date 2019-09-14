using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Flashes a game object to red temporarily.
/// </summary>
public class RedFlasher : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color[] colors = { Color.yellow, Color.red };
    float flashDuration = 0.05f, intervalTime = 0.1f;
    Color originalColor;

    public void Awake()
    {

        renderer = GetComponent<SpriteRenderer>();
        originalColor = renderer.color;
    }
    
    /// <summary>
    /// Flash using the values given in the inspector.
    /// </summary>
    public void FlashColor()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        float elapsedTime = 0f;
        int index = 0;
        while (elapsedTime < flashDuration)
        {
            renderer.color = colors[index % 2];

            elapsedTime += Time.deltaTime;
            index++;
            yield return new WaitForSeconds(intervalTime);
        }
        renderer.color = originalColor;
    }

}
