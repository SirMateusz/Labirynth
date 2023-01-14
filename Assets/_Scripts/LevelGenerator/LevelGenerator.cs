using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;

    public Material material01, material02;

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0) return;

        foreach (ColorToPrefab mapping in colorMappings)
        {
            if (mapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(mapping.prefab, position, Quaternion.identity, transform);
            }

        }
    }

    public void GenerateLabirynth()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }

    public void ColorTheChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Wall")
            {
                if (Random.Range(1, 100) % 3 == 0)
                {
                    child.gameObject.GetComponent<Renderer>().material = material01;
                }
                else
                {
                    child.gameObject.GetComponent<Renderer>().material = material02;
                }
            }

            if (child.childCount > 0)
            {
                foreach (Transform grandchild in child.transform)
                {
                    if (grandchild.tag == "Wall")
                    {
                        if (Random.Range(1, 100) % 3 == 0)
                        {
                            grandchild.gameObject.GetComponent<Renderer>().material = material01;
                        }
                        else
                        {
                            grandchild.gameObject.GetComponent<Renderer>().material = material02;
                        }
                    }
                }
            }
        }
    }
}
