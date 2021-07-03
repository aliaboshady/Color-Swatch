using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float jumpForce = 10f;
	public Rigidbody2D rb;
	public string currentColor;
	public SpriteRenderer spriteRenderer;
	public Color colorBlue;
	public Color colorYellow;
	public Color colorPink;
	public Color colorPurple;

	void Start(){
		SetRandomColor ();
	}

	void Update () {
		if (Input.GetButtonDown("Jump")) {
			if (rb.bodyType == RigidbodyType2D.Static) {
				rb.bodyType = RigidbodyType2D.Dynamic;
			}
			rb.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Color Changer")) {
			SetRandomColor ();
			Destroy (col.gameObject);
		}
		else if (!col.CompareTag(currentColor)) {
			SceneManager.LoadScene (0);
		}
	}

	void SetRandomColor(){
		int index = Random.Range (0, 4);
		switch (index) {
		case 0:
			currentColor = "Yellow";
			spriteRenderer.color = colorYellow;
			break;
		case 1:
			currentColor = "Blue";
			spriteRenderer.color = colorBlue;
			break;
		case 2:
			currentColor = "Pink";
			spriteRenderer.color = colorPink;
			break;
		case 3:
			currentColor = "Purple";
			spriteRenderer.color = colorPurple;
			break;
		}
	}
}
