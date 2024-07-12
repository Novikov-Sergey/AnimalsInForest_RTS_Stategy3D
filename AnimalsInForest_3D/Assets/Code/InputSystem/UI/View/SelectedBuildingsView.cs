using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InputSystem.UI.View
{
    public class SelectedBuildingsView : MonoBehaviour
    {
        [SerializeField] private GameObject _selected;

        public void SetSelected(bool isSelected)
        {
            _selected.SetActive(isSelected);
        }
    }
}
