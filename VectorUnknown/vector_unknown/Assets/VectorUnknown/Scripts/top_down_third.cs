using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top_down_third : MonoBehaviour {

    [SerializeField]
    private Vector3 center;

	void Start () {
        center = GameObject.FindWithTag("Center").transform.position;
        Camera.main.transform.position = center + new Vector3(0, 20, 0);
        Camera.main.transform.LookAt(center);
	}
}
