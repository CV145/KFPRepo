using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that makes a game object shake every few secs.
/// </summary>
public class Shaker : MonoBehaviour
{
   // [SerializeField] float timeBetweenExpansions;
   // [SerializeField] Vector2 expandedSize;
    [SerializeField] float waitTimeBeforeTilting;
    [SerializeField] float timeBetweenTilts;
    [SerializeField] Vector3 tiltRotationRight;
    [SerializeField] Vector3 tiltRotationLeft;
    [SerializeField] int numOfTilts;
   // [SerializeField] float timeBeforeContracting;
    //Vector2 startSize;
    Vector3 startRotation;
    bool tiltedRight;

    // Start is called before the first frame update
    void Start()
    {
      //  startSize = transform.localScale;
        startRotation = transform.localEulerAngles;
        StartCoroutine(ChangeSize());
    }

   IEnumerator ChangeSize()
    {
        while (true)
        {
          //  yield return new WaitForSeconds(timeBetweenExpansions);
          //  transform.localScale = expandedSize;
            yield return new WaitForSeconds(waitTimeBeforeTilting);
            for (int count = 0; count < numOfTilts; count++)
            {
                yield return new WaitForSeconds(timeBetweenTilts);
                if (!tiltedRight)
                {
                    transform.localEulerAngles = tiltRotationRight;
                    tiltedRight = true;
                }
                else
                {
                    transform.localEulerAngles = tiltRotationLeft;
                    tiltedRight = false;
                }
            }
           // yield return new WaitForSeconds(timeBeforeContracting);
          //  transform.localScale = startSize;
            transform.localEulerAngles = startRotation;
        }
    }
}
