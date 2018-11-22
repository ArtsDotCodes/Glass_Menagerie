using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {
    private GameObject i1;
    private GameObject i2;
    private GameObject i3;
    private GameObject i4;

    private GameObject c ;
    private GameObject c1;
    private GameObject c2;
    private GameObject b;




	// Use this for initialization
	void Start () {
		     i1=this.transform.Find ("instruction1").gameObject;
         i1.SetActive(true);

         i2=this.transform.Find ("instruction2").gameObject;
       i2.SetActive(false);

       i3=this.transform.Find ("instruction3").gameObject;
       i3.SetActive(false);

       i4=this.transform.Find ("instruction4").gameObject;
       i4.SetActive(false);

       c = GameObject.Find("controlpanel").gameObject;
       c1 = c.transform.Find("Controls").gameObject;
       c1.SetActive(true);
       c2 = GameObject.Find("MaterialHolder").gameObject;
       c2.SetActive(false);
       b = GameObject.Find("Selector").gameObject;
       b.SetActive(false);



	}
    void setScreen(int i){
      Debug.Log(i);
        switch (i){
            case 1:
                i1.SetActive(true);
                i2.SetActive(false);
                i3.SetActive(false);
                i4.SetActive(false);
                break;
            case 2:
                i1.SetActive(true);
                i2.SetActive(true);
                i3.SetActive(false);
                i4.SetActive(false);
                break;
            case 3:
                i1.SetActive(true);
                i2.SetActive(true);
                i3.SetActive(true);
                i4.SetActive(false);
                break;
            case 0:
                i1.SetActive(false);
                i2.SetActive(false);
                i3.SetActive(false);
                i4.SetActive(true);
                c1.SetActive(false);
                c2.SetActive(true);
                b.SetActive(true);
                break;
            case 5:
            i1.SetActive(false);
            i2.SetActive(false);
            i3.SetActive(false);
            i4.SetActive(true);
            c1.SetActive(false);
            c2.SetActive(false);
            b.SetActive(false);
            
            break;
        }
    }


	// Update is called once per frame
	void Update () {
		GameObject Variableholder = GameObject.Find("Variableholder");
  setScreen(Variableholder.GetComponent<SimulationController>().getProcedure());

	}
}
