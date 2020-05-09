using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
	
	public Transform target;
	public float m_speed;
	Camera myCam;
	public Animator anim;
	private MainMenu menu;

	void Awake () {
		#if UNITY_EDITOR
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = 60;
		#endif
	}
	void Start(){
		//myCam = GetComponent<Camera> ();
		anim = GetComponent<Animator>();
		menu = FindObjectOfType<MainMenu> ();
	}

	void Update(){
        //myCam.orthographicSize = (Screen.height / 100f) / 7.8f;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0, 0, -10);
        }

        if (menu) 
		{
            if (menu.LevelSelect)
            {
		    //	anim.enabled = true;
			    anim.SetBool ("CamMoveToLevel", true);
			    anim.SetBool ("CamMoveToMenu", false);
            }
            else if (!menu.LevelSelect)
            {
                //	anim.enabled = true;
                anim.SetBool("CamMoveToMenu", true);
                anim.SetBool("CamMoveToLevel", false);
                //anim.SetBool ("Default", true);
            }
        } 
	}
	void AnimStop()
	{
		anim.enabled = false;
	}

}
