using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
    private ActionAsset _inputAsset;
    public ActionAsset Input { get { return _inputAsset; } }

    #region events
    public UnityEvent<Vector2> PlayerMoveEvent;
    #endregion
    private void OnEnable()
    {
        if(_inputAsset == null)
        {
            _inputAsset = new ActionAsset();

            _inputAsset.Enable();
            _inputAsset.GamePlay.Enable();

            _inputAsset.GamePlay.Move.performed += (val) => PlayerMoveEvent.Invoke(val.ReadValue<Vector2>());
        }
    }
 

}