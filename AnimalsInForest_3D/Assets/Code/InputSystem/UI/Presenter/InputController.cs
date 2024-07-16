using UnityEngine;
using Abstraction;
using InputSystem.UI.Model;


namespace InputSystem.UI.Presenter
{
    //Отслеживает клики мышкой
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectedItemModel _currentSelected;

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitinfo))
                {
                    // Узнаем есть ли нужный компонент 
                    var selectedItem = hitinfo.collider.gameObject.GetComponent<ISelecatable>();

                    if (selectedItem != null)
                    {                         
                        //Передаем инфо модель выбранного объекта
                        _currentSelected.SetValue(selectedItem);
                    }
                    else
                    {
                        _currentSelected.SetZero();
                    }
                }
            }
        }
    }
}