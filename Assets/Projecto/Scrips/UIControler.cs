using UnityEngine;
using TMPro;

public class UIControler : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Arrastra aqu√ el objeto de TextMeshPro en el Inspector
    public Movement steps;


    void Start()
    {
        UpdateCounterText(); // Muestra el contador inicial
    }

    private void Update()
    {
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D))
        {
            if (steps.steps != 0)
            {
                
                counterText.text = "Steps: " + steps.steps; // Muestra el valor del contador en el texto
            }
        }
    }
}


