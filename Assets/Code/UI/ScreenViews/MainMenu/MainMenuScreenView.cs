using UnityEngine;
using UnityEngine.UI;
using System;

namespace Modules.Test1C.UI.ScreenViews.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour
    {
        [Header("Control btns")]
        [SerializeField] private Button _openReservesShopBtn;
        [SerializeField] private Button _openExchangeBtn;

        [Header("Resource info text")] 
        [SerializeField] private TMPro.TextMeshProUGUI _medpackAmountTxt;
        [SerializeField] private TMPro.TextMeshProUGUI _armorPlatesAmountTxt;
        
        [SerializeField] private TMPro.TextMeshProUGUI _coinsAmountTxt;
        [SerializeField] private TMPro.TextMeshProUGUI _creditsAmountTxt;

        public event Action OpenConsumablesShopEvent;
        public event Action OpenExchangeEvent;
        
        private void Start()
        {
            _openReservesShopBtn.onClick.AddListener(() => OpenConsumablesShopEvent?.Invoke());
            _openExchangeBtn.onClick.AddListener(() => OpenExchangeEvent?.Invoke());
        }

        public void SetConsumablesTxtInfo(int medpackAmount, int armorPlatesAmount)
        {
            _medpackAmountTxt.text = $"{medpackAmount}";
            _armorPlatesAmountTxt.text = $"{armorPlatesAmount}";
        }

        public void SetCurrencyTxtInfo(int coinsAmount, int creditsAmount)
        {
            _coinsAmountTxt.text = $"{coinsAmount}";
            _creditsAmountTxt.text = $"{creditsAmount}";
        }
    }
}