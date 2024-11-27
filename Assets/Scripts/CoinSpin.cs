using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed = 10f;

    void Update()
    {

        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);

    }
}