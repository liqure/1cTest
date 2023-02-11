using UnityEngine;
using UnityEngine.UI;
using System;

namespace Modules.Test1C.UI.ScreenViews.MainMenu
{
    public class ConsumablesShopPanelView : MonoBehaviour
    {
        [Header("Control btns")] 
        [SerializeField] private Button _buyMedpackBtn;
        [SerializeField] private Button _buyArmorPlateBtn;
        [SerializeField] private Button _closePanelBtn;
        
        [Header("Info txt")]
        [SerializeField] private TMPro.TextMeshProUGUI _medpackInSellPackAmountTxt;
        [SerializeField] private TMPro.TextMeshProUGUI _armorPlatesInSellPackAmountTxt;
        
        [SerializeField] private TMPro.TextMeshProUGUI _medpackPackPriceTxt;
        [SerializeField] private TMPro.TextMeshProUGUI _armorPackPriceTxt;
        
        public void InitClickHandlers(Action onBuyMedpackClickedAction, Action onBuyArmorPlateClickedAction, Action onPanelHideClickedAction)
        {
            _buyMedpackBtn.onClick.AddListener(() => onBuyMedpackClickedAction?.Invoke());
            _buyArmorPlateBtn.onClick.AddListener(() => onBuyArmorPlateClickedAction?.Invoke());
            _closePanelBtn.onClick.AddListener(() =>
            {
                onPanelHideClickedAction?.Invoke();
                HidePanel();
            });
        }

        public void InitTextInfo(int medpackInSellPackAmount, int armorPlatesInSellPackAmount, int medpackPackPrice, 
            int armorPackPrice)
        {
            _medpackInSellPackAmountTxt.text = $"{medpackInSellPackAmount}";
            _armorPlatesInSellPackAmountTxt.text = $"{armorPlatesInSellPackAmount}";
            _medpackPackPriceTxt.text = $"{medpackPackPrice}";
            _armorPackPriceTxt.text = $"{armorPackPrice}";
        }

        public void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }
    }
}