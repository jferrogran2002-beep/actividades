using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Se crea una variable para almacenar el script de Player Stats.
    private PlayerStats playerStats;

    private void Start()
    {
        // Se guarda en la variable el script que es ahora componente del mismo objeto.
        playerStats = GetComponent<PlayerStats>();
    }

    // Método que ejecuta el efecto de la poción.
    public void UsePotion()
    {
        // Si no hay poción en el inventario, se sale del método con return.
        if (Inventory.Instance.pickedUpPotion == null)
            return;

        // Se usa un Switch que valida qué sucede en caso que la poción tomada sea de cierto tipo.
        switch (Inventory.Instance.pickedUpPotion.potionType)
        {
            // Si es poción de cura, sube la vida (por el factor de la poción) hasta el máximo y se cierra con break.
            case PotionType.Cura:
                playerStats.health += Inventory.Instance.pickedUpPotion.factor;
                playerStats.health = Mathf.Min(playerStats.health, playerStats.maxLife);
                break;

            // Si es poción de Poder, sube el poder (por el factor de la poción) y se cierra con break.
            case PotionType.Poder:
                playerStats.power += Inventory.Instance.pickedUpPotion.factor;
                break;

            // Si es poción de Resistencia, sube la stamina (por el factor de la poción) y se cierra con break.
            case PotionType.Resistencia:
                playerStats.stamina += Inventory.Instance.pickedUpPotion.factor;
                break;
        }
    }

    void Update()
    {
        if(InputController.Instance.drinkInput.WasPressedThisFrame())
        {
            Drink();
        }
    }

    public void Drink()
    {
        if(Inventory.Instance.hasPotion)
        {
            UsePotion();
            Debug.Log("Tomaste la poción " + Inventory.Instance.pickedUpPotion.potionName);
            Inventory.Instance.pickedUpPotion = null;
            Inventory.Instance.hasPotion = false;
            HUDManager.Instance.ResetPotionName();
        }
        else
        {
            Debug.Log("No hay pociones");
        }
    }
}
