using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballOverlayFollow : MonoBehaviour {

    public GameObject Target;
    public float Ease = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 SmoothPos = Vector2.Lerp(transform.position, Target.transform.position, Time.deltaTime * Ease);
        transform.position = new Vector3(SmoothPos.x, SmoothPos.y, transform.position.z);
	}
}
