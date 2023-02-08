using System;
using UnityEngine;
using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI.ScreenPresenters.MainMenu
{
    public class ExchangePanelPresenter
    {
        private ExchangePanelView _exchangePanelView;
        private Guid _currentOperationGuid;
        
        public ExchangePanelPresenter(ExchangePanelView exchangePanelView)
        {
            _exchangePanelView = exchangePanelView;

            // event hanlers
            _exchangePanelView.OnPanelHiddenEvent += () =>
            {
                GameModel.OperationComplete -= ProcessOperation;
            };
            
            _exchangePanelView.OnExceptClickedEvent += inputValue =>
            {
                if(!int.TryParse(inputValue, out var amount))
                {
                    Debug.Log($"Wrong input value {inputValue}!");
                    return;
                }

                _currentOperationGuid = GameModel.ConvertCoinToCredit(amount);
            };

            _exchangePanelView.OnInputChangeEvent += inputValue =>
            {
                if(!int.TryParse(inputValue, out var amount))
                {
                    Debug.Log($"Wrong input value {inputValue}!");
                    return;
                }

                if (amount > GameModel.CoinCount)
                {
                    _exchangePanelView.SetCoinsExchangeInputFieldValue(GameModel.CoinCount);
                    amount = GameModel.CoinCount;
                }

                int creditsForCoinsAmount = amount * GameModel.CoinToCreditRate;
                _exchangePanelView.SetCreditsForCoinsAmount(creditsForCoinsAmount);
            };
            
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
            }
        }
    }
}