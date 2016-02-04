using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float jumpSpeed;
	public Text scoreText;
	private int score = 0;

	void Start()
	{
		UpdateScore ();
	}

	void FixedUpdate () {
	if (Input.GetAxis ("Vertical") > 0)
			GetComponent<Rigidbody> ().velocity = (Vector3.up * jumpSpeed);

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup") {
			Destroy (other.gameObject);
			score += 1;
			UpdateScore ();
		}
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + (score/2).ToString ();
	}

	public void ResetScore()
	{
		score = 0;
		UpdateScore ();
	}
}
