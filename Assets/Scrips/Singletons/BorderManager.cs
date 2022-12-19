using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{
    public static BorderManager Instance;

    [SerializeField]
    float miny, maxy, minx, maxx;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float MaxY()
    {
        return maxy;
    }
    public float MinY()
    {
        return miny;
    }

    public float MaxX()
    {
        return maxx;
    }

    public float MinX()
    {
        return minx;
    }
}
