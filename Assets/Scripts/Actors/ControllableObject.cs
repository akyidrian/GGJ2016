using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ControllableObject : MovableObject, IPointerClickHandler
{
    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameController.instance.SetAllPlayersFalse();
            Selected = true;
        }
    }

    #endregion

    public bool Selected { get; set; }
}
