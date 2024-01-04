using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerDash : MonoBehaviour
{
    float delaybetweenPresses = 0.25f;
    bool pressedfirst = false;
    float lastpressed;
    public bool dashingright = false;
    public bool dashingleft = false;

    public CharacterMovement CM;
    public float dashspeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private async void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && dashingleft == false && dashingright == false){
            if (pressedfirst){
                bool isdoublepress = Time.time - lastpressed <= delaybetweenPresses;

                if (isdoublepress){
                    Dashright();
                }
            }
            else{
                pressedfirst = true;
            }     
            lastpressed = Time.time;

        }

        if (pressedfirst && Time.time - lastpressed > delaybetweenPresses)
        {
            dashingright = false;
        }



////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.A) && dashingleft == false && dashingright == false){
            if (pressedfirst){
                bool isdoublepress = Time.time - lastpressed <= delaybetweenPresses;

                if (isdoublepress){
                    Dashleft();
                }
            }
            else{
                pressedfirst = true;
            }     
            lastpressed = Time.time;

        }

        if (pressedfirst && Time.time - lastpressed > delaybetweenPresses)
        {
            dashingleft = false;
        }



/////////////////////





    }
    private async void Dashleft(){

        dashingleft = true;
        CM.maxSpeed = 100f;
        CM.pbody.AddForce(transform.right * -300);
        await DashTime();
        CM.maxSpeed = 7f;


    }


    private async void Dashright(){

        dashingright = true;
        CM.maxSpeed = 100f;
        CM.pbody.AddForce(transform.right * 300);
        await DashTime();
        CM.maxSpeed = 7f;




    }
    

    private static async Task DashTime()
    {
        await Task.Delay(100);
    }
}
