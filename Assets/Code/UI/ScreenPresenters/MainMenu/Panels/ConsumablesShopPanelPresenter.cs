using System;
using UnityEngine;
using Modules.Test1C.UI.ScreenViews;
using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI.ScreenPresenters.MainMenu
{
    /// <summary>
    /// Class responsible for providing info in view from GameModel. Operates with ui handlers
    /// </summary>
    public class ConsumablesShopPanelPresenter
    {
        private readonly ConsumablesShopPanelView _consumablesShopPanelView;
        private readonly ILoadScreenView _loadScreenView;
        private Guid _operationGuid;

        public ConsumablesShopPanelPresenter(ConsumablesShopPanelView consumablesShopPanelView, ILoadScreenView loadScreenView)
        {
            _consumablesShopPanelView = consumablesShopPanelView;

            _loadScreenView = loadScreenView;
            // ui click events
            _consumablesShopPanelView.InitClickHandlers(() =>
            {
                _operationGuid = GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
                _loadScreenView.ShowScreen();
            }, () =>
            {
                _operationGuid = GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
                _loadScreenView.ShowScreen();
            },() =>
            {
                // stop processing GameModel model operations
                GameModel.OperationComplete -= ProcessOperation;
            });
            
            // todo: sell amount is hardcode, maybe some logic should be implemented in GameModel
            // todo: also medpack in concept is drawn to be sold in credits and armor in coin - MODEL OR CONCEPT NEED TO BE REDESIGNED
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
                
                _loadScreenView.HideScreen();
            }
        }
    }
}