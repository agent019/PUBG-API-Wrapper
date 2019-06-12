using PUBGAPIWrapper.Service;

namespace PUBGAPIWrapper.Interfaces
{
    public interface IClient
    {
        Response Execute(Request request);
    }
}
