using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCircle : MonoBehaviour {

	float timeCounter = 0;
	public double speed;
    public double diameter;
    int timesPassed;
	GameObject Player;
	
	// Use this for initialization
    // In the example just hit the box with your steam controller
	void Start () {
		transform.position = new Vector3 (-1065f, this.transform.position.y , 11100f);
		speed = Random.Range(1,5);
		diameter = Random.Range(200, 300);
	}
	
	// Update is called once per frame
    // This update changes the location of the sphere in a circular pattern using the sin & cosin values based upon the current time in game
    // You can change the speed and the diamater of the circlular path it takes
	void Update () {
        //Debug.Log(Time.deltaTime * 2);
        //Input.GetAxis("Horizontal") * 
        if (timesPassed < 5)
        {
            timeCounter += Time.deltaTime * (float)speed;
            float x = ((float)diameter * Mathf.Cos(timeCounter)) - 1065;
            float z = ((float)diameter * Mathf.Sin(timeCounter)) + 11110;
            transform.position = new Vector3(x, this.transform.position.y, z);
            Debug.Log(transform.position);
        }
        else
        {
            // The step size is equal to speed times frame time.
            float step = (float) (speed/10000f);
            GameObject pointToMove = GameObject.Find("result");

            Vector3 target = pointToMove.transform.position;
            // Move our position a step closer to the target.
            this.transform.position = Vector3.MoveTowards(this.transform.position, pointToMove.transform.position, step);

        }
		//GameObject Player = GameObject.Find("Player");
		//float dist = Vector3.Distance(Player.transform.position, transform.position);
        //print("Distance to other: " + dist);
	}

    // Each time it circles the accelerator it adds to the timesPassed variable
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "wall" && timesPassed < 6)
        {
            timesPassed += 1;
        }
    }
}