using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float speed = 10f; //standard speed variable applied to the asset

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Allow the asset to be moved horizontally
        float h = Input.GetAxis("Horizontal");
        //Allow the asset to be moved vertically
        float v = Input.GetAxis("Vertical");

        //Create a position object for the asset
        Vector2 pos = transform.position;

        //Calculate the assets current horizontal and vertical postion in relation to the position object as it is moved
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        //Apply the calculated new position to the position object
        transform.position = pos;
        
    }
}
