using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotate : MonoBehaviour {

	public GameObject player;
	private Vector3 position;
	public Text textvalue;

	// Use this for initialization
	void Start () {

		getPosition();
		player = GameObject.FindWithTag("rotateball");

		
	}
	
	// Update is called once per frame
	void Update () {

		getPosition();
		player.transform.Rotate (0, 360*Time.deltaTime, 0);
	}

	void getPosition(){

		position = Input.mousePosition;
        textvalue.text = position.ToString();

	}

}
