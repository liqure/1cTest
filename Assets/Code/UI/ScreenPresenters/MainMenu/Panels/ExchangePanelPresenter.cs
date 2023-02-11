using System;
using UnityEngine;
using Modules.Test1C.UI.ScreenViews;
using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI.ScreenPresenters.MainMenu
{
    /// <summary>
    /// Class responsible for providing info in view from GameModel. Operates with ui handlers
    /// </summary>
    public class ExchangePanelPresenter
    {
        private readonly ExchangePanelView _exchangePanelView;
        private readonly ILoadScreenView _loadScreenView;
        private Guid _currentOperationGuid;

        public ExchangePanelPresenter(ExchangePanelView exchangePanelView, ILoadScreenView loadScreenView)
        {
            _exchangePanelView = exchangePanelView;
            _loadScreenView = loadScreenView;

            // event hanlers
            _exchangePanelView.InitClickHandlers(inputValue =>
            {
                if(!int.TryParse(inputValue, out var amount))
                {
                    Debug.Log($"Wrong input value {inputValue}!");
                    _exchangePanelView.SetCoinsExchangeInputFieldValue("");
                    return;
                }

                _loadScreenView.ShowScreen();
                _currentOperationGuid = GameModel.ConvertCoinToCredit(amount);
            }, inputValue =>
            {
                if(!int.TryParse(inputValue, out var amount))
                {
                    Debug.Log($"Wrong input value {inputValue}!");
                    _exchangePanelView.SetCoinsExchangeInputFieldValue("");
                    return;
                }

                if (amount > GameModel.CoinCount)
                {
                    _exchangePanelView.SetCoinsExchangeInputFieldValue(GameModel.CoinCount);
                    amount = GameModel.CoinCount;
                }

                int creditsForCoinsAmount = amount * GameModel.CoinToCreditRate;
                _exchangePanelView.SetCreditsForCoinsAmount(creditsForCoinsAmount);
            }, () =>
            {
                GameModel.OperationComplete -= ProcessOperation;
            });
            
            // init exchange rate
            _exchangePanelView.InitTextInfo(GameModel.CoinToCreditRate);
        }

        public void ShowPanel()
        {
            _exchangePanelView.UpdateInfoView(GameModel.CoinCount, GameModel.CreditCount);
            _exchangePanelView.ShowPanel();
            GameModel.OperationComplete += ProcessOperation;
        }
        
        private void ProcessOperation(GameModel.OperationResult result)
        {
            if (result.Guid == _currentOperationGuid)
            {
                if (result.IsSuccess)
                {
                    Debug.Log("Exchange completed!");
                    _exchangePanelView.UpdateInfoView(GameModel.CoinCount, GameModel.CreditCount);
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