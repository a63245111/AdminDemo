using System;
namespace Admin.Common.Attribute
{
    /// <summary>
    /// 缓存验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CachingAttribute : System.Attribute
    {
        //缓存绝对过期时间
        public int AbsoluteExpiration { get; set; } = 30;
    }
}
