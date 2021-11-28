using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField]
    private float minX, maxX;

    private Transform player;
    private Vector3 temporaryPosition;

    private string Player_Tag = "Player";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(Player_Tag).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        temporaryPosition = transform.position;
        temporaryPosition.x = player.position.x;

        //Checks if the camera has reached the end of the available level area, if so, camera will stop
        if(temporaryPosition.x < minX){
            temporaryPosition.x = minX;
        }else if(temporaryPosition.x > maxX){
            temporaryPosition.x = maxX;
        }

        transform.position = temporaryPosition;
    }
}
