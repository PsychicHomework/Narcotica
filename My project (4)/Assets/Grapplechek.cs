using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapplechek : MonoBehaviour
{
    public bool GrappleEnabled = false;
    public Collider2D GrapplerCollider;
    public Collider2D GrapplerPointCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GrapplerCollider.IsTouching(GrapplerPointCollider))
        {
            GrappleEnabled = true;
        }
        else
        {
            GrappleEnabled = false;
        }
    }
    


}
