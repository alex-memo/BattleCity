using UnityEngine;

public class InputManager : InstanceFactory<InputManager>
{
	public OnPlayerInput OnPlayerInput;

	private void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		Vector2 _input = new(x, y);
		if (_input == Vector2.zero) { return; }

		OnPlayerInput?.Invoke(new Vector2(x, y));
	}
}
public delegate void OnPlayerInput(Vector2 _dir);