using UnityEngine;

	public class MultiPlatformMovement : MonoBehaviour
	{


		public void MoveX(float amount, ForceMode forceMode)
		{
			if (NonTabletPlatform()){
				Debug.Log("Do something special here");
		}

		}

		private bool NonTabletPlatform()
		{
			return !(Application.platform == RuntimePlatform.OSXPlayer);
		}

	}