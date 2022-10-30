using UnityEngine;
using System.Collections;

public class mathftutor : MonoBehaviour {


	private float mover;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//this is used to get use left and right arrow input
		mover = Input.GetAxis ("Horizontal") * Time.deltaTime * 20;
		//now we use translate to move the character
		transform.Translate (mover, 0, 0);
	

		transform.position = new Vector3 ((Mathf.Clamp (transform.position.x, -6, 6)), transform.position.y, transform.position.z);
	}
}
