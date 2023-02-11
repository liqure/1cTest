using Modules.Test1C.UI.ScreenViews;
using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI.ScreenPresenters.MainMenu
{
    /// <summary>
    /// Class controls resource info text on MainMenuScreen and opens operation panels.
    /// </summary>
    public class MainMenuScreenPresenter
    {
        public MainMenuScreenPresenter(MainMenuScreenView mainMenuScreenView, ConsumablesShopPanelView consumablesShopPanelView, 
            ExchangePanelView exchangePanelView, ILoadScreenView loadScreenView)
        {
            SetResourcesInfo(mainMenuScreenView);
            GameModel.ModelChanged += () => SetResourcesInfo(mainMenuScreenView);
            
            var exchangePanelPresenter = new ExchangePanelPresenter(exchangePanelView, loadScreenView);
            var consumablesShopPanelPresenter = new ConsumablesShopPanelPresenter(consumablesShopPanelView, loadScreenView);
            
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