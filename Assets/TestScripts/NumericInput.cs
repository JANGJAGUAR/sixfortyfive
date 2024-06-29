using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumericInput : MonoBehaviour
{
    public int currentNumber;
    public TMP_InputField inputField;
    public TextMeshProUGUI displayText;

    void Start()
    {
        // Ensure the InputField is set to accept only numeric input
        inputField.contentType = TMP_InputField.ContentType.DecimalNumber;

        // Add a listener to handle input value changes
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(string input)
    {
        // Convert the input string to a float
        if (int.TryParse(input, out int numericValue))
        {
            // Display the numeric value or process it as needed
            displayText.text = "Numeric Input: " + numericValue;
            currentNumber = numericValue;
        }
        else
        {
            displayText.text = "Invalid input. Please enter a number.";
        }
    }
}
