using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DisableDecoration : MonoBehaviour
{
    public InteriorManager interiorManager;
    public TilemapRenderer tilemapRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] system = GameObject.FindGameObjectsWithTag("System");
        interiorManager = system[0].GetComponent<InteriorManager>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interiorManager.interior == true)
        {
            tilemapRenderer.enabled = false;
        }
        else
        {
            tilemapRenderer.enabled = true;
        }
    }
}
