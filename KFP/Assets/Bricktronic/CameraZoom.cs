using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    int OriginalSize = 5;
    public void DoZoom(GameObject G)
    {
        StartCoroutine(ZoomTo(G,Camera.main.transform.position));
    }

    public IEnumerator ZoomTo(GameObject GO, Vector3 OriginalPosition)
    {
        yield return new WaitForFixedUpdate();
        if (Camera.main.transform.position != GO.transform.position)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, GO.transform.position, 0.1f);
            StartCoroutine(ZoomTo(GO, Camera.main.transform.position));
        } else
        {
            StartCoroutine(ZoomOut(OriginalPosition));
        }
    }

    public IEnumerator ZoomOut(Vector3 OriginalPosition)
    {
        yield return new WaitForFixedUpdate();
        if (Camera.main.transform.position != OriginalPosition)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, OriginalPosition, 0.2f);
            StartCoroutine(ZoomOut(OriginalPosition));
        }
    }
}
