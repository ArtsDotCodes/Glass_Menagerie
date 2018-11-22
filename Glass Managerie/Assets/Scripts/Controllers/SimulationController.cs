using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour {
    public static bool electronShouldFire =  false;

    public static bool speedWasSet = false;
    public static float speed = 0.0f;

    public static bool runWasSet = false;
    public static float run = 0.0f;

    public static bool varienceWasSet = false;
    public float varience = 0.0f;

    public static bool testObjectWasSet = false;
    public static int testObject = 0;




	// Use this for initialization


	void synchrotronReady(){
        if(speedWasSet && runWasSet && varienceWasSet && testObjectWasSet){
            electronShouldFire = true;
        }
    }
    public void setMember(string m, float f){
        switch (m){
            case "speed":
                speedWasSet = true;
                speed = f;
                break;
            case "run":
                runWasSet = true;
                run = f;
                break;
            case "var":
                varienceWasSet=true;
                varience = f;
                break;
            case "obj":
                testObjectWasSet = true;
                testObject= (int)f;
                break;

            default:
                break;
        }


    }
    public float getMember(string m){
        switch (m){
            case "speed":
                return speed;
                break;
            case "run":
                return run;
                break;
            case "var":
                return varience;
                break;
            case "obj":
                Debug.Log("getMember for obj is undefined, try getObj");
                return 0.0f;
                break;
            default:
                return 0.0f;
                break;
        }
}
    public int getProcedure(){
      int x =1;
        if(speedWasSet)x+=1;
        if(runWasSet)x+=1;
        if(varienceWasSet)x+=1;
        if(speedWasSet&&runWasSet&&varienceWasSet)x=0;
        if(speedWasSet&&runWasSet&&varienceWasSet&&testObjectWasSet)x=5;

        return x;
    }

    public int getTest(){
      return testObject;
    }

    public bool eShouldFire(){
        return electronShouldFire;
    }
	// Update is called once per frame
	void Update () {
		synchrotronReady();
    Debug.Log(speedWasSet +""+runWasSet+""+varienceWasSet+""+testObjectWasSet);
	}
}
