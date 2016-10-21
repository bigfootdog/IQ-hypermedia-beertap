using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace MyHypemediaWebApi.ApiServices.Security
{

    public class MyHypemediaWebApiApiUser : ApiUser<UserAuthData>
    {
        public MyHypemediaWebApiApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class MyHypemediaWebApiUserFactory : ApiUserFactory<MyHypemediaWebApiApiUser, UserAuthData>
    {
        public MyHypemediaWebApiUserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override MyHypemediaWebApiApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new MyHypemediaWebApiApiUser("MyHypemediaWebApi user", auth);
        }
    }

}
