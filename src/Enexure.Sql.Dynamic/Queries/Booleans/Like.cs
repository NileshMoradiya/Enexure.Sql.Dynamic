﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enexure.Sql.Dynamic.Queries
{
	public class Like : Operator
	{
		public Like(IExpression expressionLeft, IExpression expressionRight)
			: base(expressionLeft, expressionRight)
		{
		}

		public override string OperatorSymbol
		{
			get { return "like"; }
		}
	}
}
