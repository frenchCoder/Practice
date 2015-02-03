using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;//counts collected objects
	public GUIText countText; 
	public GUIText winText;

	void Start()
	{
		count = 0;
		setCountText();
		winText.text = "";
	}

	//called before rendering any physics calculations
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		//multiply by deltaTime to make input smooth and framerate independent
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	//called when object collides with other object
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") 
		{
			other.gameObject.SetActive(false);
			count++;

			setCountText();
		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}

//Destroy (other.GameObject);