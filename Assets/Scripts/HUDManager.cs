using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class HUDManager : InstanceFactory<HUDManager>
{
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private GameObject deadScreen;
	private int score = 0;
	protected override void Awake()
	{
		base.Awake();
	}
	private void Start()
	{
		GameManager.Instance.OnScoreChange += updateScore;
		GameManager.Instance.OnPlayerDeath += ShowDeadScreen;
	}
	private void updateScore(int _score)
	{
		score += _score;
		scoreText.text = $"Score: {score}";
	}
	public void PlayAgain()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	private void ShowDeadScreen()
	{
		deadScreen.SetActive(true);
	}
}