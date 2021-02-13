using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToogleButton : MonoBehaviour
{
    public bool                                         toggle;
    public                  UnityEvent                  _WhenOn, _WhenOff;

    private void Start() {
        Button button;
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate{
            _GetToggleMode();
        });
    }
    public void _GetToggleMode()
    {
        toggle = !toggle;
        if(toggle)
            _WhenOn.Invoke();
        else
            _WhenOff.Invoke();
    }
}
