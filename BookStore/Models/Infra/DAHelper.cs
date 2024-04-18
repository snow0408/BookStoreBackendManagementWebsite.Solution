using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Infra
{
    public class DAHelper
    {
        public const string Required = "{0} 必填";
        public const string EmailAddress = "{0} 格式不正確";
        public const string StringLength = "{0} 長度不可大於 {1}";
        public const string StringLength2 = "{0} 長度必須為 {2} 到 {1}";
        public const string Compare = "{0} 與 {1} 不相同";
    }
}