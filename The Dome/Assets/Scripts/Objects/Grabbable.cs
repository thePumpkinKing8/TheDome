using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    protected bool _grabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_grabbed)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }

    public virtual void GrabStart()
    {
        if(_grabbed)
            return;
        _grabbed = true;
        PlayerManager.Instance.SetGrabbedObject(this);

        Debug.Log("grabbed");
    }

    public virtual void GrabEnd()
    {
        _grabbed = false;
        Debug.Log("ungrabbed");
    }
}

