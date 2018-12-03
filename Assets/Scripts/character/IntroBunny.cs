using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroBunny : MonoBehaviour {
	private const string FACE_RIGHT_ANIM_PARAM = "isFacingRight";
	private const string VELOCITY_X_ANIM_PARAM = "velocityX";

	public Text levelText;
	public String nextLevel;
	public float fadeOutTime = 1f;

	private Rigidbody2D bunny;
	private Animator bunnyAnim;
	private float maxX;
	private float endTimeStamp = -1;


	// Use this for initialization
	void Start () {
		bunny = GetComponent<Rigidbody2D> ();
		bunnyAnim = GetComponentInChildren<Animator> ();
		bunnyAnim.SetBool(FACE_RIGHT_ANIM_PARAM, true);
		maxX = -bunny.position.x;
	}

	void Update() {
		if (Input.GetButtonDown ("Fire1")
		   || Input.GetButtonDown ("Fire2")
		   || Input.GetButtonDown ("Fire3")
		   || Input.GetButtonDown ("Jump")
			|| Input.GetKeyDown(KeyCode.Mouse0))
			NextLevel ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bunny.velocity = 7 * Vector2.right;
		bunnyAnim.SetFloat(VELOCITY_X_ANIM_PARAM, bunny.velocity.x);

		if(endTimeStamp != -1f)
		{
			Color fadeOut = Color.white;
			fadeOut.a = Mathf.Max (0f, 1f - (Time.timeSinceLevelLoad - endTimeStamp / fadeOutTime));
			bunnyAnim.GetComponent<SpriteRenderer> ().color = fadeOut;
			levelText.color = fadeOut;

			if(Time.timeSinceLevelLoad - endTimeStamp > fadeOutTime)
				SceneManager.LoadScene(nextLevel);
			return;
		}



		if (bunny.position.x >= maxX)
			NextLevel ();
	}

	private void NextLevel()
	{
		if(endTimeStamp == -1f)
		endTimeStamp = Time.timeSinceLevelLoad;
	}
}
