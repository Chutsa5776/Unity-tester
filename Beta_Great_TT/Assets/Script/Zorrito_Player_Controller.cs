using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;
         position.x = position.x + 6.5f * horizontal * Time.deltaTime;
        transform.position = position;
        
    }


}
