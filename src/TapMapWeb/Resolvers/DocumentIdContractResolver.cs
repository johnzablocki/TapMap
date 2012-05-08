using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;

namespace TapMapWeb.Resolvers
{
	public class DocumentIdContractResolver : DefaultContractResolver
	{
		protected override List<System.Reflection.MemberInfo>
			GetSerializableMembers(Type objectType)
		{
			return base.GetSerializableMembers(objectType)
				.Where(o => o.Name != "Id").ToList();
		}
	}
}