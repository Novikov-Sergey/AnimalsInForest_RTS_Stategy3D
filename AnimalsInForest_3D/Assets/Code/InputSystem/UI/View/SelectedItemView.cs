using UnityEngine;
using UnityEngine.UI;

namespace InputSystem.UI.View
{
    public class SelectedItemView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;
        [SerializeField] private Text _health;
        //Слайдер
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillmage;

        public Sprite Icon { set => _icon.sprite = value; }

        public string Name { set => _name.text = value; }

        public string Health { set => _health.text = value; }

        //public float HealthBar { set => _healthBar.value = value; }

        public void SliderController (float maxHealth, float health)
        {
            _healthBar.minValue = 0;
            _healthBar.maxValue = maxHealth;
            _healthBar.value = health;
            var color = Color.Lerp(Color.red, Color.green, health / maxHealth);
            _sliderBackground.color = color * 0.5f;
            _sliderFillmage.color = color;
        }
    }
} 
