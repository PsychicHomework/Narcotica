using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocation : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layerMask;
    public GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = 10;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, layerMask);
            {
                if (hitData && Input.GetKeyDown(KeyCode.LeftShift))
                {
                    selectedObject = hitData.transform.gameObject;
                    Debug.Log("gay");
                }
            }

        transform.position = worldPosition;
        Cursor.visible = false;
    }

}