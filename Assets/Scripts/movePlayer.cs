using UnityEngine;
using TMPro;
using System.Collections; // Necesario para usar corutinas

public class movePlayer : MonoBehaviour
{
    public float velocidad = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private Vector3 direccionMovimiento;
    private bool isGrounded;
    private int monedasRecolectadas = 0;

    public TextMeshProUGUI monedaTexto;  // UI para mostrar monedas
    public TextMeshProUGUI mensajeMeta;  // UI para mostrar mensaje al llegar a la meta

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        ActualizarUI();
        mensajeMeta.gameObject.SetActive(false); // Oculta el mensaje al inicio
    }

    void Update()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");

        direccionMovimiento = new Vector3(movX, 0, movZ).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 nuevaPosicion = rb.position + direccionMovimiento * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(nuevaPosicion);
    }

    private void OnTriggerEnter(Collider other) // Usamos OnTriggerEnter en lugar de OnCollisionEnter
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (other.CompareTag("Meta")) // Si toca la meta
        {
            RevisarMeta();
        }
    }

    public void RecolectarMoneda()
    {
        monedasRecolectadas++;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (monedaTexto != null)
        {
            monedaTexto.text = "Monedas: " + monedasRecolectadas + "/10";
        }
    }

    void RevisarMeta()
    {
        // Asegúrate de desactivar el mensaje primero antes de mostrar el nuevo
        mensajeMeta.gameObject.SetActive(true);

        if (monedasRecolectadas >= 10)
        {
            mensajeMeta.text = "¡Felicidades! Llegaste a la meta con todas las monedas";
        }
        else
        {
            mensajeMeta.text = "Te faltan monedas... ¡Vuelve a buscarlas!";
            StartCoroutine(DesaparecerMensaje()); // Inicia la corutina para desaparecer el mensaje
        }
    }

    IEnumerator DesaparecerMensaje()
    {
        yield return new WaitForSeconds(3f); // Espera 3 segundos
        mensajeMeta.gameObject.SetActive(false); // Oculta el mensaje
    }
}
