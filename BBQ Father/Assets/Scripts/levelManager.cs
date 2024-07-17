using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 100f;
    [SerializeField] private GameObject mic;
    [SerializeField] private GameObject carne;

    [SerializeField] private float fireHeatLevel = 300f; // 300 seconds

    [SerializeField] private Slider FireStrenghtSlider;
    [SerializeField] private TMP_Text Wins;
    [SerializeField] private TMP_Text Fails;
    int nrOfWins = 0;
    int nrOfFails = 0;

    void BuildUI()
    {
        float value = fireHeatLevel / 300;
        FireStrenghtSlider.value = value;

        string wins = "WINS " + nrOfWins.ToString();
        string fails = "FAILS " + nrOfFails.ToString();

        Wins.text = wins;
        Fails.text = fails;
    }

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
                        nrOfWins++;
                        Destroy(hit.transform.gameObject);
                    }
                    else
                    {
                        Debug.Log("Food not YET cooked Sir!");
                        nrOfFails++;
                        Destroy(hit.transform.gameObject);
                    }

                    Debug.Log(wellDone);
                }
            }
        }
    }

    void BBQLogic()
    {
        if (fireHeatLevel > 0)
        {
            fireHeatLevel -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Game Over");
        }

        // press E for a burst of power to the fire
        if (Input.GetKeyDown(KeyCode.E)) {
            fireHeatLevel += 50f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        BBQLogic();
        CollectCookedFood();
        BuildUI();
    }
}
