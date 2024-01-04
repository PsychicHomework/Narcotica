using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpslimiter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake () {
	QualitySettings.vSyncCount = 0;  // VSync must be disabled
	Application.targetFrameRate = 240;
}
}
