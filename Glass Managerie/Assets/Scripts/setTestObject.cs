using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setTestObject : MonoBehaviour {
	private float v;
	public Button thisButton;
	public int buttonID;
	// Use this for initialization
	void Start () {
		thisButton.onClick.AddListener(delegate {sendValue(); });
	}
	void sendValue(){

		GameObject Variableholder = GameObject.Find("Variableholder");
	 Variableholder.GetComponent<SimulationController>().setMember("obj",buttonID);
	}

	// Update is called once per frame
}
