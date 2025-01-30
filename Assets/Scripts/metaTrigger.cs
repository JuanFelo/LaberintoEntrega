using UnityEngine;
using UnityEngine.UI;

public class metaTrigger : MonoBehaviour
{
   public GameObject messagePanel; // Panel de mensaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el cubo tiene el tag "Player"
        {
            messagePanel.SetActive(true); // Muestra el mensaje
        }
    }
}
