using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using EmptyWebApplication.Models;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace EmptyWebApplication.Auth
{
    public static class AudiencesStore
    {
        public static ConcurrentDictionary<string, Audience> AudiencesList = new ConcurrentDictionary<string, Audience>();

        static AudiencesStore()
        {
            AudiencesList.TryAdd("76794a8b02d24b48815cd0a81b39cdbf",
                                new Audience
                                {
                                    ClientId = "76794a8b02d24b48815cd0a81b39cdbf",
                                    Base64Secret = "VfIVi0JcRVHpvZaNVQfdkh2hNfPrm5Sez06unVn4CRU",
                                    Name = "Audience"
                                });
        }

        public static Audience AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RandomNumberGenerator.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            Audience newAudience = new Audience { ClientId = clientId, Base64Secret = base64Secret, Name = name };
            AudiencesList.TryAdd(clientId, newAudience);
            return newAudience;
        }

        public static Audience FindAudience(string clientId)
        {
            Audience audience = null;
            if (AudiencesList.TryGetValue(clientId, out audience))
            {
                return audience;
            }
            return null;
        }
    }
}