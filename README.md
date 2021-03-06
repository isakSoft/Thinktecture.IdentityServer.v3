# Thinktecture IdentityServer v3 #

**Current status: Beta 4**

Dev build: [![Build status](https://ci.appveyor.com/api/projects/status/p3w7grusyd7cnctw?svg=true)](https://ci.appveyor.com/project/leastprivilege/thinktecture-identityserver-v3)
[![Gitter](https://badges.gitter.im/Join Chat.svg)](https://gitter.im/thinktecture/Thinktecture.IdentityServer.v3?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Overview ##

IdentityServer is a framework and a hostable component that allows implementing single sign-on and access control for modern web applications and APIs using protocols like OpenID Connect and OAuth2. It supports a wide range of clients like mobile, web, SPAs and desktop applications and is extensible to allow integration in new and existing architectures.

[OpenID Connect specification](http://openid.net/specs/openid-connect-core-1_0.html) / [OAuth2 specification](http://tools.ietf.org/html/rfc6749 "OAuth2 specification")

Watch this for the big picture: [Introduction to OpenID Connect, OAuth2 and IdentityServer](http://www.ndcvideos.com/#/app/video/2651).

## Getting started ##
We currently don't provide a setup tool or a UI, but IdentityServer is remarkably easy to setup. Start with downloading/cloning the repo. Open the solution in Visual Studio and start it. Use the various clients in the [samples](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.Samples) repository to exercise the various flows. Also check the wiki for more information.

IdSrv3 is designed as an OWIN/Katana component. The following configuration (in the host project) gives you a minimal implementation with in-memory repositories and user authentication.

```csharp
public void Configuration(IAppBuilder app)
{
    var factory = InMemoryFactory.Create(
        users:   Users.Get(), 
        clients: Clients.Get(), 
        scopes:  Scopes.Get());

    var options = new IdentityServerOptions
    {
        SiteName = "Thinktecture IdentityServer v3",
        SigningCertificate = Certificate.Get(),
        
        Factory = factory
    };

    app.UseIdentityServer(options);
}
```

You can find a test signing certificate and setup instructions in the [certificates](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.Samples/tree/master/source/Certificates) folder in the samples repository.

The host [samples](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.Samples/) shows other configuration options, including
* support for MembershipReboot and ASP.NET Identity based user stores
* support for additional Katana authentication middleware (e.g. Google, Twitter, Facebook etc)
* support for EntityFramework based persistence of configuration
* support for WS-Federation

## Related repositories ##
* [Access Token Validation](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.AccessTokenValidation)
* [EntityFramework support](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.EntityFramework)
* [MembershipReboot support](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.MembershipReboot)
* [ASP.Net Identity support](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.AspNetIdentity)
* [WS-Federation plugin](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.WsFederation)
* [Samples](https://github.com/thinktecture/Thinktecture.IdentityServer.v3.Samples)

## Credits ##
IdentityServer is built using the following great open source projects:

- [ASP.NET Web API](https://aspnetwebstack.codeplex.com/)
- [Autofac](http://autofac.org/)
- [Json.Net](http://james.newtonking.com/json)
- [LibLog](https://github.com/damianh/LibLog)
- [Katana](https://katanaproject.codeplex.com/)
- [Web Protection Library](https://wpl.codeplex.com/)
- [License Header Manager](https://visualstudiogallery.msdn.microsoft.com/5647a099-77c9-4a49-91c3-94001828e99e)

thanks to all [contributors](https://github.com/thinktecture/Thinktecture.IdentityServer.v3/graphs/contributors)!
