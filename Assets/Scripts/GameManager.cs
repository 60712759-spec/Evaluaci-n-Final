using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Progreso")]
    public int tarjetasRecolectadas = 0;
    public int tarjetasTotales = 3;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AgregarTarjeta()
    {
        tarjetasRecolectadas++;
        Debug.Log("Tarjetas: " + tarjetasRecolectadas + " / " + tarjetasTotales);

        if (tarjetasRecolectadas >= tarjetasTotales)
        {
            Debug.Log("¡Todas las tarjetas recolectadas! La puerta de salida se ha abierto.");
        }
    }
}

