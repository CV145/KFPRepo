using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicZoom : MonoBehaviour
{
    public bool FoundEnemy;
    Vector3 OriginalCamPos;

    private void Start()
    {
        StartCoroutine(DestroyWait());
    }

    public IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(14);
        StartCoroutine(DestroyCheck());
    }

    public IEnumerator DestroyCheck()
    {
        yield return new WaitForEndOfFrame();
        if (!FoundEnemy)
        {
            Destroy(gameObject);
        } else
        {
            StartCoroutine(DestroyCheck());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!FoundEnemy)
        {
            if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyHealth>())
            {
                Mover.gameIsPaused = true;
                Camera.main.GetComponent<CameraFocuser>().enabled = false;
                OriginalCamPos = Camera.main.transform.position;
                Vector3 GoPos = collision.gameObject.transform.position;
                StartCoroutine(ZoomIn(GoPos));
                FoundEnemy = true;
            }
        }
    }

    public IEnumerator ZoomIn(Vector3 GO)
    {
        yield return new WaitForFixedUpdate();

        if (GO!=null)
        {
            if (Vector3.Distance(Camera.main.transform.position,GO)>0.2f || Camera.main.orthographicSize>3.4f)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, GO, 0.1f);

                if (Camera.main.orthographicSize > 2.5f)
                    Camera.main.orthographicSize -= 0.1f;

                StartCoroutine(ZoomIn(GO));
            }
            else
            {
                StartCoroutine(ZoomBack());
            }
        } else
        {
            StartCoroutine(ZoomBack());
        }
    }

    public IEnumerator ZoomBack()
    {
        yield return new WaitForEndOfFrame();

        if (Vector3.Distance(Camera.main.transform.position, OriginalCamPos) > 0.2f || Camera.main.orthographicSize!=8)
        {
            if (Camera.main.orthographicSize < 8)
            {
                Camera.main.orthographicSize += 0.1f;
            } else
            {
                Camera.main.orthographicSize = 8;
            }

            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, OriginalCamPos, 0.1f);
            StartCoroutine(ZoomBack());
        } else
        {
            Camera.main.GetComponent<CameraFocuser>().enabled = true;
            Mover.gameIsPaused = false;
            FoundEnemy = false;
        }
    }
}
