using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    [SerializeField] float moveSpeed;

    Rigidbody2D myRigidBody2D;


	// Use this for initialization
	void Start () {
        myRigidBody2D = GetComponent<Rigidbody2D>(); 
		
	}
	
	// Update is called once per frame
	void Update () {
        myRigidBody2D.velocity = new Vector2(moveSpeed, Mathf.Sin(transform.localPosition.x));
        
        
		
	}
}
