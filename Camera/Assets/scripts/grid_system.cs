using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_system : MonoBehaviour {

    [SerializeField]

    private float size = 5f;
    private Vector3 center;

    void Awake()
    {
        center = GetNearestPointOnGrid(new Vector3(10, 0, 10)) - GetNearestPointOnGrid(new Vector3(0, 0, 0));
        center = center / 2;
        //GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform.position = center;
        Debug.Log(center.ToString());
    }

	public Vector3 GetNearestPointOnGrid( Vector3 position)
    {//converts a floating point "natural position" into a gridspace position

        position -= transform.position;

        int pos_x = Mathf.RoundToInt( position.x / size);
        int pos_y = Mathf.RoundToInt( position.y / size);
        int pos_z = Mathf.RoundToInt( position.z / size);

        Vector3 result = new Vector3(
            (float)pos_x * size,
            (float)pos_y * size,
            (float)pos_z * size);

        result += transform.position;

        return result;
    }

    public void OnDrawGizmos()
    {//visual debugging
        Gizmos.color = Color.green;

        for( float x = 0; x < 10; x += size)
        {
            for( float z = 0; z < 10; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0.0f, z)) - center;
                Gizmos.DrawSphere(point, 0.1f);
            }
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(center, .25f);
        Gizmos.DrawSphere(new Vector3(5, 0, 5), .25f);

    }

    public float Size(){ return size; }

    public Vector3 Center(){ return center;}

}
