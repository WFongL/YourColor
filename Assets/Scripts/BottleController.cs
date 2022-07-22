using UnityEngine;
using UnityEngine.EventSystems;

public class BottleController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform positionBottle;

    [SerializeField] private GameObject[] paintInABottle;

    [SerializeField] private GameController gameController;

   public void OnPointerDown(PointerEventData pointerEventData)
    {
        transform.Translate(Vector3.up);

        gameController.CheckThePressedBottle(paintInABottle, positionBottle);
    }
}