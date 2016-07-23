using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.acceleration.x * 5;
		float moveVertical = Input.acceleration.y * 5;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pickup"))
		{
			other.gameObject.SetActive (false);
			count= count+1;
			setCountText ();
		}
	}

	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 17) {
			winText.text = "You win.";
		}
	}
}