using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{

    [SerializeField]
    private PlantData plant;
    private SetPlantInfo spi;
    private void Start()
    {
        spi = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    private void OnMouseDown()
    {
        spi.OpenPlantPanel();
        spi.planeName.text = plant.Name;
        spi.threatLevel.text = plant.Threat.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = plant.Icon;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && plant.Threat == PlantData.THREAT.High)
        {
            PlayerControllerScrObj.dead = true;
        }
    }
}
