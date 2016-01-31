using UnityEngine;
using System.Collections;

public class PlayerSelector : MonoBehaviour {

	public ControllableObject[] players;

	public void SelectOnClick(int index) 
	{
		GameController.instance.SetAllPlayersFalse();
		players[index].Selected = true;
	}
}
