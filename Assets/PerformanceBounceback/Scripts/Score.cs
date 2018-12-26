using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private GameManager gameManager_;
	private Text text_;

	private void Start () {
        gameManager_ = GameObject.Find("GameManager").GetComponent<GameManager>();
		text_ = GetComponentInChildren<Text>();
		gameManager_.ScoreUpdated += OnScoreUpdated;
	}

	private void OnScoreUpdated (int newScore) {
        text_.text = "Score: " + newScore;
	}
}
