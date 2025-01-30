using UnityEngine;

public class rotarMoneda : MonoBehaviour
{
    public float velocidadRotacion = 100f; // Velocidad de giro

    void Update()
    {
        transform.Rotate(0, velocidadRotacion * Time.deltaTime, 0, Space.World); // Rotación constante
    }
}
