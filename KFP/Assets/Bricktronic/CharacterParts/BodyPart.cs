using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public bool IsContainer;
    public Vector2 StartingScale = Vector2.one;
    Vector3 StartingForce;
    bool RotateDirection;
    private void Start()
    {
        if (IsContainer)
        {
            transform.localScale = this.StartingScale;
            foreach (Transform T in GetComponentsInChildren<Transform>())
            {
                if (T != this.transform)
                {
                    T.gameObject.AddComponent<BodyPart>();
                    T.gameObject.GetComponent<BodyPart>().StartingForce = (Player.PlayerObject.transform.position - T.position) * 0.001f;
                    T.gameObject.GetComponent<BodyPart>().StartingForce += (this.transform.position - T.position)*0.01f;

                    if(Random.Range(0, 2) == 1)
                    {
                            T.gameObject.GetComponent<BodyPart>().RotateDirection = true;
                    }
                }
            }
        }
    }

    private void Update()
    {
        transform.position -= new Vector3(StartingForce.x,StartingForce.y);

        if (RotateDirection)
        {
            transform.Rotate(new Vector3(0, 0, StartingForce.magnitude * 100));
        } else
        {
            transform.Rotate(new Vector3(0, 0, -StartingForce.magnitude * 100));
        }

        if(StartingForce.magnitude>0.2f)
        StartingForce *= 0.99f;
    }
}
