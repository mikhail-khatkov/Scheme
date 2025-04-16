using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class Inventory : MonoBehaviour
    {
        private List<UnifiedInventoryItems> _items = new();
        public Button PreviousButton, NextButton;

        private int _startIndex = 0;
        
        private int StartIndex
        {
            get => _startIndex;
            set
            {
                if (value >= 0 && value < _items.Count)
                    _startIndex = value;
            }
        } 

        private int _length = 2;


        public void Initialize()
        {
            _items.AddRange(GetComponentsInChildren<UnifiedInventoryItems>());
            
            UpdateDisplayedItems();

            NextButton.onClick.AddListener(NextPage);
            PreviousButton.onClick.AddListener(PreviousPage);
        }
        
        private void UpdateDisplayedItems()
        {
            PreviousButton.gameObject.SetActive(_items.Count > 2 && StartIndex != 0);
            NextButton.gameObject.SetActive(_items.Count > 2 && StartIndex != _items.Count - 2);
            
            for (int i = 0; i < _items.Count; i++)
            {
                if (IndexIsCorrect(i))
                {
                    _items[i].gameObject.SetActive(true);
                    continue;
                }
                _items[i].gameObject.SetActive(false);
            }
        }

        private void NextPage()
        {
            StartIndex++;
            UpdateDisplayedItems();
        }

        private void PreviousPage()
        {
            StartIndex--;
            UpdateDisplayedItems();
        }

        private bool IndexIsCorrect(int index)
        {
            for (int i = 0; i < _length; i++)
            {
                if (StartIndex + i == index)
                    return true;
            }

            return false;
        }
    }
}