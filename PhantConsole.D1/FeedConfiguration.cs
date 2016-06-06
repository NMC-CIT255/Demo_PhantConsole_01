using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantConsole.D1
{
    public static class PhantFeedConfiguration
    {
        public static string BaseHost_URL = "http://data.sparkfun.com";
        public static string PrivateKey = "4WwD54zyVRtjDBErYmXx";
        public static string PublicKey = "yAz56awylbHO0dvlpgY5";
        public static string DeleteKey = "avlA4oke9buZ5lKE16kM";

        public static string[] Fields = { "temp", "light", "humidity" };
    }
}
