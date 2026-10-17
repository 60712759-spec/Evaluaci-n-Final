using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public float velocidadRotacion = 90f;

    void Update()
    {
        // Hace rotar la tarjeta sobre su propio eje
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.AgregarTarjeta();
            }
            Destroy(gameObject);
        }
    }
}

