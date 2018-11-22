using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class camerabehavior : MonoBehaviour {
    public Camera mainCam ;
    public GameObject rigVR;

    public SteamVR_TrackedObject LEFT ;
    public SteamVR_TrackedObject RIGHT ;

    public SteamVR_Controller.Device l;
    public SteamVR_Controller.Device r;

    private AudioSource correctAudio;
    private AudioSource errorAudio;

    private string mode;

    private static Vector3 outsideView = new Vector3(-1102f,16102f,13762f);
    private static Quaternion outsideRotation = Quaternion.Euler(0,180,0);

    private static Vector3 controlView= new Vector3(714f,15992f,10332.5f);
    private static Quaternion controlRotation = Quaternion.Euler(0f,-236.19f,0f);

    private static Vector3 accelleratorView = new Vector3(-1102f,16102f,10583f);
    private static Quaternion accelleratorRotation = Quaternion.Euler(0,0,0);

    private static Vector3 materialView = new Vector3(560.1f,16045.9f,10412.1f);
    private static Quaternion materialRotation = Quaternion.Euler(0f,-185.866f,0f);

    private static Vector3 pipeView;
    private static Vector3 resultView;

    private static Vector3 [] positions = new [] {outsideView,controlView,accelleratorView,materialView};
    private static Quaternion [] angles = new [] {outsideRotation,controlRotation,accelleratorRotation,materialRotation};

    private int cursor = 0;

    void Start(){
      AudioSource[] audios = GetComponents<AudioSource>();
     errorAudio = audios[0];
     correctAudio = audios[1];

      if(rigVR != null){
        mode="VR";
        GameObject rig = GameObject.Find("[CameraRig]");
      LEFT = rig.transform.Find("Controller (left)").GetComponent<SteamVR_TrackedObject>();
      RIGHT = rig.transform.Find("Controller (right)").GetComponent<SteamVR_TrackedObject>();
      }else if(mainCam != null){
        mode = "2D";
      }else{
        mode="NO CAMERA!";
      }
      mainCam.transform.position = positions[0];
      mainCam.transform.rotation = angles[0];

      rigVR.transform.position = positions[0];
      rigVR.transform.rotation = angles[0];


    }
	// Use this for initialization
	void cCP (int s) {
		if(cursor == 0 && s == -1){
          errorAudio.Play();
        }else if(cursor == 3 && s == 1){
          errorAudio.Play();
        }else {
          cursor += s;
          correctAudio.Play();
            mainCam.transform.position = positions[cursor];
            mainCam.transform.rotation = angles[cursor];
        }
	}

  void rigCP(int s){
    if(cursor == 0 && s == -1){
          errorAudio.Play();
        }else if(cursor == 3 && s == 1){
          errorAudio.Play();
        }else {
          cursor += s;
          correctAudio.Play();
          rigVR.transform.position = positions[cursor];
          rigVR.transform.rotation = angles[cursor];
        }
  }

	// Update is called once per frame
	void Update () {
        if(mode=="2D"){
		    if(Input.GetKeyDown("right")){
            cCP(1);
        }else if(Input.GetKeyDown("left")){
            cCP(-1);
        }
      }else if(mode=="VR"){
        l = SteamVR_Controller.Input((int)LEFT.index);
        r = SteamVR_Controller.Input((int)RIGHT.index);
        if( Input.GetKeyDown("right") || (l.GetAxis().x > 0 && l.GetPressDown(SteamVR_Controller.ButtonMask.Axis0))||(r.GetAxis().x < 0 && r.GetPressDown(SteamVR_Controller.ButtonMask.Axis0))){
            rigCP(1);
        }else if( Input.GetKeyDown("left") || (l.GetAxis().x < 0 && l.GetPressDown(SteamVR_Controller.ButtonMask.Axis0)) ||(r.GetAxis().x < 0 && r.GetPressDown(SteamVR_Controller.ButtonMask.Axis0)) ){
            rigCP(-1);
        }
      }

	   }

}
