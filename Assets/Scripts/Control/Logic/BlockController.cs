using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public Block block;
    public int limitLength;
    public GameObject rootBlock;
    public GameObject generateBlock;
    private Stack<GameObject> blocks;
    private Queue<GameObject> queue;
    private Vector2 squareSize;
    void Start()
    {       
        blocks = new Stack<GameObject>();
        blocks.Push(rootBlock);
        squareSize = generateBlock.GetComponent<BoxCollider2D>().size;
    }
    public void SetRight(int height)
    {
        height = Mathf.Min(height, limitLength);
        while(block.height > height)
        {
            block.height--;
            GameObject firstBlock = blocks.Peek();
            blocks.Pop();
            firstBlock.GetComponent<GenerateBlock>().Clear();
        }
        if(block.height < height)
        {
            AddRightBlock(height -  block.height);
            block.height = height;
        }

    }

    public void SetLeft(int height)
    {
        height = Mathf.Min(height, limitLength);
        while (block.height > height)
        {
            block.height--;
            GameObject firstBlock = blocks.Peek();
            blocks.Pop();
            firstBlock.GetComponent<GenerateBlock>().Clear();
        }
        if (block.height < height)
        {
            AddLeftBlock(height - block.height);
            block.height = height;
        }

    }

    public void SetY(int width)
    {
        block.width = width;
    }

    private void AddLeftBlock(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 posLeft = new Vector3(-squareSize.x, 0, 0);
            GameObject newBlock = Instantiate(generateBlock, posLeft, Quaternion.identity);
            newBlock.transform.SetParent(blocks.Peek().transform, false);
            blocks.Push(newBlock);
            newBlock.GetComponent<GenerateBlock>().Spawn();
        }
    }
    private void AddRightBlock(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 posLeft = new Vector3(squareSize.x, 0, 0);
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
            Vector3 posLeft = new Vector3(0, squareSize.y, 0);
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
            Vector3 posLeft = new Vector3(0, -squareSize.y, 0);
            GameObject newBlock = Instantiate(generateBlock, posLeft, Quaternion.identity);
            newBlock.transform.SetParent(blocks.Peek().transform, false);
            blocks.Push(newBlock);
            newBlock.GetComponent<GenerateBlock>().Spawn();
        }
    }
}
