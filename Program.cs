namespace BillboardTallest
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BillboardTallest billboardTallest = new();
			Console.WriteLine(billboardTallest.TallestBillboard(new int[] { 1, 2, 3, 6 }));
			Console.WriteLine(billboardTallest.TallestBillboard(new int[] { 1, 2, 3, 4, 5, 6 }));
			Console.WriteLine(billboardTallest.TallestBillboard(new int[] { 1, 2 }));
		}
	}
}