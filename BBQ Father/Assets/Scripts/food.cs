using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    [SerializeField] private float cookTime = 100f;
    [SerializeField] private Material rawMaterial;
    [SerializeField] private Material cookedMaterial;
    [SerializeField] private Material burntMaterial;
    
    private bool burned = false;

    void GetCooked()
    {
        if (!burned && cookTime > 0)
        {
            cookTime -= Time.deltaTime;
        }
        else
        {
            burned = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
