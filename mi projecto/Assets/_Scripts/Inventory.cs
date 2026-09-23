
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Se crea el Singleton de este script, creando la variable.
    public static Inventory Instance;

    // Se completa el singleton con este aspecto del Awake.
    private void Awake()
    {
        if(Instance == null){Instance = this;}
        else { Destroy(this); }
    }

    // Dos variables que son públicas pero que no se pueden ver en el inspector.
    // Esta variable es del tipo de los Scriptable Objects.
    [HideInInspector] public PotionsSO pickedUpPotion;

    // Booleano que valida si el inventario tiene la poción o no.
    [HideInInspector] public bool hasPotion;

     void Start()
    {
        pickedUpPotion = null;
        hasPotion = false;
    }
}
