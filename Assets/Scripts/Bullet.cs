using UnityEngine;

public class Bullet : MonoBehaviour
{
	Rigidbody rb;
	private void OnTriggerEnter(Collider _coll)
	{
		_coll.TryGetComponent(out EnemyController enemyController);
		if (enemyController == null) { return; }
		enemyController.Die();
		Destroy(gameObject);
	}
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.linearVelocity = transform.forward * 10f;
		Destroy(gameObject, 5f);
	}
	private void Update()
	{
		//transform.position += transform.forward * Time.deltaTime * 5f;
	}
}
