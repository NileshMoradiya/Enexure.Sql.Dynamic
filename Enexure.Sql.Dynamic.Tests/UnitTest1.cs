﻿using System;
using Enexure.Sql.Dynamic.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enexure.Sql.Dynamic.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var tableA = new Table("TableA").As("a");
			var tableB = new Table("TableB").As("b");

			var query = Query
				.From(tableA)
				.Join(tableB, Expression.Eq(tableA.Field("Id"), tableB.Field("Fk")))
				.Where(Expression.Eq(tableA.Field("Id"), Expression.Const(1)))
				.Select(tableA.Field("Id"), tableB.All());

			var sql = TSqlProvider.GetSqlString(query);

			var expected = 
				"select [a].[Id], [b].*" + Environment.NewLine +
				"from [TableA] [a]" + Environment.NewLine +
				"join [TableB] [b] on [a].[Id] = [b].[Fk]" + Environment.NewLine +
				"where [a].[Id] = @p";

			Assert.AreEqual(expected, sql);
		}
	}
}
