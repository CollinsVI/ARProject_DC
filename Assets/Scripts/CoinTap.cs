using UnityEngine;
using UnityEngine.EventSystems; // Required for IPointerClickHandler

public class CoinTap : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Assuming the coin is tapped, handle the logic here
        GameManager.instance.AddScore(10);

        Destroy(gameObject);
        Debug.Log("Coin has been tapped");
    }
}
