using UnityEngine;
using Modules.Test1C.UI.ScreenViews;
using Modules.Test1C.UI.ScreenPresenters;
using Modules.Test1C.UI.ScreenPresenters.MainMenu;
using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI
{
    public class UiIocContainer: MonoBehaviour
    {
        [SerializeField] private MainMenuScreenView _mainMenuScreenView;
        [SerializeField] private ConsumablesShopPanelView _consumablesShopPanelView;
        [SerializeField] private ExchangePanelView _exchangePanelView;

        private void Awake()
        {
            new MainMenuScreenPresenter(_mainMenuScreenView, _consumablesShopPanelView, _exchangePanelView);
        }
    }
}