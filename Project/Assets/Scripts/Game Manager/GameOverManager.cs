using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public static GameOverManager instance;

	private GameObject gameOverPanel;
	private Animator gameOverAnim;

	private Button playAgainBtn, backBtn;

	private GameObject scoreText;
	private Text finalScore;

	void Awake() {
		MakeInstance ();
		InitializeVariables ();
	}

	void MakeInstance() {
		if (instance == null)
			instance = this;
	}

	public void GameOverShowPanel() {
		scoreText.SetActive (false);
		gameOverPanel.SetActive (true);

		finalScore.text = "Score \n" + ScoreManager.instance.GetScore ();

		gameOverAnim.Play ("FadeIn");
	}

	void InitializeVariables() {
		gameOverPanel = GameObject.Find ("Game Over Panel Holder");
		gameOverAnim = gameOverPanel.GetComponent<Animator> ();

		playAgainBtn = GameObject.Find ("Play Again Button").GetComponent<Button> ();
		backBtn = GameObject.Find ("Back Button").GetComponent<Button> ();

		playAgainBtn.onClick.AddListener (() => PlayAgain());
		backBtn.onClick.AddListener (() => BackToMenu());

		scoreText = GameObject.Find ("Score Text");
		finalScore = GameObject.Find ("Final Score").GetComponent<Text> ();

		gameOverPanel.SetActive (false);
	}

	public void PlayAgain() {
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void BackToMenu() {
		Application.LoadLevel ("MainMenu");
	}

} // GameOverManager

















































