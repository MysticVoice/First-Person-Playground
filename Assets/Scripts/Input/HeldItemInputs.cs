using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItemInputs : MonoBehaviour
{
    public ScriptableBoolEvent useInput;
    public ScriptableBoolEvent secondaryUseInput;
    public ScriptableBoolEvent reloadInput;

    public bool use;
    public bool secondaryUse;
    public bool reload;

    private void OnEnable()
    {
        useInput.OnTrigger += SetUseState;
    }
    private void OnDisable()
    {
        useInput.OnTrigger -= SetUseState;
    }

    public void SetUseState(bool value) => use = value;
    public void SetSecondaryUseState(bool value) => secondaryUse = value;
    public void SetReloadInput(bool value) => reload = value;
}
