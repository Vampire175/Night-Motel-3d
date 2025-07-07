using TMPro;
using UnityEngine;


public class InputField : MonoBehaviour
{
    public TMP_InputField inputField;
    public bool textentered = false;

    void Start()
    {

        textentered = true;
        // Add listener for any time the user types something
        inputField.onValueChanged.AddListener(OnInputChanged);
    }

    void OnInputChanged(string userInput)
    {
        // Force the text back to motelbooking.com
        inputField.text = "motelbooking.com";
        

    }
}
