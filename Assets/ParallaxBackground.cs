using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 1.0f;  // pr�dko�� przesuwania t�a
    public float startPosition = 20.0f;  // pozycja startowa t�a
    public float endPosition = -20.0f;  // pozycja ko�cowa t�a

    private void Update()
    {
        // przesuwamy t�o z prawej do lewej
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        // je�li t�o osi�gn�o pozycj� ko�cow�, przenosimy je na pocz�tek
        if (transform.position.x <= endPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}
