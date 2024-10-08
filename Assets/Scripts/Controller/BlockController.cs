using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Block block;
    public GameObject rootBlock;
    private List<GameObject> blocks;
    void Start()
    {
        blocks = new List<GameObject>();
        blocks.Add(rootBlock);
    }

    public void SetWidth(int width)
    {
        block.width = width;
        while (blocks.Count < width)
        {

        }
        while (blocks.Count > width)
        {

        }
    }
    public void SetHeight(int height)
    {
        block.height = height;
    }
}
