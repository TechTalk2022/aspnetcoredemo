using System;
using System.Collections.Generic;
using System.Text;

namespace TechTalkDemo.Common
{
     
        public static class CommonVariable
        {
            public abstract class DefaultValues
            {
                public static string Zero = "0";
                public static string ONE = "1";
                public static string TWO = "2";
                public static string THREE = "3";
                public static string FOUR = "4";
                public static string FIVE = "5";
                public static string SIX = "6";
                public static string SEVEN = "7";
                public static string EIGHT = "8";
                public static string TEN = "10"; 
                public static string TRUE = "True";
                public static string FALSE = "False"; 
            }

             
            public static class GemBoxSettings
            {
                public const string LicenseKey = "1111-2222-333-444";
            }

            public static class DefaultValue
            {
                public const string Select = "Select";
                public const string Empty = "";
                public const string One = "1";
                public const string AllFAQs = "-1"; 
                public const string Delete = "Delete";
            }

            public static class TempDataField
            {
                public const string FormId = "tdf_FormId";
            }

            public static class ViewBagField
            {
                public const string FormId = "vbf_FormId";
            }

            /// <summary>
            ///
            /// </summary>
            public static class SessionField
            {
                public const string UserId = "sf_UserId";
            }
            }
}
