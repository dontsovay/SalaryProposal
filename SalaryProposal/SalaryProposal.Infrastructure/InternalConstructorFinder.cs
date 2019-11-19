using System;
using System.Linq;
using System.Reflection;
using Autofac.Core.Activators.Reflection;

namespace SalaryProposal.Infrastructure
{
    /// <summary></summary>
    /// <seealso cref="Autofac.Core.Activators.Reflection.IConstructorFinder" />
    public class InternalConstructorFinder : IConstructorFinder
    {
        /// <summary>Finds the constructors.</summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public ConstructorInfo[] FindConstructors(Type t) => t.GetTypeInfo().DeclaredConstructors.Where(c => !c.IsPrivate && !c.IsPublic).ToArray();
    }
}
