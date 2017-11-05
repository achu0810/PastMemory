using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class ButtonIconManager : MonoBehaviour {

	private Image m_buttonImage;
	[SerializeField]private bool canPlay = true;
	[SerializeField]private Sprite m_playSprite;
	[SerializeField]private Sprite m_stopSprite;
	private AudioClip[] m_clips;
	private int m_count = 0;

	private AudioSource m_audio;
	[SerializeField]private SetupDatabase m_database;

	public bool CanPlay {
		set {
			canPlay = value;
		}
		get {
			return canPlay;
		}
	}

	void Start () {
		m_clips = new AudioClip[m_database.CountSecond];
		m_buttonImage = GetComponent<Image> ();
		m_audio = GetComponent<AudioSource> ();



	}

	public void OnClicked() {

		if (CanPlay) {
			CanPlay = false;
			m_buttonImage.sprite = m_stopSprite;
		} else {
			CanPlay = true;
			m_buttonImage.sprite = m_playSprite;
		}
	}

}
