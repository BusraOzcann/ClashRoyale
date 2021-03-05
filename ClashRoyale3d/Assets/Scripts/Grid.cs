using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject gridPrefab;
    public Transform groundScale;

    private void Start()
    {
        SetGrid();  
    }

    void SetGrid()
    {
        float xPos = 0 - groundScale.localScale.x / 2 + gridPrefab.transform.localScale.x / 2;
        float zPos = 0 - groundScale.localScale.z / 2 + gridPrefab.transform.localScale.z / 2;

        for (int i = 0; i < Mathf.Ceil(groundScale.localScale.z); i++)
        {
            for (int j = 0; j < Mathf.Ceil(groundScale.localScale.x); j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3(xPos, gridPrefab.transform.position.y, zPos), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.name = j + " . " + i;
                xPos += 1;
            }
            zPos += 1;
            xPos = 0 - groundScale.localScale.x / 2 + gridPrefab.transform.localScale.x / 2;
        }
    }
}
