using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI.ScreenPresenters.MainMenu
{
    public class MainMenuScreenPresenter
    {
        public MainMenuScreenPresenter(MainMenuScreenView mainMenuScreenView, ConsumablesShopPanelView consumablesShopPanelView, 
            ExchangePanelView exchangePanelView)
        {
            SetResourcesInfo(mainMenuScreenView);
            GameModel.ModelChanged += () => SetResourcesInfo(mainMenuScreenView);
            
            var exchangePanelPresenter = new ExchangePanelPresenter(exchangePanelView);
            var consumablesShopPanelPresenter = new ConsumablesShopPanelPresenter(consumablesShopPanelView);
            
            // open panels events
            mainMenuScreenView.OpenExchangeEvent += () => { exchangePanelPresenter.ShowPanel(); };
            mainMenuScreenView.OpenConsumablesShopEvent += () => { consumablesShopPanelPresenter.ShowPanel(); };
        }

        private void SetResourcesInfo(MainMenuScreenView mainMenuScreenView)
        {
            mainMenuScreenView.SetCurrencyTxtInfo(GameModel.CoinCount, GameModel.CreditCount);
            mainMenuScreenView.SetConsumablesTxtInfo(GameModel.GetConsumableCount(GameModel.ConsumableTypes.Medpack),
                GameModel.GetConsumableCount(GameModel.ConsumableTypes.ArmorPlate));
        }
    }
}