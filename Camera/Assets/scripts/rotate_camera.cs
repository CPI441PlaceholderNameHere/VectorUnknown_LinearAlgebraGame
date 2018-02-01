using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_camera : MonoBehaviour {

    private Vector3 target;
    private float h_lock = 0.0f, v_lock = 0.0f;

    void Start () {
        target = GameObject.FindGameObjectWithTag("Center").transform.position;
        transform.LookAt(target);
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.RotateAround(target, Vector3.up, 45.0f);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.RotateAround(target, Vector3.down, 45.0f);
        if (Input.GetKeyDown(KeyCode.UpArrow) && v_lock < 36.0f)
        {
            transform.RotateAround(target, transform.TransformDirection(Vector3.right), 12.0f);
            v_lock += 15.0f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && v_lock > 0.0f)
        {
            transform.RotateAround(target, transform.TransformDirection(Vector3.left), 12.0f);
            v_lock -= 15.0f;
        }
    }
}
