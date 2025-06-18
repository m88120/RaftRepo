using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raft.Test.Tests.TestData
{
	public static class UserApiResponseMocks
	{
		public static string GetUsersJson()
		{
			return $@"
{{
    ""page"": 1,
    ""per_page"": 6,
    ""total"": 12,
    ""total_pages"": 2,
    ""data"": [
        {{
            ""id"": 1,
            ""email"": ""george.bluth@reqres.in"",
            ""first_name"": ""George"",
            ""last_name"": ""Bluth"",
            ""avatar"": ""https://reqres.in/img/faces/1-image.jpg""
        }},
        {{
            ""id"": 2,
            ""email"": ""janet.weaver@reqres.in"",
            ""first_name"": ""Janet"",
            ""last_name"": ""Weaver"",
            ""avatar"": ""https://reqres.in/img/faces/2-image.jpg""
        }}
    ]
}}";
		}


		public static string GetUserByIdJson(int id)
		{
			return $@"
{{
  ""data"": {{
    ""id"": {id},
    ""email"": ""george.bluth@reqres.in"",
    ""first_name"": ""George"",
    ""last_name"": ""Bluth"",
    ""avatar"": ""https://reqres.in/img/faces/1-image.jpg""
  }}
}}";
		}

	}


}
