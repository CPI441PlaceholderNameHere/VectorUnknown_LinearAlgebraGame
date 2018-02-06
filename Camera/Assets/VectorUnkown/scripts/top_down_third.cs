using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top_down_third : MonoBehaviour {

    [SerializeField]
    private Vector3 center;//Center GameObject
	/*private GameObject follow;//transform to smoothly follow
	private Vector3 velocity = Vector3.zero;//camera follow velocity
	public float smooth = 0.3f, distance = -20.0f, yVelocity = 0.0f;*/

	void Start () {
        center = GameObject.FindWithTag("Center").transform.position;
		//follow = GameObject.FindWithTag ("Follow1");

		transform.position = center + new Vector3(0, 20, 0);
		//follow.transform.position = transform.position;
		//follow.transform.LookAt(center);
        transform.LookAt(center);
	}

	void Update(){

		/*if (Input.GetKeyDown(KeyCode.LeftArrow))
			follow.transform.RotateAround(center, Vector3.up, 45.0f);
		if (Input.GetKeyDown(KeyCode.RightArrow))
			follow.transform.RotateAround(center, Vector3.down, 45.0f);

		float angle = Mathf.SmoothDampAngle (transform.eulerAngles.z, follow.transform.eulerAngles.z, ref yVelocity, smooth);
		Vector3 position = follow.transform.position;
		position += Quaternion.Euler (0, 0, angle) * new Vector3(0,0,distance);
		transform.position = position;
		//transform.position = Vector3.SmoothDamp (transform.position, follow.transform.position, ref velocity, 0.3f);
		transform.LookAt ( center);*/
	}
}
