using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireElectron : MonoBehaviour {
// Require the rocket to be a rigidbody.
// This way we the user can not assign a prefab without rigidbody

public GameObject electron;
public GameObject aps;
public GameObject rps;
public GameObject cps;

void Fire () {

    GameObject electronClone = (GameObject) Instantiate(electron, transform.position, transform.rotation);

    // You can also access other components / scripts of the clone
    
    electronClone.GetComponent<Acceleration>().Start();
}

// Calls the fire method when holding down ctrl or mouse
void Update () {
  GameObject Variableholder = GameObject.Find("Variableholder");
    if (Input.GetButtonDown("Fire1") && Variableholder.GetComponent<SimulationController>().eShouldFire() ) {
        Fire();
    }
}
}
