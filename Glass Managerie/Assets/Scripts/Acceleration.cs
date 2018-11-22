using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour {
    private Rigidbody rb;

    public float speed;
    public float run;
    public float timer;
    public float angle;
    public float centerx;
    public float rad;
    public float centery;
    public float centerz;
    public int currentspeed = 1;
    private GameObject data;
    public GameObject aParticles;
    public GameObject rParticles;
    public GameObject cParticles;
    public GameObject sParticles;
    GameObject a;
    GameObject r;
    GameObject c;
    GameObject s;
    AudioSource[] audios;



    public void Start()
    {
        centerx= -1074f;
        centery= 16125f;
        centerz= 11082f;
        rad = 400f;
        audios = GetComponents<AudioSource>();
        data = GameObject.Find("Variableholder").gameObject;
        speed = data.GetComponent<SimulationController>().getMember("speed");
        run = data.GetComponent<SimulationController>().getMember("run") + speed;
        
        r =Instantiate(rParticles, transform.position, transform.rotation);
    }

    private void FixedUpdate()

    {

      bool how = true;
      Debug.Log(speed+" "+run);
        timer += Time.deltaTime;
        audios[0].loop=true;
        audios[0].Play();
        if(timer <= speed){


        angle = timer*timer;
        Vector3 prevPosition =  this.transform.position;
        this.transform.position = new Vector3((centerx + Mathf.Sin(angle) * rad), centery, ((centerz + Mathf.Cos(angle) * rad)));
        a = Instantiate(aParticles);
         }else
        if(timer > speed && timer < run){


              angle = timer;
            centerx = -4400f ;centery = 16070f;centerz = 8072f;rad=4500;
            angle = timer * speed;
        Vector3 prevPosition =  this.transform.position;
        this.transform.position = new Vector3((centerx + Mathf.Sin(angle) * rad), centery, ((centerz + Mathf.Cos(angle) * rad)));

      }else if(timer > run){

        Debug.Log("FIRE IN THE HOLE!");
         if(c == null){
           Debug.Log("shooting");

          c = Instantiate(cParticles);
          c.GetComponent<ParticleSystem>().Play();

        }else if(s==null && c.GetComponent<ParticleSystem>().isStopped){
          Debug.Log("collecting data");
          s=Instantiate(sParticles);
          s.GetComponent<ParticleSystem>().Play();
        }else if(c.GetComponent<ParticleSystem>().isStopped && s.GetComponent<ParticleSystem>().isStopped){
          Debug.Log("cycle complete, now destroying electron");
          Destroy(a);
          Destroy(c);
          Destroy(s);
          Destroy(this);
}
        }
    }


}
