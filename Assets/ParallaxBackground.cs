using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 1.0f;  // prêdkoœæ przesuwania t³a
    public float startPosition = 20.0f;  // pozycja startowa t³a
    public float endPosition = -20.0f;  // pozycja koñcowa t³a

    private void Update()
    {
        // przesuwamy t³o z prawej do lewej
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        // jeœli t³o osi¹gnê³o pozycjê koñcow¹, przenosimy je na pocz¹tek
        if (transform.position.x <= endPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}
