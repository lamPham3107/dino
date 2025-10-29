#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;


public class ChangeScene : Editor {

    [MenuItem("Open Scene/Loading #1")]
    public static void OpenLoading()
    {
        OpenScene("LoadingScene");

    }

    [MenuItem("Open Scene/Home #2")]
    public static void OpenHome()
    {
        OpenScene("Home");
    }
    
    [MenuItem("Open Scene/GamePlay #3")]
    public static void OpenGamePlay()
    {
        OpenScene("Game");

    }

    
    private static void OpenScene (string sceneName) {
		if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo ()) {
			EditorSceneManager.OpenScene ("Assets/DinoRun/Scenes/" + sceneName + ".unity");
		}
	}
}
#endif