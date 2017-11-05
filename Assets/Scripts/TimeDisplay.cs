using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {
	
	[SerializeField]private bool isBefore;
	private bool isFinishedOnce;
	private Text m_text;

	private int m_beforeSecond;
	private int m_afterSecond;
	private System.DateTime m_beforeDateTime;
	private System.DateTime m_afterDateTime;
	private System.TimeSpan m_sub;
	private System.DateTime m_tmp;

	[SerializeField]private SetupDatabase m_database;

	void Start () {
		m_tmp = new DateTime (1, 1, 1, 0, 0, m_database.CountSecond);
		m_text = GetComponent<Text> ();
		m_beforeDateTime = System.DateTime.Now;
		m_text.text = m_beforeDateTime.ToString();

		if (!isBefore) {				 // 終わりの時間
			this.ObserveEveryValueChanged (_ => System.DateTime.Now.Second)
			.Subscribe (_ => {
					m_text.text = System.DateTime.Now.ToString ();
			});
		} else { 						 // 始まりの時間

			this.ObserveEveryValueChanged (_ => System.DateTime.Now.Second)
				.Subscribe (_ => {
					m_afterDateTime = System.DateTime.Now;

					m_beforeSecond = m_beforeDateTime.Hour * 3600 + m_beforeDateTime.Minute * 60 + m_beforeDateTime.Second;
					m_afterSecond = m_afterDateTime.Hour * 3600 + m_afterDateTime.Minute * 60 + m_afterDateTime.Second;
					if(m_afterSecond - m_beforeSecond >= m_database.CountSecond && !isFinishedOnce) {
						isFinishedOnce = true;
						m_beforeDateTime = System.DateTime.Now;
						m_beforeDateTime.AddYears(1);
						m_beforeDateTime.AddMonths(1);
						m_beforeDateTime.AddDays(1);
						Debug.Log("before:" + m_beforeDateTime);
						m_sub = m_beforeDateTime.Subtract(m_tmp);
						m_text.text = m_sub.ToString();
					}

					if(isFinishedOnce) {
						m_beforeDateTime = System.DateTime.Now;
						m_sub = new TimeSpan(0,0, m_database.CountSecond);
						m_beforeDateTime -= m_sub;
						m_text.text = m_beforeDateTime.ToString();
					}

			});
		}

	}
		

}

