using UnityEngine;
using System.Collections;

public class movimientoCubo : MonoBehaviour {

   // public float velocidadDespzamiento;
   // public float velocidadGiro;
    //public float desplazamientoRD = 0;
   // public float desplazamientoRI = 0;
    public float giroI = 1f;
    public float giroD = 1f;
   	private float pos_anterior, pos_actual;
    public GameObject robotMalo = new GameObject();
    public bool move = false, r_malo = false, already_modif = false;
    private Vector3 modif;
    //private bool hide = false;

    // Use this for initialization
    void Start () 
    {
       /* velocidadDespzamiento = 40;
        velocidadGiro = 1f;*/
        if(!move)
        	robotMalo.GetComponent<TrailRenderer>().enabled=false; 
        pos_anterior = this.transform.position.z;
        modif = new Vector3();
    }
	
	// Update is called once per frame
	void Update () 
	{
		pos_actual = this.transform.position.z;
		if(move && pos_actual-pos_anterior >= 40 && !r_malo && !already_modif)
		{
	    	modif.x = 100;
	    	modif.z = 100;
	    	modif.y = robotMalo.transform.position.y;
	    	robotMalo.transform.position = modif;
	    	mover_malo();
    	}
        //if (Input.GetKey(KeyCode.UpArrow)){
        //    this.transform.Translate(Vector3.forward * velocidadDespzamiento * Time.deltaTime);
        //    desplazamientoRD++;
        //    desplazamientoRI++;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.RotateAround(GameObject.Find("ruedaDerecha").transform.position,Vector3.up,velocidadGiro);
        //    desplazamientoRI++;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.RotateAround(GameObject.Find("ruedaIzquierda").transform.position, Vector3.up, -velocidadGiro);
        //    desplazamientoRD++;
        //}
        //if (Input.GetKey(KeyCode.W)){
        //   // eje.transform.Rotate(Vector3.up*velocidadGiro);
        //    transform.RotateAround(GameObject.Find("ruedaIzquierdaMalo").transform.position, Vector3.up, -giroI*velocidadGiro);
        //    transform.RotateAround(GameObject.Find("ruedaDerechaMalo").transform.position, Vector3.up, giroD*velocidadGiro);

        //    //GameObject.Find("ruedaIzquierda").transform.Rotate(Vector3.up * velocidadGiro);
        //}
        //pos_actual = this.transform.position.x;
        //if (pos_actual-pos_anterior <= 40.0)
        //{
            //transform.RotateAround(GameObject.Find("ruedaIzquierda").transform.position, Vector3.up, -giroI * velocidadGiro);
           // GameObject.Find("ruedaIzquierda").transform.Rotate(Vector3.up, -giroI * velocidadGiro);
            //GameObject.Find("ruedaDerecha").transform.Rotate(Vector3.up, +giroD * velocidadGiro);
            //transform.RotateAround(GameObject.Find("ruedaDerecha").transform.position, Vector3.up, giroD * velocidadGiro);
            //pos_anterior = this.transform.position.x;
            //transform.RotateAround(GameObject.Find("ruedaIzquierdaMalo").transform.position, Vector3.up, -giroI * velocidadGiro);
            //transform.RotateAround(GameObject.Find("ruedaDerechaMalo").transform.position, Vector3.up, giroD * velocidadGiro);
       // }
		//
    }
    void mover_malo()
    {
    	robotMalo.GetComponent<movimientoCubo>().move = true;
    	robotMalo.GetComponent<TrailRenderer>().enabled=true; 
    	already_modif =  true;
    }
    void OnCollisionStay()
    {


    	if(move && !robotMalo.GetComponent<movimientoCubo>().move)
    	{
	        this.transform.Translate(Vector3.forward * 1f * Time.deltaTime);
	        this.transform.Translate(Vector3.right * giroD * Time.deltaTime);
	        this.transform.Translate(Vector3.left * giroI * Time.deltaTime);
	    }
	    else if(move && robotMalo.GetComponent<movimientoCubo>().move)
	    {
	    	this.transform.Translate(Vector3.forward * 1f * Time.deltaTime);
	        this.transform.Translate(Vector3.right * giroD * Time.deltaTime);
	        this.transform.Translate(Vector3.left * giroI * Time.deltaTime);
	    }
    }
}
