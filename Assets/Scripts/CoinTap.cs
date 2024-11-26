using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTap : MonoBehaviour
{
    void Update()
    {
        
        if (Input.touchCount > 0) //Unsure if necessary but keep for now
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) // Detect touch start
            {
                // Making the touch position a Ray
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject) 
                    {
                        
                        GameManager.instance.AddScore(10);

                        
                        Destroy(gameObject);
                        Debug.Log("Coins been tapped");

                    }
                }
            }
        }
    }
}
