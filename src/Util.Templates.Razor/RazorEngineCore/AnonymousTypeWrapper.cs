using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace RazorEngineCore
{
    public class AnonymousTypeWrapper : DynamicObject
    {
        private readonly object model;

        public AnonymousTypeWrapper(object model)
        {
            this.model = model;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            PropertyInfo propertyInfo = this.model.GetType().GetProperty(binder.Name);

            if (propertyInfo == null)
            {
                result = null;
                return false;
            }

            result = propertyInfo.GetValue(this.model, null);

            if (result == null)
            {
                return true;
            }

            var type = result.GetType();

            if (result.IsAnonymous())
            {
                result = new AnonymousTypeWrapper(result);
            }

            bool isEnumerable = typeof(IEnumerable).IsAssignableFrom(type);

            if (isEnumerable && !(result is string))
            {
                result = ((IEnumerable<object>) result)
                        .Select(e =>
                        {
                            if (e.IsAnonymous())
                            {
                                return new AnonymousTypeWrapper(e);
                            }

                            return e;
                        })
                        .ToList();
            }
        

            return true;
        }
    }
}