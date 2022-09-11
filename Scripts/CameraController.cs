using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    public BoxCollider2D boundsBox;

    private float halfHeight, halfWidth;
    
    

    // Start is called before the first frame update
    void Start()
    {
        // find the object with script PlayerController
        player = FindObjectOfType<PlayerController>();

        // radius of camera in y
        halfHeight = Camera.main.orthographicSize;
        // aspect ratio of the screen (full HD)
        halfWidth = halfHeight * Camera.main.aspect;

    }


    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            // moving the camera to the player
            // set the camera pos to player's x,y but do not change the z axis
            this.transform.position = new Vector3(
                // Mathf.Clamp(value you wish to clamp, min, max)
                // if value is within range, returns value else returns min or max
                // no z position because it's 2D
                Mathf.Clamp(player.transform.position.x, boundsBox.bounds.min.x+halfWidth, boundsBox.bounds.max.x-halfWidth),
                Mathf.Clamp(player.transform.position.y, boundsBox.bounds.min.y+halfHeight, boundsBox.bounds.max.y-halfHeight),
                this.transform.position.z);


        }
    }
}
