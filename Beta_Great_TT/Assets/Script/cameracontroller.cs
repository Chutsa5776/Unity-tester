using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{

    public Transform personaje; 
    private float tamañoCamara;
    private float alturaPantalla;

    // Start is called before the first frame update
    void Start()
    {
        tamañoCamara = Camera.main.orthographicSize;
        alturaPantalla = tamañoCamara*2;
    }

    // Update is called once per frame
    void Update()
    {
      calcularPosicionCamara();  
    }

    void calcularPosicionCamara()
    {
        int pantallaPersonaje = (int) (personaje.position.x / alturaPantalla);
        float alturaCamara = (pantallaPersonaje + alturaPantalla) + tamañoCamara;
        Transform.position = new vector3(Transform.position.x, alturaCamara, Transform.position.z);
    }
}
