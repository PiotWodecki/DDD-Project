using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DDD.Base.InfrastructureLayer
{
    public class DialCodesReader
    {
        public static string LoadJson()
        {
            var json = "";
            using (StreamReader r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "dialcodes.json")))
            {
                json = r.ReadToEnd();
            }

            return json;
        }
    }
}
