using System;
using System.Windows.Forms;
using System.Reflection;

namespace FortniteReplayRepairer.Extensions
{
    public static class ControlExtensions
    {
        public static object GetPropertyValue<T>(this T control, string propName) where T : Control
        {
            object output = null;
            if (control.InvokeRequired)
            {
                control.Invoke((Action)delegate
               {
                   output = control.GetType().GetProperty(propName)?.GetValue(control);
               });
            } else
            {
                output = control.GetType().GetProperty(propName)?.GetValue(control);
            }

            return output;
        }

        public static void SetPropertyValue<T>(this T control, string propName, object value) where T : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke((Action)delegate
               {
                   control.GetType().GetProperty(propName)?.SetValue(control, value);

               });
            } else
            {
                control.GetType().GetProperty(propName)?.SetValue(control, value);
            }
        }

        public static object InvokeMember<T>(this T control, string methodName, params object[] values) where T : Control
        {
            object retObj = null;
            if (control.InvokeRequired)
            {
                control.Invoke((Action)delegate
               {
                   retObj = control.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, Type.DefaultBinder, control, values);
               });
            } else
            {
                retObj = control.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, Type.DefaultBinder, control, values);
            }

            return retObj;
        }
    }
}