using System;
using System.Runtime;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace ListPerformance
{
	[TestFixture]
	public class ListPerformance
	{
		readonly int REPS = 1000000;
	
		public void TestAddRemoveLinked(int size)
		{
			var list = new LinkedList<int>();
			for (var i = 0; i < size; i++)
				list.AddLast(i);
			for (var r = 0; r < REPS; r++) {
                 list.AddFirst(77);
                 list.RemoveFirst();
            }			
		}

		public void TestAddRemoveArray(int size)
		{
			var list = new List<int>(size);
			for (var i = 0; i < size; i++)
				list.Add(i);
			for (var r = 0; r < REPS; r++) {
                 list.Insert(0, 77);
                 list.RemoveAt(0);
            }			
		}

		public void TestRandomAccessLinked(int size)
		{
			var list = new LinkedList<int>();
			for (var i = 0; i < size; i++)
				list.AddLast(i);
			int sum = 0;
			for (var r = 0; r < list.Count; r++)
                sum += list.Find(r).Value;
		}

		public void TestRandomAccessArray(int size)
		{
			var list = new List<int>(size);
			for (var i = 0; i < size; i++)
				list.Add(i);
			int sum = 0;
			for (var r = 0; r < list.Count; r++)
                sum += list[r];
		}

		[Test] public void TestAddRemoveL10() { TestAddRemoveLinked(10); }
		[Test] public void TestAddRemoveL100() { TestAddRemoveLinked(100); }
		[Test] public void TestAddRemoveL1000() { TestAddRemoveLinked(1000); }
		[Test] public void TestAddRemoveL10000() { TestAddRemoveLinked(10000); }
		[Test] public void TestAddRemoveA10() { TestAddRemoveArray(10); }
		[Test] public void TestRandomAccessL10() { TestRandomAccessLinked(10); }
		[Test] public void TestRandomAccessA10() { TestRandomAccessArray(10); }
		//TODO add the corresponding tests for the missing sizes 100, 1000, and 10000
	}
}

