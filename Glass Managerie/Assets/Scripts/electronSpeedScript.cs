using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class electronSpeedScript : MonoBehaviour {
  private float v;
	public Slider thisSlider;
	public string updateValue;
	// Use this for initialization
	void Start () {
		thisSlider.onValueChanged.AddListener(delegate {updateSpeed(); });
	}
	void updateSpeed(){
		v = thisSlider.value * 60f;
		GameObject Variableholder = GameObject.Find("Variableholder");
		if(v > 0){
	 Variableholder.GetComponent<SimulationController>().setMember(updateValue,v);}
	}

	// Update is called once per frame
	void Update () {
		GameObject Variableholder = GameObject.Find("Variableholder");
		if(v > 0){
	 Variableholder.GetComponent<SimulationController>().setMember(updateValue,v);}
	}
}
