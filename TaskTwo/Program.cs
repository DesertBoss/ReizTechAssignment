using System;
using System.Collections.Generic;

namespace TaskTwo {
	class Program {
		static Random rand = new Random ();
		static void Main (string[] args) {
			var branch = new Branch ();

			RandBranches (branch, 14);
			//MyBranches (branch);

			Console.WriteLine ($"Depth of structure: {branch.GetDepth ()}");
			Console.ReadKey ();
		}

		static void MyBranches (Branch startBranch) {
			var branch1 = new Branch ();
			var branch2 = new Branch ();
			var branch3 = new Branch ();
			var branch4 = new Branch ();
			var branch5 = new Branch ();
			var branch6 = new Branch ();
			var branch7 = new Branch ();
			var branch8 = new Branch ();
			var branch9 = new Branch ();
			var branch10 = new Branch ();

			startBranch.AddBranch (branch1);
			startBranch.AddBranch (branch2);
			branch1.AddBranch (branch3);
			branch2.AddBranch (branch4);
			branch2.AddBranch (branch5);
			branch2.AddBranch (branch6);
			branch4.AddBranch (branch7);
			branch5.AddBranch (branch8);
			branch5.AddBranch (branch9);
			branch8.AddBranch (branch10);
		}

		static void RandBranches (Branch branch, int depth) {
			if (depth <= 0) return;
			depth -= 1;
			for (int i = 0; i < rand.Next (1, 3); i++) {
				if (rand.Next (100) > 95) continue;
				Branch chield = new Branch ();
				branch.AddBranch (chield);
				RandBranches (chield, depth);
			}
		}
	}

	class Branch {
		private List<Branch> branches;

		public Branch () {
			branches = new List<Branch> ();
		}

		public void AddBranch (Branch branch) {
			branches.Add (branch);
		}

		public void DeleteBranch (Branch branch) {
			branches.Remove (branch);
		}

		public int GetDepth () {
			int depthPrev = 0;
			int depthNow = branches.Count > 0 ? 1 : 0;
			int depth = 1;
			foreach (var branch in branches) {
				depth = Math.Max (depthPrev, depthNow + branch.GetDepth ());
				depthPrev = depth;
			}
			return depth;
		}
	}
}
