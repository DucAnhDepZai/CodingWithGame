
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LessonController : MonoBehaviour
{
    [SerializeField] private string loadString;    
    private GameObject curLesson;
    private string curPath;
    void Start()
    {
#if UNITY_EDITOR
        if(loadString != null && loadString != "")
        LoadLesson(loadString);
#endif
    }

    public void LoadLesson(string s)
    {
        curPath = s;
        string[] ss = s.Split('/');
        int lesson_id = Convert.ToInt32(ss[1]);
        string path = "Levels/" + s;
        GameObject lesson = Resources.Load<GameObject>(path);
        curLesson = Instantiate(lesson);
        GetLesson(lesson_id);     
    }

    public void OnReload()
    {
        Destroy(curLesson);
        LoadLesson(curPath);
    }
    public void GetLesson(int lessonId)
    {
        string url = "http://localhost:8080/api/lesson/" + lessonId;
        StartCoroutine(GetLessonData(url));
    }

    private IEnumerator GetLessonData(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Access-Control-Allow-Origin", "*");
            request.SetRequestHeader("Access-Control-Allow-Methods", "DELETE, POST, GET, OPTIONS");
            request.SetRequestHeader("Access-Control-Allow-Headers", "Content-Type, Authorization, X-Requested-With");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                PopupNoticeController.Instance.Notice(request.error);
            }
            else
            {
                // Parse JSON response
                string jsonResponse = request.downloadHandler.text;
                Debug.Log(jsonResponse);
                Lesson lesson = JsonUtility.FromJson<Lesson>(jsonResponse);
                curLesson.GetComponent<BaseLessonController>().lesson = lesson;
                PopupManager.Instance.InitMissionPopup();
                UIManager.Instance.cameraUI.gameObject.SetActive(false);
                UIManager.Instance.cameraUI.gameObject.SetActive(true);
            }
        }
    }
}
