using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public bool IsContainer;
    public Vector2 StartingScale = Vector2.one;
    Vector2 StartingForce;
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
                    T.gameObject.GetComponent<BodyPart>().StartingForce = (this.transform.position - T.position)*5000;
                }
            }
        }
        else
        {
            gameObject.AddComponent<PolygonCollider2D>();
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<BodyPart>().AddForce(StartingForce);
        }
        Destroy(this.gameObject, 5);
    }

    public void AddForce(Vector2 Vel)
    {
        if(Vel.magnitude>0)
        this.GetComponent<Rigidbody2D>().AddForce(Vel);
    }
}
