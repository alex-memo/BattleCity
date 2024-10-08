using UnityEngine;

public class InstanceFactory<T> : MonoBehaviour where T : class
{
	public static T Instance { get; private set; }

	protected virtual void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this as T;
	}
	protected virtual void OnDestroy()
	{
		if ((object)Instance == this)
		{
			Instance = null;
		}
	}
}
