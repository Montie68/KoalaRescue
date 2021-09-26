using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.InfiniteRunnerEngine
{	
	public class Jump_n_Slide : Jumper 
	{

		/// <summary>
		/// On Start() we initialize the last jump time
		/// </summary>
		protected override void Start()
		{
			base.Start();
		}

		/// <summary>
		/// On update, we update the animator and try to reset the jumper's position
		/// </summary>
		protected override void Update ()
		{
			base.Update();
		}

		/// <summary>
		/// Updates all mecanim animators.
		/// </summary>
		protected override void UpdateAllMecanimAnimators()
		{
			base.UpdateAllMecanimAnimators();
			// TODO place Mecanim updates for ground slide here
		}

		// TODO get suitablie sliding animantion for characters place code here 
		public override void DownStart() {
			Debug.Log("going downnnn!");
		}
		public override void DownOngoing() { }
		public override void DownEnd() { }


	}
}