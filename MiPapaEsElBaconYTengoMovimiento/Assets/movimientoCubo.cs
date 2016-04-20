using UnityEngine;
using System.Collections;
using System;

public class movimientoCubo : MonoBehaviour 
{

   // public float velocidadDespzamiento;
   // public float velocidadGiro;
    //public float desplazamientoRD = 0;
   // public float desplazamientoRI = 0;
    public float giroI = 1f;
    public float giroD = 1f;
    private int rotate_count = 0;
   	private float pos_anterior, pos_actual, pos_local;
   	private float pos_anterior_x, pos_actual_x, pos_local_x;
   	private double x_final, x_inicial,h_desviacion;
    public GameObject robotMalo = new GameObject();
    public bool move = false, r_malo = false, already_modif = false, already_rotate = false;
    private Vector3 modif;
    //private bool hide = false;

    // Use this for initialization
    void Start () 
    {
       /* velocidadDespzamiento = 40;
        velocidadGiro = 1f;*/
        if(!move)
        	robotMalo.GetComponent<TrailRenderer>().enabled=false; 
        pos_local = pos_anterior = this.transform.position.z;
        pos_local_x = pos_anterior_x = this.transform.position.x;
		x_inicial = pos_anterior_x + 40f;
        modif = new Vector3();
    }
	
	// Update is called once per frame
	void Update () 
	{
		pos_actual = this.transform.position.z;
		x_final = pos_actual_x = this.transform.position.x;
		//calculo de la desviacion respecto al perfecto
		//la h_desviacion segun pitagoras deberia ser la distancia real que ha recorrido r_malo
		h_desviacion = Math.Sqrt(Math.Pow(x_final-x_inicial, 2)+Math.Pow(x_inicial, 2));
		
		if(move && pos_actual-pos_anterior >= 40 && !r_malo && !already_modif)
		{
	    	modif.x = 100;
	    	modif.z = 100;
	    	modif.y = this.transform.position.y;
	    	robotMalo.transform.position = modif;
	    	mover_malo();
    	}
    	/*
			En projecto para hacer un cuadrado perfecto recorriendo las
			mismas distacia ambos.
    	*/
    	/*if(r_malo && h_desviacion >= 140f)
    		rotar();
    	if(rotate_count == 0 || rotate_count == 2 && !r_malo)
    		if(pos_actual-pos_local >= 40f)
    			rotar();*/
    	/*else if(rotate_count == 1)
    		if(pos_actual_x-pos_local_x >= 40f && rotate_count == 1)
    			rotar();*/
    }
    void mover_malo()
    {
    	robotMalo.GetComponent<movimientoCubo>().move = true;
    	robotMalo.GetComponent<TrailRenderer>().enabled=true; 
    	already_modif =  true;
    }
    void rotar()
    {
    	if(rotate_count == 0)
    	{
	    	this.transform.Rotate(0,90, 0);
	    	rotate_count++;
	    	//already_rotate = true;
		}
		if(rotate_count == 1)
    	{
	    	this.transform.Rotate(0,90, 0);
	    	rotate_count++;
	    	//already_rotate = true;
		}if(rotate_count == 2)
    	{
	    	this.transform.Rotate(0,90, 0);
	    	rotate_count++;
	    	//already_rotate = true;
		}
		pos_local_x = this.transform.position.x;
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