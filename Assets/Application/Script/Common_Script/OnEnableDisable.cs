using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableDisable : MonoBehaviour
{
  public UnityEvent OnEnableCall, OnDisableCall;

  private void OnEnable() {
      OnEnableCall.Invoke();
  }

  private void OnDisable() {
      OnDisableCall.Invoke();
  }
}
