using UnityEngine;
using System.Linq;


namespace InputSystem.UI.View
{
    public class SelectedOutlineView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] _renderers;
        [SerializeField] private Material _outlineMaterial;

        private bool _isSelectedCache;

        public void SetSelected(bool isSelected)
        {
            // проверка на повторяющийся сигнал
            if (isSelected == _isSelectedCache)
            {
                return;
            }

            for (int i = 0; i < _renderers.Length; i++)
            {   
                // перебираем материалы и присваеваем новым переменным
                var renderer = _renderers[i];
                var materialsList = renderer.materials.ToList();


                if (isSelected)
                {
                    materialsList.Add(_outlineMaterial);
                }
                else
                {
                    materialsList.RemoveAt(materialsList.Count - 1);
                }

                renderer.materials = materialsList.ToArray();
            }
            _isSelectedCache = isSelected;
        }
    }
}
