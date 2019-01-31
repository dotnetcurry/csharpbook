using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace DynamicBinding
{
    class MyDynamicObject : DynamicObject
    {
        private readonly Dictionary<string, object> members = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (members.ContainsKey(binder.Name))
            {
                result = members[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            members[binder.Name] = value;
            return true;
        }

        public bool RemoveMember(string name)
        {
            return members.Remove(name);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                var type = typeof(Dictionary<string, object>);
                result = type.InvokeMember(binder.Name,
                    BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance,
                    null, members, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public static explicit operator Dictionary<string, object>(MyDynamicObject instance)
        {
            return instance.members;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type.IsAssignableFrom(members.GetType()))
            {
                result = members;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }

}
