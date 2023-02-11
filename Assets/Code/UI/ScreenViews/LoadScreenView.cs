using UnityEngine;

namespace Modules.Test1C.UI.ScreenViews
{
    //todo: maybe some other logic required to handle loading

    public interface ILoadScreenView
    {
        void ShowScreen();
        void HideScreen();
    }

    /// <summary>
    /// Class represents loading, when Model try to handle operation with fake delay. View have canvas sortingOrder - SORTING_ORDER 
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class LoadScreenView: MonoBehaviour, ILoadScreenView
    {
        private const int SORTING_ORDER = 10;
        
        [SerializeField] private RectTransform _loadSpinnerRT;
        [SerializeField] private Vector3 _rotateV3;

        private void OnValidate()
        {
            GetComponent<Canvas>().sortingOrder = SORTING_ORDER;
        }

        private void Update()
        {
            _loadSpinnerRT.Rotate(_rotateV3);
        }

        public void ShowScreen()
        {
            gameObject.SetActive(true);
        }

        public void HideScreen()
        {
            gameObject.SetActive(false);
        }
    }
}