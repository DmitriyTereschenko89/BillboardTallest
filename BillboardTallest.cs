using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillboardTallest
{
	internal class BillboardTallest
	{
		private Dictionary<int, int> Helper(int[] rods, int leftIdx, int rightIdx)
		{
			HashSet<(int, int)> states = new();
			states.Add((0, 0));
			for (int i = leftIdx; i < rightIdx; ++i)
			{
				int r = rods[i];
				HashSet<(int, int)> newStates = new();
				foreach ((int, int) pair in states)
				{
					newStates.Add((pair.Item1 + r, pair.Item2));
					newStates.Add((pair.Item1, pair.Item2 + r));
				}
				states.UnionWith(newStates);
			}
			Dictionary<int, int> dp = new();
			foreach ((int, int) state in states)
			{
				int left = state.Item1;
				int right = state.Item2;
				dp[left - right] = Math.Max(dp.GetValueOrDefault(left - right), left);
			}
			return dp;
		}

		public int TallestBillboard(int[] rods)
		{
			int n = rods.Length;
			Dictionary<int, int> firstHalf = Helper(rods, 0, n / 2);
			Dictionary<int, int> secondHalf = Helper(rods, n / 2, n);
			int tallestBillboard = 0;
			foreach (int different in firstHalf.Keys)
			{
				if (secondHalf.ContainsKey(-different))
				{
					tallestBillboard = Math.Max(tallestBillboard, firstHalf[different] + secondHalf[-different]);
				}
			}
			return tallestBillboard;
		}
	}
}
