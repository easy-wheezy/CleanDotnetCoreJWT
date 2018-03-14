using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Contracts
{
    public interface IRequest
    {
    }
    public interface IRequest<out TResponse> { }
}
