using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    [SerializeField] private float cookTime = 100f;
    
    [SerializeField] private Material rawMaterial;
    [SerializeField] private Material cookedMaterial;
    [SerializeField] private Material burntMaterial;
    
    [SerializeField] private float cookedWindowA;
    [SerializeField] private float cookedWindowB;
    
    private bool burned = false;
    private bool wellDone = false;
    private MeshRenderer foodMeshRenderer;

    void updateFoodCookState(float time)
    {
        if (cookedWindowB < time)
        {
            foodMeshRenderer.material = new Material(rawMaterial);
            wellDone = false;
        }
        else
        {

            if (cookedWindowA <= time && time <= cookedWindowB)
            {
                foodMeshRenderer.material = new Material(cookedMaterial);
                wellDone = true;
            }
            else
            {
                if (time < cookedWindowA)
                {
                    foodMeshRenderer.material = new Material(burntMaterial);
                    wellDone = false;
                }
            }
        }

    }
    void GetCooked()
    {
        if (!burned && cookTime > 0)
        {
            cookTime -= Time.deltaTime;
            updateFoodCookState(cookTime);
        }
        else
        {
            burned = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foodMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetCooked();
            Debug.Log(cookTime);
        }
    }
}
