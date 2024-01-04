using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcheck : MonoBehaviour
{
    public bool canwalljump;
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
        if(other.gameObject.CompareTag("Wall"))
        {
            canwalljump = true;
        }
        if(other.gameObject.CompareTag("Ground"))
        {
            canwalljump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            canwalljump = false;
        }
        if(other.gameObject.CompareTag("Ground"))
        {
            canwalljump = false;
        }
    }
}
