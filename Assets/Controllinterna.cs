using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllinterna : MonoBehaviour
{

    Light linterna;
    bool encendida = true;

    // Start is called before the first frame update
    void Start()
    {
        linterna = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))

        {
            encendida = !encendida;
            linterna.enabled = encendida;
        }

    }
}
