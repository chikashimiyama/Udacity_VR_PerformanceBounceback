using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private GameManager gameManager_;
	private Text text_;

	private void Start () {
        gameManager_ = GameObject.Find("GameManager").GetComponent<GameManager>();
		text_ = GetComponentInChildren<Text>();
	}

	private void Update () {
        text_.text = "Score: " + gameManager_.score.ToString();
	}
}
