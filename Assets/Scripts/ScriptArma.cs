using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArma : MonoBehaviour
{

    Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            col.enabled = true;
        }
        else
        {
            col.enabled = false;
        }
    }
    
}
