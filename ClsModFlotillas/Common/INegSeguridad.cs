using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModHarodoor.Common
{
    public interface INegSeguridad<T>
    {
        T Login(T objModel, out ClsModResultado objClsModResultado);

    }
}
