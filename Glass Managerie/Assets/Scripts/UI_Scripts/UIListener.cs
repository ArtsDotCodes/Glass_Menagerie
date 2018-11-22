using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;


public class UIListener : MonoBehaviour {
	  public GameObject LeftController;
	  public GameObject RightController;

		private GameObject electronspeed;
	  private GameObject lengthOfRun;
	  private GameObject electronvarience;
	  private GameObject testObject;
	  GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
		GameObject rig;



		private SteamVR_TrackedObject LEFT;
    private SteamVR_TrackedObject RIGHT;

		private SteamVR_Controller.Device l;
    private SteamVR_Controller.Device r;

// Use this for initialization
void Start () {
	     //electronspeed =this.transform.Find ("electronspeed").gameObject;
			 //lengthOfRun =  this.transform.Find("lengthOfRun").gameObject;
			 //electronvarience = this.transform.Find("electronvarience").gameObject;
			 //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();


        LEFT = LeftController.GetComponent<SteamVR_TrackedObject>();
        RIGHT = RightController.GetComponent<SteamVR_TrackedObject>();
				l = SteamVR_Controller.Input((int)LEFT.index);
        r = SteamVR_Controller.Input((int)RIGHT.index);

}

				void Update () {
					GameObject Variableholder = GameObject.Find("Variableholder");
         Variableholder.GetComponent<SimulationController>().getProcedure();
				 if (Input.GetKey(KeyCode.Mouse1))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;
            Debug.Log(Input.mousePosition);
            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
        }
				else if (l.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)||r.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
					m_PointerEventData = new PointerEventData(m_EventSystem);
					//Set the Pointer Event Position to that of the mouse position
					if(l.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
					m_PointerEventData.position = LeftController.transform.position;
					Debug.Log(LEFT.transform.position);
				}else if(l.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)){
					m_PointerEventData.position = RIGHT.transform.position;
					}
					//Create a list of Raycast Results
					List<RaycastResult> results = new List<RaycastResult>();

					//Raycast using the Graphics Raycaster and mouse click position
					m_Raycaster.Raycast(m_PointerEventData, results);

					//For every result returned, output the name of the GameObject on the Canvas hit by the Ray
					foreach (RaycastResult result in results)
					{
							Debug.Log("Hit " + result.gameObject.name);
					}
				}
				}
}
