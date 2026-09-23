using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Variables por defecto de los estados del personaje
    public int maxLife;
    public int minStamina;
    public int minPower;

    // Variables que se van a modificar.
    [HideInInspector] public int health;
    [HideInInspector] public int stamina;
    [HideInInspector] public int power;


    // Start is called before the first frame update
    void Start()
    {
        // Las variables que se modifican se inicializan con los valores por defecto.
        health = maxLife;
        stamina = minStamina;
        power = minPower;
    }

    private void Update()
    {
        // Al presionar cada una de las teclas:

        // La salud baja máximo hasta cero, y se muestra en pantalla.
        if (Input.GetKeyDown(KeyCode.H))
        {
            health--;
            health = Mathf.Max(health, 0);
            Debug.Log("Health is: " + health);
        }

        // Se muestra el poder en pantalla.
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Power is: " + power);
        }

        // Se muestra la stamina en pantalla.
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Resistance is: " + stamina);
        }
    }
}
