﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

	public static GameController instance = null;
	public List <ControllableObject> playerControllers;

	void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	void Update() {

		Vector3 newPosition;


		if (Input.GetButtonDown ("Fire2")) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
			if(Physics.Raycast(ray, out hit)) {
				Debug.DrawLine (ray.origin, ray.direction, Color.green);
				newPosition = hit.point;
                
				FindSelectedCharacter().SetNewPosition(newPosition);
			}


		}   

	}

	public void SetAllPlayersFalse() {
		for(int i = 0; i < playerControllers.Count; i++) {
			playerControllers[i].Selected = false;
		}
	}

	private ControllableObject FindSelectedCharacter()
	{
        ControllableObject selectedCharacter = playerControllers[0];

		for(int i = 0; i < playerControllers.Count; i++) {

			if(playerControllers[i].Selected == true) {
				Debug.Log (playerControllers[i].name);
				selectedCharacter = playerControllers[i];
			}
		}

		return selectedCharacter;
	}

}