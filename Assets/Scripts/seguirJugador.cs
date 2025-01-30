using UnityEngine;

public class seguirJugador : MonoBehaviour
{
   public Transform player;  // Referencia al jugador
    public Vector3 offset = new Vector3(10, 10, -10);  // Posición isométrica
    public float smoothSpeed = 5f;  // Velocidad de suavizado

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcular la posición deseada de la cámara
            Vector3 desiredPosition = player.position + offset;

            // Suavizar el movimiento de la cámara
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Opcional: Mantener la rotación fija en vista isométrica
            transform.rotation = Quaternion.Euler(45f, 10f, 0f);
        }
    }
}
