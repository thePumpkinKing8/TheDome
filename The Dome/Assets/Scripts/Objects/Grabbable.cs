using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    protected bool _grabbed = false;
    private Rigidbody2D _rb;
    private Vector3 _velector;
    private float _vel;
    private Vector3 _pastPos;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_grabbed)
        {
            _pastPos = transform.position;
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            _velector = (transform.position - _pastPos);
            _vel = (_pastPos - transform.position).magnitude / Time.deltaTime;
            _velector *= _vel;
        }
    }

    public virtual void GrabStart()
    {
        if(_grabbed)
            return;
        _grabbed = true;
        PlayerManager.Instance.SetGrabbedObject(this);
        _pastPos = transform.position;
        Debug.Log("grabbed");
    }

    public virtual void GrabEnd()
    {
        _grabbed = false;
        _rb.velocity = _velector;
        Debug.Log("ungrabbed");
    }
}

