using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 5f;
	public float rotationSpeed = 200f;

	private Vector2 input;
	private Vector3 direction;
	private Rigidbody rb;
	[SerializeField] private GameObject bullet;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		GameManager.Instance.Player = gameObject;
		StartCoroutine(shoot());
		InputManager.Instance.OnPlayerInput += HandlePlayerInput;
	}
	private void OnDestroy()
	{
		if (InputManager.Instance == null) { return; }
		InputManager.Instance.OnPlayerInput -= HandlePlayerInput;
	}

	private void HandlePlayerInput(Vector2 _input)
	{
		input = _input;
	}

	private void Update()
	{
		direction = new Vector3(input.x, 0, input.y);
	}

	private void FixedUpdate()
	{
		rb.linearVelocity = direction * speed;
	}
	private IEnumerator shoot()
	{
		while (true)
		{
			yield return new WaitForSeconds(.5f);
			//bullet direction from direction
			Quaternion bulletDirection = Quaternion.LookRotation(direction);
			Vector3 _bulletPosition = transform.position + direction.normalized;
			_bulletPosition.y += 1f;
			Instantiate(bullet, transform.position, bulletDirection);
		}
	}
	private void OnCollisionEnter(Collision _coll)
	{
		if (_coll.gameObject.TryGetComponent(out EnemyController enemyController))
		{
			GameManager.Instance.OnPlayerDeath?.Invoke();
			Destroy(gameObject);
		}
	}
}
