using FTranslate.Core.BaseClasses;

namespace FTranslate.Core.Interfaces
{
    public interface IHttpRequest
    {
        string GetRequestData(string langCode, string inpText);
    }
}
