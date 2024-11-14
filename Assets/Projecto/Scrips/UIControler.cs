using UnityEngine;
using TMPro;

public class UIControler : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Arrastra aquí el objeto de TextMeshPro en el Inspector
    public Movement movementScript;    // Referencia al script Movement

    void Start()
    {
        movementScript = GameObject.Find("BoxRobot(Clone)").GetComponent<Movement>();
        // Inicializa el texto con el valor actual de steps
        UpdateCounterText();
    }

    private void Update()
    {
        // Actualiza el contador de pasos en cada frame
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        //if (movementScript != null)  // Verifica que movementScript esté asignado
        //{
            // Actualiza el texto con el valor de steps
            counterText.text = "Steps: " + movementScript.steps;
        //}
    }
}


