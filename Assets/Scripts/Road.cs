using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject RoadObject;
    private float x = 0.71f, z = 0.71f;
    public Vector3 lastpos;
    // Start is called before the first frame update
    public void StartBuilding()
    {
        InvokeRepeating("CreateNewObject", 1F, 0.5F);
    }

    public void CreateNewObject()
    {
        Vector3 spawnpos = Vector3.zero;
        float chance = Random.Range(1, 3);
        if (chance == 1)
            spawnpos = new Vector3(lastpos.x + x, lastpos.y, lastpos.z + z);
        else
            spawnpos = new Vector3(lastpos.x - x, lastpos.y, lastpos.z + z);

        chance = Random.Range(0, 100);

        GameObject g = Instantiate(RoadObject, spawnpos, Quaternion.Euler(0, 45F, 0));

        chance = Random.Range(1, 4);
        if (chance == 1)
        {
            spawnpos = new Vector3(lastpos.x + Random.Range(-0.5f, 0.5f), 0.5f, lastpos.z + Random.Range(-0.5f, 0.5f));
            g.transform.GetChild(0).gameObject.SetActive(true);
            g.transform.GetChild(0).gameObject.transform.position = spawnpos;
        }
        lastpos = g.transform.position;
        Destroy(g, 10F);
    }
}
