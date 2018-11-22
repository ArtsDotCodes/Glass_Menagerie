using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    private float rotation = 2;
	// Use this for initialization


	// Update is called once per frame
	void Update ()
    {
        transform.Rotate (new Vector3 ((3), (-3), (3)) );
	}
}
