using System;
using NUnit.Framework;
using StringExtensions;

namespace Test_StringExtensions
{
	public class StringExtTest {
		private string a = 
		"We the People of the United States, in Order to form a more perfect Union, establish Justice, insure domestic Tranquility, provide for the common defense, promote the general Welfare, and secure the Blessings of Liberty to ourselves and our Posterity, do ordain and establish this Constitution for the United States of America.";
		

		[SetUp]
		public void Setup()
		{
		}



		[TestCase("We")]
		[TestCase("We the People")]
		[Test]
		public void Success_StringStart(string b) {
			Assert.IsTrue(StringExtension.SpanSearcherContains(a,b),"A10:");
		}


		[TestCase("People")]
		[TestCase("America.")]
		[TestCase(", and secure the Blessings")]
		[TestCase("and establish this Constitution for the United States of America.")]
		[Test]
		public void Success_StringMiddle(string b)
		{
			Assert.IsTrue(StringExtension.SpanSearcherContains(a, b), "A10:");
		}



		[TestCase("We",0,10)]
		[TestCase("People",0,14)]
		[TestCase("Order", 0,46)]
		[TestCase("Order", 30, 53)]
		[Test]
		public void Success_Middle_LimitedSection(string b, int start, int end)
		{
			Assert.IsTrue(StringExtension.SpanSearcherContains(a, b,start,end), "A10:");
		}



		[TestCase("we")]
		[TestCase("we the People")]
		[TestCase("I")]
		[TestCase("xyz")]
		[Test]
		public void Fail_FullStringSearch(string b)
		{
			Assert.IsFalse(StringExtension.SpanSearcherContains(a, b), "A10:");
		}



		[TestCase("We",1,4)]
		[TestCase("People",8,120)]
		[TestCase("People", 8,12)]
		[TestCase("America.",50,60)]
		[Test]
		public void Fail_MiddleLimitedSection(string b, int start, int end)
		{
			Assert.IsFalse(StringExtension.SpanSearcherContains(a, b,start,end), "A10:");
		}


		[Test]
		public void Fail_IsNull()
		{
			Assert.IsFalse(StringExtension.SpanSearcherContains(null,"We"));
		}

		[Test]
		public void Fail_EmptyString () {
			Assert.IsFalse(StringExtension.SpanSearcherContains(String.Empty,"We"));
		}


		[Test]
		public void Success_IsNullBothStrings()
		{
			Assert.IsFalse(StringExtension.SpanSearcherContains(a, null));
		}

		[Test]
		public void Fail_SearchForIsEmpty()
		{
			Assert.IsFalse(StringExtension.SpanSearcherContains(a, string.Empty));
		}




	}
}