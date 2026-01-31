using TMPro;
using UnityEngine;

namespace Money
{
    public class PlayerMoneyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _moneyValueText;

        public void SetMoney(float amount)
        {
            _moneyValueText.text = amount.ToString();
        }
    }
}