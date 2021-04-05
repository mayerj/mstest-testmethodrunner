using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicDataExample
{
	[TestClass]
	public class UnitTest1
	{
		static int _executionCount = 0;

		private static IEnumerable<object[]> GetData()
		{
			_executionCount++;
			yield return new object[] { new object() };
		}

		[DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
		[DataTestMethod]
		public void TestMethod1(object input)
		{
			Assert.AreEqual(1, _executionCount);
			Assert.IsNotNull(input);
		}
	}
}
