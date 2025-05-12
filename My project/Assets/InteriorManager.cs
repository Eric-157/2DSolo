using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorManager : MonoBehaviour
{
    public bool interior;
    public SaveData saveData;
    // Start is called before the first frame update
    void Start()
    {
        saveData = GetComponent<SaveData>();
        
    }

    // Update is called once per frame
    void Update()
    {
        interior = saveData.playerData.interior;
    }
}
