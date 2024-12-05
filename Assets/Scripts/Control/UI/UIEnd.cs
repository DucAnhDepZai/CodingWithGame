using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIEnd : MonoBehaviour
{
    private UIManager uiManager;
    [SerializeField] private RectTransform panelPopup;
    [SerializeField] private Button replay, next;
    [SerializeField] private Text time, death;
   
    private void Start()
    {
        replay.onClick.RemoveAllListeners();
        next.onClick.RemoveAllListeners();
        replay.onClick.AddListener(OnClickReplay);
        next.onClick.AddListener(OnClickNext);
    }
    public void Init(UIManager uiManager)
    {
        
        this.uiManager = uiManager;
        ShowPanel();
        time.text = GameManager.Instance.timeFinish + "";
        death.text = GameManager.Instance.deathCount + "";
    }

    public void Close()
    {
        gameObject.SetActive(false);

    }
    public void ShowPanel()
    {
        gameObject.SetActive(true);
        panelPopup.localScale = Vector3.zero;
        panelPopup.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    public void HidePanel()
    {
        panelPopup.DOScale(Vector3.zero, 0.5f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);             
            });
    }
    private void OnClickReplay()
    {
        Debug.Log("Replay");
        Application.ExternalCall("replay");
    }
    private void OnClickNext()
    {
        Debug.Log("Next");
        Application.ExternalCall("next");
    }
   
}
