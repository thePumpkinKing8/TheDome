using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private Grabbable _heldObject;
    public Grabbable HeldObject { get { return _heldObject; } }

    private void Start()
    {
        InputManager.Instance.PlayerClickEvent.AddListener(CheckForObject);
        InputManager.Instance.PlayerDropEvent.AddListener(DropGrabbable);
    }

    public void CheckForObject()
    {
        Debug.Log("call");
        if (_heldObject != null)
            return;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, LayerMask.NameToLayer("Grabbable"));
        
        if(hit)
        {
            Debug.Log("hit");
            SetGrabbedObject(hit.rigidbody.gameObject.GetComponent<Grabbable>());           
        }
        
    }

    public void SetGrabbedObject(Grabbable _grabbed)
    {
        _heldObject = _grabbed; 
        _heldObject.GrabStart();
    }

    public void DropGrabbable()
    {
        if(_heldObject == null)
            return;

        _heldObject.GrabEnd();
        _heldObject = null;
    }
}
