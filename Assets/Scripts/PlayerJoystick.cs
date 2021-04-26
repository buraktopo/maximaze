using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerJoystick : MonoBehaviour
{

	public FloatingJoystick MoveJoystick;
	public FixedTouchField TouchField;

	// Update is called once per frame
	void Update()
	{
		var fps = GetComponent<RigidbodyFirstPersonController>();

		fps.RunAxis = MoveJoystick.Direction;
		fps.mouseLook.LookAxis = TouchField.TouchDist;
	}
}