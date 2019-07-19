using System;
using System.Threading.Tasks;
using NativeIOS.Model;
using Refit;

namespace NativeIOS.Services
{
    public interface IDropBoxContent
    {
        [Get("/s/2iodh4vg0eortkl/facts.json")]
        Task<DropBoxData> GetDropBoxContent();
    }
}
