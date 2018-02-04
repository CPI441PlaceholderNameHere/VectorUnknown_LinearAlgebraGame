using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour {

    [SerializeField]
    private grid_system Grid;
	
    void Awake()
    {
        Grid = FindObjectOfType<grid_system>();
    }

    void Start()
    {

        for (float x = 0; x < 10; x += Grid.Size())
               {
                   for (float z = 0; z < 10; z += Grid.Size())
                   {
                       var point = Grid.GetNearestPointOnGrid(new Vector3(x, 0.0f, z)) - Grid.Center();
                       GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                       sphere.transform.position = point;
                   }
               }
    }
    
    void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit info;
            Ray romano = Camera.main.ScreenPointToRay(Input.mousePosition);

            if( Physics.Raycast( romano, out info))
            {
                PlaceCubeOnGrid(info.point);
            }
        }
	}

    private void PlaceCubeOnGrid( Vector3 point)
    {
        var grid_position = Grid.GetNearestPointOnGrid(point);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = grid_position;
    }
}
