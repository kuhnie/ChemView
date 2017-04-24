/// @file    Rotator.cs
/// @author  Thomas Bolden (boldenth@msu.edu)
/// @date    Wed Apr 19 21:20:00 EST 2017
/// @brief   Implimenting Rotator class
///
/// Attach to any gameobject to make it rotate with cursor

using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------\\
 
public class Rotator : MonoBehaviour {

    // TODO: when the molecule is upside down, the movement is not intuitive
    //       so figure out how to fix this

    public float speed = 100f;

    bool rotating = false;

    // rotating the molecule
    // TODO: add VR
    // in VR, this should somehow work with the VR sticks/controllers
    // how much of this needs to change for that to work??
    // TODO: get meshcollider to cover whole molecule so can use OnMouseDrag
    // TODO: add zoom
    void Update(){

        // allows person to click anywhere and drag the object with
        // LEFT click
        if (Input.GetMouseButtonDown(0))
            rotating = true;

        // turns off rotation when left click is released (for drag)
        if (Input.GetMouseButtonUp(0))
            rotating = false;

        // can toggle rotation using RIGHT click
        if (Input.GetMouseButtonDown(1))
            rotating = !rotating;

        if (rotating){

            float xrot = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
            float yrot = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

            transform.Rotate(xrot*Vector3.down,  Space.Self);
            transform.Rotate(yrot*Vector3.right, Space.Self);

        }

    }
     
}