using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drop : MonoBehaviour
{
    float zoom = 55.0f;
    float normal = 60.0f;
    float smooth = 5.0f;

    private bool isZoomed = false;
    private bool isBuilding = false;

    public Vector3 position;
    public Vector3 tposition;

    public GameObject building;

    // Update is called once per frame
    void Update()
    {
        if(!isZoomed && !isBuilding) {
            building.transform.position = new Vector3(16.74141f, 18.0f, -11.23316f);
            isZoomed = true;
        } else if(!isBuilding) {
            building.transform.position = building.transform.position + new Vector3(0.0f, -0.3f, 0.0f);
            transform.position = transform.position + new Vector3(0.0f, 0.0f, 0.5f);
            if(building.transform.position.y < 0.3f) {
                building.transform.position = building.transform.position + new Vector3(0.0f, -0.01f, 0.0f);
                transform.position = tposition;
            }
            if(building.transform.position.y < 0.001f) {
                building.transform.position = position;
                transform.position = tposition;
                isBuilding = true;
            }
        } else if(isZoomed && isBuilding) {
            building.transform.position = position;
            transform.position = transform.position + new Vector3(0.2f, 0.0f, 0.0f);
            if(transform.position.x > -6) {
                isZoomed = false;
            }
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        building = GameObject.Find("Cubo.2511");
        transform.position = new Vector3(-55.0f, 4.624f, -5.242f);
        tposition = new Vector3(-45.0f, 4.624f, 13.242f);
        position = building.transform.position;
    }

}
