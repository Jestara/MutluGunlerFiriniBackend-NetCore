using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSucccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isSucccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSucccess)
                {
                    OnSuccess(invocation);
                }

            }
            OnAfter(invocation);
        }
    }
}

