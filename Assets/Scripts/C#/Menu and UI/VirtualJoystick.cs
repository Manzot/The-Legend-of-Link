using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	public Image bgImage;
	public Image JoystickImage;
	public Vector2 InputDirection{set; get; }


	// Use this for initialization
	void Start () 
	{
		bgImage = GetComponent<Image>();
		InputDirection = Vector2.zero;
	}
	
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle
		   (bgImage.rectTransform,
		 	ped.position,
		 	ped.pressEventCamera,
		 	out pos))
		{
			pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

			float x = (bgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (bgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			InputDirection = new Vector2 (x, y);

			/*if (InputDirection.x > 0 && InputDirection.y > 0) 
			{
				InputDirection= new Vector2(1, 0);

			}
			if (InputDirection.x < 0 && InputDirection.y < 0) 
			{
				InputDirection= new Vector2(-1, 0);

			}
			if (InputDirection.x > 0 && InputDirection.y < 0) 
			{
				InputDirection= new Vector2(0, -1);

			}
			if (InputDirection.x < 0 && InputDirection.y > 0) 
			{
				InputDirection= new Vector2(0, 1);
			
			}*/
			InputDirection = (InputDirection.magnitude > 0.05f) ? InputDirection.normalized : InputDirection;

			JoystickImage.rectTransform.anchoredPosition = 
				new Vector3(InputDirection.x * (bgImage.rectTransform.sizeDelta.x / 3),InputDirection.y *(bgImage.rectTransform.sizeDelta.y / 3));
		}
	}
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}
	public virtual void OnPointerUp(PointerEventData ped)
	{
		InputDirection = Vector3.zero;
		JoystickImage.rectTransform.anchoredPosition = Vector3.zero;
	}
}
