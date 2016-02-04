using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAreaController : MonoBehaviour {
	
	public float speed;
	public GameObject pickup;
	public Text gameEndText;

	private float endTime; 

	private Vector3 rot = new Vector3 (0.0f, 0.0f, 90.0f); 
    
	void Start()
	{
		endTime = Time.time + 60.0f;
		UpdateTime ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rot.x += Input.GetAxis ("Horizontal"); 
		rb.rotation = Quaternion.Euler(rot);
	}

	void Update()
	{
		if (GameObject.FindWithTag ("Pickup") == null && Time.time < endTime) {
			Vector3 spawnPos = Random.insideUnitSphere * 0.8f;
			spawnPos.x = 0.0f;
			Instantiate(pickup, spawnPos, Quaternion.identity);
		}
		if (Time.time >= endTime) {
			Destroy(GameObject.FindWithTag("Pickup"));
		}
		if (Input.GetButton ("Jump") && Time.time >= endTime)
			NewGame ();
		UpdateTime ();
	}

	void UpdateTime()
	{
		if (Time.time < endTime) {
			gameEndText.text = "Time: " + (endTime - Time.time).ToString ("F1") + "s";
		} 
		else {
			gameEndText.text = "Game Over!";
		}
	}

	void NewGame()
	{
		GameObject.FindWithTag ("Player").transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		GameObject.FindWithTag ("Player").GetComponent<PlayerController> ().ResetScore ();
		rot = new Vector3 (0.0f, 0.0f, 90.0f);
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (rot);
		endTime = Time.time + 60.0f;

	}
}
