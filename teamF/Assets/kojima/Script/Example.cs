using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TouchScript;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        var t = TouchManager.Instance;
        if (t == null) return;
        t.PointersPressed += OnPointersPressed;
    }

    private void OnDisable()
    {
        var t = TouchManager.Instance;
        if (t == null) return;
        t.PointersPressed -= OnPointersPressed;
    }

    private void OnPointersPressed(object sender, PointerEventArgs e)
    {
        foreach (var n in e.Pointers)
        {
            Debug.LogFormat("Id: {0} Position: {1}", n.Id, n.Position);
        }
    }
}
