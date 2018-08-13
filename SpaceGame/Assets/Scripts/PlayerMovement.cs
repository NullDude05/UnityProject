using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float rotSpeed;

    [SerializeField]
    float boostSpeed;

    float playerBoundaryRadius = 0.5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveShip();
	}

    void MoveShip()
    {

        //Grab rotation quaternion
        Quaternion rot = transform.rotation;
        //Grab the z euler angle
        float z = rot.eulerAngles.z;
        //Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);
        //Feed the quaternion into our rotation
        transform.rotation = rot;


        Vector3 pos = transform.position;

        if (Input.GetButton("Fire2"))
        {
            Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * boostSpeed * Time.deltaTime, 0);
            pos += rot * velocity;
        }
        else
        {
            Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
            pos += rot * velocity;
        }

        // Boundaries vertical
        if (pos.y+playerBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - playerBoundaryRadius;
        }
        if (pos.y-playerBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + playerBoundaryRadius;
        }

        //Boundaries horizontal
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + playerBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - playerBoundaryRadius;
        }
        if (pos.x - playerBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + playerBoundaryRadius;
        }


        transform.position = pos;
    }
}
