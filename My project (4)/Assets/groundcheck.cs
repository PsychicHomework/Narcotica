using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    public bool grounded;
    public bool airjumpfill;
    public bool OnPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            airjumpfill = true;
        }
        if(other.gameObject.CompareTag("Platform"))
        {
            OnPlatform = true;
            grounded = true;
            airjumpfill = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            airjumpfill = false;
            
        }
        if(other.gameObject.CompareTag("Platform"))
        {
            OnPlatform = false;
            grounded = false;
            airjumpfill = false;
        }
    }
}
