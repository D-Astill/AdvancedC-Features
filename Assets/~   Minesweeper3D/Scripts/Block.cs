using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    [RequireComponent(typeof(Renderer))]
    public class Block : MonoBehaviour
    {
        public int x, y, z;
        public bool isMine = false;
        [Range(0, 1)]
        public float chance;
        [Header("References")]
        [Space(5)]
        public Color[] textColors;
        public TextMesh textElement;
        public Transform mine;

        public bool isRevealed = false;
        private Renderer rend;
        // Use this for initialization
        void Awake()
        {
            rend = GetComponent<Renderer>();
            
        }
        void Start()
        {
            for (int i = 0; i < textColors.Length; i++)
            {
                textColors[i].r = Random.Range(0f, 1f);
                textColors[i].g = Random.Range(0f, 1f);
                textColors[i].b = Random.Range(0f, 1f);
                textColors[i].a = 1;
            }
            //Detach text element
            textElement.transform.SetParent(null);
            isMine = Random.value < 0.05f;
        }

        void UpdateText(int adjcentMines)
        {
            if (adjcentMines > 0)
            {
                textElement.text = adjcentMines.ToString();
                if (adjcentMines >= 0 && adjcentMines < textColors.Length)
                {
                    textElement.color = textColors[adjcentMines];
                }
            }
        }

        public void Reveal(int adjacentMines)
        {
            isRevealed = true;
            if (isMine)
            {
                mine.gameObject.SetActive(true);
                mine.SetParent(null);
            }
            else
            {
                UpdateText(adjacentMines);
            }
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
