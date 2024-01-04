using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermomentum : MonoBehaviour
{
    public float momentum;
    public groundcheck GC;
    public wallcheck WC;
    public PlayerDash PD;
    public CharacterMovement CM;
    public PlayerGrapple PG;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GC.grounded == true)
        {
            momentum = momentum * .9f;
        }

        if (GC.grounded == false)
        {
            momentum = momentum * .97f;
        }

        if (PD.dashingleft == true || PD.dashingright == true)
        {
            if (momentum < 2)
            {
                momentum = momentum + .23f;
            }
            if (momentum > 2)
            {
                momentum = momentum + .05f;
            }

        }



        if (CM.walljumping == true)
        {
            momentum = momentum + .3f;
        }




    }
    
    void Update()
    {
        if (momentum < 0)
        {
            momentum = 0;
        }
        
        if (momentum > 6f)
        {
            momentum = 6f;
        }
        
    }
}
