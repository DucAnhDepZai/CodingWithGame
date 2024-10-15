using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Block block;
    public GameObject rootBlock;
    public GameObject generateBlock;
    private Stack<GameObject> blocks;
    private Queue<GameObject> queue;
    void Start()
    {       
        blocks = new Stack<GameObject>();
        blocks.Push(rootBlock);
    }
    public void SetHeight(int height)
    {
        block.height = height;
    }
    private void Update()
    {
       
    }
   
    private void AddLeftBlock(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 posLeft = new Vector3(-1f, 0, 0);
            GameObject newBlock = Instantiate(generateBlock, posLeft, Quaternion.identity);
            newBlock.transform.SetParent(blocks.Peek().transform, false);
            blocks.Push(newBlock);
            newBlock.GetComponent<GenerateBlock>().Spawn();
        }
    }
    private void AddRighttBlock(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 posLeft = new Vector3(1f, 0, 0);
            GameObject newBlock = Instantiate(generateBlock, posLeft, Quaternion.identity);
            newBlock.transform.SetParent(blocks.Peek().transform, false);
            blocks.Push(newBlock);
            newBlock.GetComponent<GenerateBlock>().Spawn();
        }
    }
    private void AddAboveBlock(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 posLeft = new Vector3(0, 1f, 0);
            GameObject newBlock = Instantiate(generateBlock, posLeft, Quaternion.identity);
            newBlock.transform.SetParent(blocks.Peek().transform, false);
            blocks.Push(newBlock);
            newBlock.GetComponent<GenerateBlock>().Spawn();
        }
    }
    private void AddBelowBlock(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 posLeft = new Vector3(0, -1f, 0);
            GameObject newBlock = Instantiate(generateBlock, posLeft, Quaternion.identity);
            newBlock.transform.SetParent(blocks.Peek().transform, false);
            blocks.Push(newBlock);
            newBlock.GetComponent<GenerateBlock>().Spawn();
        }
    }
}
