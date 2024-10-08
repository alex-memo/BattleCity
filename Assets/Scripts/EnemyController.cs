using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	//has to follow player
	[SerializeField] private float speed = 5f;
	[SerializeField] private int score = 1;
	private NavMeshAgent agent;
	public void Die()
	{
		GameManager.Instance.OnScoreChange?.Invoke(score);
		Destroy(gameObject);
	}
	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.speed = speed;
	}
	private void FixedUpdate()
	{
		if (GameManager.Instance.Player == null)
		{
			return;
		}
		agent.destination = GameManager.Instance.Player.transform.position;
	}
}
