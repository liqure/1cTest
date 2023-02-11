using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Test1C.UI.ScreenViews.MainMenu
{
    public class ExchangePanelView : MonoBehaviour
    {
        [Header("Control elements")] 
        [SerializeField] private Button _exceptBtn;
        [SerializeField] private Button _cancelBtn;
        [SerializeField] private TMPro.TMP_InputField _coinsAmountInputF;
        [SerializeField] private TMPro.TextMeshProUGUI _creditForCoinsAmountTxt;
        
        [Header("Resource info text")]
        [SerializeField] private TMPro.TextMeshProUGUI _coinToCreditRateTxt;
        
        [SerializeField] private TMPro.TextMeshProUGUI _availableCoinsAmountTxt;
        [SerializeField] private TMPro.TextMeshProUGUI _availableCreditsAmountTxt;
        
        public void InitClickHandlers(Action<string> onExceptClickedAction, Action<string> onInputChangeAction, Action onPanelHideClickedAction)
        {
            _exceptBtn.onClick.AddListener(() =>
            {
                onExceptClickedAction?.Invoke(_coinsAmountInputF.text);
            });
            
            _coinsAmountInputF.onValueChanged.AddListener(value =>
            {
                onInputChangeAction?.Invoke(value);
            });
            
            _cancelBtn.onClick.AddListener(() =>
            {
                onPanelHideClickedAction?.Invoke();
                HidePanel();
            });
        }
        
        public void InitTextInfo(int coinToCreditRate)
        {
            _coinToCreditRateTxt.text = $"{coinToCreditRate}";
        }

        public void UpdateInfoView(int coinsAmount, int creditsAmount)
        {
            _availableCoinsAmountTxt.text = $"{coinsAmount}";
            _availableCreditsAmountTxt.text = $"{creditsAmount}";
            _coinsAmountInputF.text = "";
            _creditForCoinsAmountTxt.text = $"0";
        }

        public void SetCoinsExchangeInputFieldValue(int value)
        {
            _coinsAmountInputF.text = $"{value}";
        }
        
        public void SetCoinsExchangeInputFieldValue(string value)
        {
            _coinsAmountInputF.text = $"{value}";
        }
        
        public void SetCreditsForCoinsAmount(int creditsAmount)
        {
            _creditForCoinsAmountTxt.text = $"{creditsAmount}";
        }

        public void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
            _coinsAmountInputF.text = "";
        }
    }
}