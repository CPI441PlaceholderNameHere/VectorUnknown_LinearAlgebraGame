using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controls : MonoBehaviour {

    [SerializeField]
    private grid_system Grid;

    void Start()
    {
        Grid = GameObject.FindObjectOfType<grid_system>();
        transform.position = Grid.GetNearestPointOnGrid(new Vector3(4, 0, 4)) + new Vector3( 0, 2.5f, 0);
        transform.LookAt(new Vector3(0, 2.5f, 0));
    }

    void Update() {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -45.0f * Time.deltaTime,0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 45.0f * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.W))
            transform.Rotate(-45.0f * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
            transform.Rotate(45.0f * Time.deltaTime ,0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            Camera.main.transform.position -= Vector3.left * .5f;
        if (Input.GetKey(KeyCode.RightArrow))
            Camera.main.transform.position += Vector3.left * .5f;
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Vector3 new_forward = transform.TransformDirection(Vector3.forward);
            //new_forward = Vector3.Normalize(new_forward);
            transform.position = Grid.GetNearestPointOnGrid(transform.position + new_forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 new_backward = transform.TransformDirection(Vector3.back);
            //new_backward = Vector3.Normalize(new_backward);
            transform.position = Grid.GetNearestPointOnGrid(transform.position + new_backward);
        }


        transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
    }
}
