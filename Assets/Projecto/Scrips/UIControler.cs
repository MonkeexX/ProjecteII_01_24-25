using UnityEngine;
using TMPro;

public class UIControler : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Arrastra aquí el objeto de TextMeshPro en el Inspector
    public Movement movementScript1;    // Referencia al script Movement
    public Movement movementScript2;    // Referencia al script Movement

    void Start()
    {
        // Inicializa el texto con el valor actual de steps
        UpdateCounterText();
    }

    void Update()
    {
        if (movementScript1 == null)
        {
            var obj = GameObject.Find("BoxRobot(Clone)");
            if (obj != null)
                movementScript1 = obj.GetComponent<Movement>();
        }

        if (movementScript2 == null)
        {
            var obj = GameObject.Find("SmallRobot(Clone)");
            if (obj != null)
                movementScript2 = obj.GetComponent<Movement>();
        }

        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        if (movementScript1 != null)  // Verifica que movementScript esté asignado
        {
            //Actualiza el texto con el valor de steps
            counterText.text = "PushBot Steps: " + movementScript1.steps;
        }
        if (movementScript2 != null)
        {
            counterText.text = "TinyBot Steps: " + movementScript2.steps;
        }
    }
}


