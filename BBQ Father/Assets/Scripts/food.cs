using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    [SerializeField] private float cookTime = 100f;
    
    [SerializeField] private Material rawMaterial;
    [SerializeField] private Material cookedMaterial;
    [SerializeField] private Material burntMaterial;
    
    private float cookedWindowA;
    private float cookedWindowB;
    
    private bool burned = false;
    private bool wellDone = false;
    private MeshRenderer foodMeshRenderer;

    public bool GetWellDoneBool
    {
        get{
            return wellDone;
        }
    }
    void GenerateCookedWindow()
    {
        cookedWindowB = Random.Range(10, cookTime - 10);
        int padding = Random.Range(3, 10);
        cookedWindowA = cookedWindowB - padding;
    }
    void UpdateFoodCookState(float time)
    {
        if (time > cookedWindowB)
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
                    burned = true;
                }
            }
        }

    }
    void GetCooked()
    {
        if (!burned && cookTime > 0)
        {
            cookTime -= Time.deltaTime;
            UpdateFoodCookState(cookTime);
        }
        else
        {
            burned = true;
            Debug.Log("COOKED!");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foodMeshRenderer = GetComponent<MeshRenderer>();
        GenerateCookedWindow();
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetKey(KeyCode.Space)*/ true)
        {
            GetCooked();
            Debug.Log(cookTime);
        }
    }
}
