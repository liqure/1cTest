using System;
using UnityEngine;
using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI.ScreenPresenters.MainMenu
{
    public class ConsumablesShopPanelPresenter
    {
        private ConsumablesShopPanelView _consumablesShopPanelView;
        
        private Guid _operationGuid;

        public ConsumablesShopPanelPresenter(ConsumablesShopPanelView consumablesShopPanelView)
        {
            _consumablesShopPanelView = consumablesShopPanelView;
            
            _consumablesShopPanelView.OnBuyMedpackClickedEvent += () =>
            {
                _operationGuid = GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
            };
            _consumablesShopPanelView.OnBuyArmorPlateClickedEvent += () =>
            {
                _operationGuid = GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
            };

            _consumablesShopPanelView.OnPanelHiddenEvent += () =>
            {
                GameModel.OperationComplete -= ProcessOperation;
            };
            
            // todo: sell amount is hardcode, maybe some logic should be implemented in GameModel
            _consumablesShopPanelView.InitTextInfo(50, 25, 
                GameModel.ConsumablesPrice[GameModel.ConsumableTypes.Medpack].CoinPrice, 
                GameModel.ConsumablesPrice[GameModel.ConsumableTypes.ArmorPlate].CreditPrice);
        }

        public void ShowPanel()
        {
            GameModel.OperationComplete += ProcessOperation;
            _consumablesShopPanelView.ShowPanel();
        }

        private void ProcessOperation(GameModel.OperationResult result)
        {
            if (result.Guid == _operationGuid)
            {
                if (result.IsSuccess)
                {
                    Debug.Log("Counsumable purchased!");
                }
                else
                {
                    // todo: use popup for this
                    Debug.Log(result.ErrorDescription);
                }
            }
        }
    }
}