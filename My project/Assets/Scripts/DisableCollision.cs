using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DisableCollision : MonoBehaviour
{
    public InteriorManager interiorManager;
    public TilemapRenderer tilemapRenderer;
    public TilemapCollider2D tilemapCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] system = GameObject.FindGameObjectsWithTag("System");
        interiorManager = system[0].GetComponent<InteriorManager>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (interiorManager.interior == true)
        {
            tilemapRenderer.enabled = false;
            tilemapCollider2D.enabled = false;
        }
        else
        {
            tilemapRenderer.enabled = true;
            tilemapCollider2D.enabled = true;

        }
    }
}
