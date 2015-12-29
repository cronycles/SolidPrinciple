using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	public class DependecInv : DisplayableSample, DisplayableSampleSplitted
	{
		public string Run()
		{
			var result = this.GetHeader();
			//result += Environment.NewLine + Environment.NewLine + RunWrongApproach();
			//result += Environment.NewLine + Environment.NewLine + RunCorrectApproach();

			return result;
		}

		public string GetHeader()
		{
			var result = "DependecInv.cs";
			result += Environment.NewLine + "one should \"Depend upon Abstractions\". Do not depend upon concretions";
			return result;
		}

		public string RunCorrectApproach()
		{
			throw new NotImplementedException();
		}

		public string RunWrongApproach()
		{
			throw new NotImplementedException();
		}
	}
}
