using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDatabase : MonoBehaviour {

	private int m_countSecond = 30;
	public int CountSecond {
		set {
			m_countSecond = value;
		}
		get {
			return m_countSecond;
		}
	}
}
