using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class DestroyOnInvis : MonoBehaviour
{
    private Renderer rend;
	
	void Awake ()
    {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!rend.isVisible)
        {
            Destroy(gameObject);
        }
	}
}
