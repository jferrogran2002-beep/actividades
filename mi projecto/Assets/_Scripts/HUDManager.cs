using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{

    // Se crea la variable del Singleton
    public static HUDManager Instance;

    // Variable que almacena el texto de la pantalla.
    public TextMeshProUGUI potionNameText;

    // Variable que almacena el contenido del texto al no haber poción.
    public string emptyInventoryText;

    // Se completa la creación del Singleton.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        // El texto del texto de la pantalla es el de el inventario vació al comenzar el juego.
        potionNameText.text = emptyInventoryText;
    }

    // Toma la poción que se ponga entre paréntesis y escribe su nombre en la pnatalla.
    public void PotionName(PotionsSO potion)
    {
        potionNameText.text = potion.potionName;
    }

    // El texto en pantalla muestra el escrito guardado en la variable.
    public void ResetPotionName()
    {
        potionNameText.text = emptyInventoryText;
    }
}
