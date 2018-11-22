using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialUIcontroller : MonoBehaviour {
	private GameObject m1;
	private GameObject m2;
	private GameObject m3;




	// Use this for initialization
	void Start () {
			 m1=this.transform.Find ("hollowparticle").gameObject;
			 m1.SetActive(false);

			 m2=this.transform.Find ("dna3").gameObject;
		  m2.SetActive(false);

		 m3=this.transform.Find ("gold_nanostar").gameObject;
		 m3.SetActive(false);




	}
	void setMaterial(int i){

		Debug.Log(i);
			switch (i){
				  case 0:
							break;
					case 1:
							m1.SetActive(true);

							break;
					case 2:
							m2.SetActive(true);

							break;
					case 3:
							m3.SetActive(true);
							break;
			}

	}


	// Update is called once per frame
	void Update () {
	GameObject Variableholder = GameObject.Find("Variableholder");
	setMaterial(Variableholder.GetComponent<SimulationController>().getTest());

	}

}
