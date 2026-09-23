using UnityEngine;

// Se crean los enumeradores. Están por fuera de la clase para que sean públicos.
public enum PotionType { Cura, Poder, Resistencia}

// Permite crear un menu en el apartado de "Crear", para poder crear los Scriptable Objects.
[CreateAssetMenu(fileName = "New Potion", menuName = "Potions/New Potion")]
public class PotionsSO : ScriptableObject
{
    // Variables que van a tener los SO
    // Variable que almacena qué tipo de poción es.
    public PotionType potionType;

    // Variable que almacena el nombre de la poción.
    public string potionName;

    // Variable que almacena cuánto mejora la estadística.
    public int factor;
}
