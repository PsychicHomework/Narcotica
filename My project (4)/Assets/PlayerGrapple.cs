using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    //public SpringJoint2D grappler;
    public Camera mainCamera;
  public LineRenderer _lineRenderer;
    public SpringJoint2D _distanceJoint;
    public MouseLocation ML;
    public bool isGrappling;
    public playermomentum pm;
    public CharacterMovement cm;





    // Start is called before the first frame update
    void Start()
    {
          _distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.LeftShift)){
        StartGrapple();
      }

      if(Input.GetKeyUp(KeyCode.LeftShift)){
        StopGrapple();
      }
      if (_distanceJoint.enabled) 
      {
        _lineRenderer.SetPosition(1, transform.position);
      }

      }
    
    void FixedUpdate()
    {
      _distanceJoint.distance -= 0.03f;

      if(Input.GetMouseButton(1))
      {
        _distanceJoint.distance -= .2f;
      }


    }




    private void StartGrapple()
    {
        Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _lineRenderer.SetPosition(0, ML.selectedObject.transform.position);
        _lineRenderer.SetPosition(1, transform.position);
        _distanceJoint.connectedAnchor = ML.selectedObject.transform.position;
        _distanceJoint.enabled = true;
        _lineRenderer.enabled = true;
        isGrappling = true;
    }

    private void StopGrapple(){
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
        ML.selectedObject = null;
        isGrappling = false;
        pm.momentum = pm.momentum + 3f;

    }
}
