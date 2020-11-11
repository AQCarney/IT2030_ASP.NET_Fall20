using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PIG.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObject<T>(this ISession session, string key)
        {
            string jsonString = session.GetString(key);
            if (string.IsNullOrEmpty(jsonString))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
        }
    }
}
