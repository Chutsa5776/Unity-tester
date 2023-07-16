using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
       // Application.targetFrameRate = 60;
    }

    // Update is called once per frame

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;
         position.x = position.x + 3.5f * horizontal * Time.deltaTime;
        transform.position = position;
        
    }


}
