﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        public GameObject blockPrefab;
        //Grid dimensions
        public int width = 10;
        public int height = 110;
        public int depth = 10;
        public float spacing = 1.2f;
        //multidimensional arrayfor storing the blocks
        private Block[,,] blocks;
        // Use this for initialization
        void Start()
        {
            GenerateBlocks();
        }
        Block SpawnBlock(Vector3 pos)
        {
            GameObject clone = Instantiate(blockPrefab);
            clone.transform.position = pos;
            Block currentBlock = clone.GetComponent<Block>();
            return currentBlock;
        }

        void GenerateBlocks()
        {
            blocks = new Block[width, height, depth];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int z = 0; z < depth; z++)
                    {
                        Vector3 halfSize = new Vector3(
                            width / 2, 
                            height / 2, 
                            depth / 2);
                        halfSize -= new Vector3(0.5f, 0.5f, 0.5f);
                        Vector3 pos = new Vector3(
                            x - halfSize.x,
                            y - halfSize.y,
                            z - halfSize.z);
                        pos *= spacing;

                        Block block = SpawnBlock(pos);
                        block.transform.SetParent(transform);
                        block.x = x;
                        block.y = y;
                        block.z = z;

                        blocks[x, y, z] = block;
                    }
                }
            }
        }

        public int GetAdjMineCountAt(Block b)
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y < 1; y++)
                {
                    for (int z = -1; z < 1; z++)
                    {
                        int desiredX = b.x + x;
                        int desiredY = b.y + y;
                        int desiredZ = b.z + z;
                        if (desiredX <= height && desiredX > 0 && desiredY <= width && desiredY > 0 && desiredZ <= depth && desiredZ > 0)
                        {
                            if (b.isMine == true)
                            {
                                count++;
                            }
                        }
                   
                    }
                }
            }
            return count;
        }
    }

}
