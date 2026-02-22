using TMPro;
using UnityEngine;

namespace Gameplay.Money.Core
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyValueText;

        public void SetMoney(float amount)
        {
            _moneyValueText.text = amount.ToString();
        }
    }
}