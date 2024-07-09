using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 100f;
    [SerializeField] private GameObject mic;
    [SerializeField] private GameObject carne;

    void CollectCookedFood()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {

                food food = hit.transform.gameObject.GetComponent<food>();

                if (food != null)
                {
                    bool wellDone = food.GetWellDoneBool;

                    if (wellDone)
                    {
                        Debug.Log("Food is ready");
                        Destroy(hit.transform.gameObject);
                    }
                    else
                    {
                        Debug.Log("Food not YET cooked Sir!");
                    }

                    Debug.Log(wellDone);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        CollectCookedFood();
    }
}
