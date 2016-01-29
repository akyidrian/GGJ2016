using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour, IPointerClickHandler {

	public float speed;
	
	private Vector3 newPosition;
	private Vector3 currentPosition;
	private Vector3 startPosition;
	private float startTime;
	private float journeyLength;

	void Awake() {
		startPosition = transform.position;
		currentPosition = startPosition;
		journeyLength = 0f;
	}

	void Update()
	{
		if(journeyLength > 0)
			MoveToLocation();
	}

	#region IPointerClickHandler implementation
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Left) {
			Debug.Log ("Selected: " + gameObject.name);
			Selected = true;
		}

	}
		           
	#endregion

	public bool Selected { get; set;}


	public void SetNewPosition(Vector3 position) 
	{
		newPosition = position;
		startPosition = currentPosition;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startPosition, newPosition);
	}

	private void MoveToLocation() 
	{

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		currentPosition = Vector3.Lerp(startPosition, newPosition, fracJourney);

		transform.position = new Vector3(currentPosition.x, currentPosition.y, 0.5f);
	}



}
