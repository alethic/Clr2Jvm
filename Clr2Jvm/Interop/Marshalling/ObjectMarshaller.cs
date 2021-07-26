using System;
using System.Reflection;

using Clr2Jvm.Interop.Native;

namespace Clr2Jvm.Interop.Marshalling
{

    class ObjectMarshaller : Marshaller
    {

        public override bool CanMarshal(object value)
        {
            throw new NotImplementedException();
        }

        public override bool CanMarshal(JObject value)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo GetManagedType(JObject value)
        {
            throw new NotImplementedException();
        }

        public override TypeInfo GetMarshalType(object value)
        {
            throw new NotImplementedException();
        }

        public override MarshalledValue Marshal(object value)
        {
            throw new NotImplementedException();
        }

        public override object MarshalReturn(JObject value)
        {
            throw new NotImplementedException();
        }

    }

}
