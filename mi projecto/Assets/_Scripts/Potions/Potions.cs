using UnityEngine;

public class Potions : MonoBehaviour
{
    // Variable para poner en el inspector el SO correspondiente a la poción.
    public PotionsSO potion;

    // Método que detecta cuando un objeto atraviesa la poción.
    private void OnTriggerEnter(Collider other)
    {
        // Si es el jugador es el que atraviesa la poción.
        if (other.CompareTag("Player"))
        {
            // Desactiva el objeto poción.
            gameObject.SetActive(false);

            // La variable del inventario de Has Potion se vuelve verdadera.
            Inventory.Instance.hasPotion = true;

            // La variable de pickedUpPotion, del Inventario, se llena con el SO de este objeto.
            Inventory.Instance.pickedUpPotion = potion;

            // El método para actualizar el texto del HUD se llama con el SO de este objeto.
            HUDManager.Instance.PotionName(potion);
        }

    }

}
