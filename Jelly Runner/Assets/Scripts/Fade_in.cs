using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_in : MonoBehaviour {


    public Animator animator;

    // Use this for initialization
    void Start () {
        animator.SetTrigger("Fade_in");
    }
	
	
}
