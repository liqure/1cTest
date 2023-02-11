using UnityEngine;
using Modules.Test1C.UI.ScreenViews;
using Modules.Test1C.UI.ScreenPresenters.MainMenu;
using Modules.Test1C.UI.ScreenViews.MainMenu;

namespace Modules.Test1C.UI
{
    /// <summary>
    /// Enter point for all ui scripts
    /// </summary>
    public class UiIocContainer: MonoBehaviour
    {
        [SerializeField] private MainMenuScreenView _mainMenuScreenView;
        [SerializeField] private ConsumablesShopPanelView _consumablesShopPanelView;
        [SerializeField] private ExchangePanelView _exchangePanelView;
        
        [Space(20)]
        [SerializeField] private LoadScreenView _loadScreenView;
        

        private void Awake()
        {
            new MainMenuScreenPresenter(_mainMenuScreenView, _consumablesShopPanelView, _exchangePanelView, _loadScreenView);
        }
    }
}