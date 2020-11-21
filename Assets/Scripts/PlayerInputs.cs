using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public bool InteractIsPressed { get; private set; }
    public bool FireIsPressed { get; private set; }

    public bool InteractIsReleased { get; private set; }
    public bool FireIsReleased { get; private set; }

    public enum Button
    {
        Interact,
        Fire
    }

    string horizontalAxis = "Horizontal";
    string verticalAxis = "Vertical";
    string interactButton = "Interact";
    string fireButton = "Fire";

    public bool IsButtonDown(Button btn)
    {
        switch (btn)
        {
            case Button.Interact:
                return Input.GetButton(interactButton);
            case Button.Fire:
                return Input.GetButton(fireButton);
        }
        return false;
    }

    private void Update()
    {
        Horizontal = Input.GetAxis(horizontalAxis);
        Vertical = Input.GetAxis(verticalAxis);

        InteractIsPressed = false;
        InteractIsReleased = false;
        FireIsPressed = false;
        FireIsReleased = false;

        if (Input.GetButtonDown(interactButton))    InteractIsPressed = true;
        if (Input.GetButtonDown(fireButton))        FireIsPressed = true;
        if (Input.GetButtonUp(interactButton))      InteractIsReleased = true;
        if (Input.GetButtonUp(fireButton))          FireIsReleased = true;
    }
}

